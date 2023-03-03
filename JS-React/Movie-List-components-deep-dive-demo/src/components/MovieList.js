import Movie from './Movie';

export default function MovieList({
    movies,
    onMovieDelete,
    onMovieSelect }) {


    return [
        <ul>
            {movies.map(movie => (
                <li key={movie.id}>
                    <Movie{...movie}
                        onMovieDelete={onMovieDelete}
                        onMovieSelect={onMovieSelect} />
                </li>
            ))}
        </ul>
        // title={firstMovie.title}
        // year={firstMovie.year}
        // plot={firstMovie.plot}
        // posterUrl={firstMovie.posterUrl}
        // director={firstMovie.director}
        // />
    ];
}