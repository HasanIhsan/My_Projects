import { useCallback, useEffect, useState } from "react";
import { getRandomBlock, hasCollisions, useTetrisBoard } from "./useTetrisBoard";
import { useInterval } from "./useInterval";
import { Block, BlockShape, BoardShape } from "../types";

enum TickSpeed {
    Normal = 800,
    Sliding = 100,
    Fast = 50,
}

export function useTetris() {
    const [isPlaying, setIsPlaying] = useState(false);
    const [tickSpeed, setTickSpeed] = useState<TickSpeed | null>(null);
    const [isCommitting, setIsCommitting] = useState(false);
    const [upcomingBlocks, setUpcomingBlocks] = useState<Block[]>([]);

    const [
        {board, droppingRow, droppingColumn, droppingBlock, droppingShape},
        dispatchBoardState,
    ] = useTetrisBoard();


    const commitPosition = useCallback(() => {
        if(!hasCollisions(board, droppingShape, droppingRow +1, droppingColumn)) {
            setIsCommitting(false);
            setTickSpeed(TickSpeed.Normal);
            return;
        }

        const newBoard = structuredClone(board) as BoardShape;

        addShapeToBoard(newBoard, droppingBlock, droppingShape, droppingRow, droppingColumn);
        
        const newUpcomingBlocks = structuredClone(upcomingBlocks) as Block[];
        const newBlock = newUpcomingBlocks.pop() as Block;
        upcomingBlocks.unshift(getRandomBlock());
        
        setTickSpeed(TickSpeed.Normal);
        setUpcomingBlocks(newUpcomingBlocks);
        dispatchBoardState({type: 'commit', newBoard, newBlock});
        setIsCommitting(false);
    },[board, dispatchBoardState, droppingBlock, droppingColumn, droppingRow, droppingShape])


    const gameTick = useCallback(() => {
    if (isCommitting) {
      commitPosition();
    } else if (
      hasCollisions(board, droppingShape, droppingRow + 1, droppingColumn)
    ) {
      setTickSpeed(TickSpeed.Sliding);
      setIsCommitting(true);
    } else {
      dispatchBoardState({ type: 'drop' });
    }
  }, [
    board,
    commitPosition,
    dispatchBoardState,
    droppingColumn,
    droppingRow,
    droppingShape,
    isCommitting,
  ]);


    
    useInterval(() => {
        if(!isPlaying)
        {
            return;
        }
        gameTick();
    }, tickSpeed);




    useEffect(() => {
        if(!isPlaying){
            return;
        }


        const handleKeyDown = (event: KeyboardEvent) => {
            if(event.key === 'ArrowDown') {
                setTickSpeed(TickSpeed.Fast);
            }

            if(event.key === 'ArrowUp') {
                dispatchBoardState({type: 'move', isRotating: true})
            }

            if(event.key === 'ArrowLeft') {
                dispatchBoardState({type: 'move', isPressingLeft: true})
            }

            if(event.key === 'ArrowRight') {
                dispatchBoardState({type: 'move', isPressingRight: true})
            }
        }

        const handlekeyUp = (event: KeyboardEvent) => {
            if(event.key === 'ArrowUp')
            {
                setTickSpeed(TickSpeed.Normal);
            }
        }
        document.addEventListener('keydown', handleKeyDown);
        document.addEventListener('keyup', handlekeyUp);
        return () => {
            document.removeEventListener('keydown', handleKeyDown);
            document.removeEventListener('keyup', handlekeyUp);
        }
    },[isPlaying])

    const startGame = useCallback(() => {
        const startingBlocks = [
            getRandomBlock(),
            getRandomBlock(),
            getRandomBlock(),
        ];
        setUpcomingBlocks(startingBlocks);
        setIsPlaying(true);
        setTickSpeed(TickSpeed.Normal);
        dispatchBoardState({type: 'start'});
    }, [dispatchBoardState]);
    

    const renderedBoard = structuredClone(board) as BoardShape;
    if(isPlaying)
    {
        addShapeToBoard(
            renderedBoard,
            droppingBlock,
            droppingShape,
            droppingRow,
            droppingColumn
        );
    }

 
    return {
        board: renderedBoard,
        startGame,
        isPlaying,
    }

}

function addShapeToBoard (
    board: BoardShape,
    droppingBlock: Block,
    droppingShape: BlockShape,
    droppingRow: number,
    droppingColumn: number

) {

    droppingShape
    .filter((row) => row.some((isSet) => isSet))
    .forEach((row: boolean[], rowIndex: number) => {
        row.forEach((isSet: boolean, colIndex: number) => {
            if(isSet){

                board[droppingRow + rowIndex][droppingColumn + colIndex] = droppingBlock;
                
                console.log( ` row ${droppingRow + rowIndex}`);
                console.log(` column ${droppingColumn + colIndex}`);
            }
        })
    })


}
