
import './App.css';
import MovieList from './components/MovieList';
import Timer from './components/Timer';
import Counter from './components/Counter';


function App() {
  const movies = [
    { title: 'Man of steel', year: 2008, cast: ['Henry Cavil', 'Russel Crowe'] },
    { title: 'Harry Potter', year: 2008, cast: ['Daniel', 'Ema Watson'] },
    { title: 'Sherlock', year: 2010, cast: ['Benedict Cumberbatch', 'Martin Freeman', 'Una Stubbs'] },
  ];
  return (
    <div className="App">
      <h1>React Demo</h1>
      <Timer start={0} />
      <Counter canReset />
      <MovieList movies={movies} />
    </div>
  );
}

export default App;
