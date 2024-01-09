import { useCallback, useState } from "react";
import { hasCollisions, useTetrisBoard } from "./useTetrisBoard";
import { useInterval } from "./useInterval";
import { Block, BlockShape, BoardShape } from "../types";

enum TickSpeed {
    Normal = 800,
    Sliding = 100,
}

export function useTetris() {
    const [isPlaying, setIsPlaying] = useState(false);
    const [tickSpeed, setTickSpeed] = useState<TickSpeed | null>(null);
    const [isCommitting, setIsCommitting] = useState(false);

    const [
        {board, droppingRow, droppingColumn, droppingBlock, droppingShape},
        dispatchBoardState,
    ] = useTetrisBoard();

    const gameTick = useCallback(() => {
        if(isCommitting)
        {
            commitPosition();
        }else
        if(hasCollisions(board, droppingShape, droppingRow +1, droppingColumn)){
            setTickSpeed(TickSpeed.Sliding);
            setIsCommitting(true);
        }else {
            dispatchBoardState({type: 'drop'});
        }
    }, [board]);


    const commitPosition = useCallback(() => {
        if(!hasCollisions(board, droppingShape, droppingRow +1, droppingColumn)) {
            setIsCommitting(false);
            setTickSpeed(TickSpeed.Normal);
            return;
        }

        const newBoard = structuredClone(board) as BoardShape;

        addShapeToBoard(newBoard, droppingBlock, droppingShape, droppingRow, droppingColumn);
        setTickSpeed(TickSpeed.Normal);
        dispatchBoardState({type: 'commit', newBoard});
        setIsCommitting(false);
    },[board, dispatchBoardState, droppingBlock, droppingColumn, droppingRow, droppingShape])

    useInterval(() => {
        if(!isPlaying)
        {
            return;
        }
        gameTick();
    }, tickSpeed);


    const startGame = useCallback(() => {
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
