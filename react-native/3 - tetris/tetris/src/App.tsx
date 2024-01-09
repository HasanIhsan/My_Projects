import Board from "./components/Board"
import { EmptyCell } from "./types"
import { useTetris } from "./hooks/useTetris"
//const board = Array(20).fill(null).map(() => Array(12).fill(EmptyCell.Empty));

function App() {
  const {board, startGame, isPlaying} = useTetris();


  return (
    <>
      <div>
        <h1>Tetris</h1>
        <Board currentBoard={board}/>
        <div className="controls">
          {isPlaying ? null : (
            <button onClick={startGame}>New Game</button>
          )}

        </div>
      </div>

     
    </>
  )
}

export default App
