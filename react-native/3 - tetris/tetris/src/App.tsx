import Board from './components/Board';
import UpcomingBlocks from './components/UpcomingBlocks';
import { useTetris } from './hooks/useTetris';

function App() {
  const { board, startGame, stopGame, isPlaying, score, upcomingBlocks } = useTetris();

  return (
    <div className="app">
      <h1>Tetris</h1>
      <Board currentBoard={board} />
      <div className="controls">
        <h2>Score: {score}</h2>
     
        {isPlaying ? (
  <>
    <UpcomingBlocks upcomingBlocks={upcomingBlocks} />
    <button onClick={stopGame}>Stop Game</button>
  </>
) : (
  <button onClick={startGame}>New Game</button>
)}

       
      </div>
    </div>
  );
}

export default App;