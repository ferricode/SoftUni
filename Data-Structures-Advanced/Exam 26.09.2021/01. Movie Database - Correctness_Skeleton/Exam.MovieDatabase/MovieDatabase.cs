using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private LinkedList<Movie> movies;
        private Dictionary<string, Movie> moviesById;
        private Dictionary<string, List<Movie>> actorInMovies;
        private Dictionary<string, int> actorPopularity;

        public MovieDatabase()
        {
            moviesById = new Dictionary<string, Movie>();
            actorInMovies = new Dictionary<string, List<Movie>>();
            actorPopularity = new Dictionary<string, int>();
            movies = new LinkedList<Movie>();
        }
        public int Count => movies.Count;

        public void AddMovie(Movie movie)
        {

            if (!movies.Contains(movie))
            {
                moviesById[movie.Id] = movie;
                movies.AddLast(movie);

                foreach (var actor in movie.Actors)
                {
                    if (!this.actorInMovies.ContainsKey(actor))
                    {
                        this.actorInMovies[actor] = new List<Movie>();
                    }
                    actorInMovies[actor].Add(movie);
                }


            }
        }
        public bool Contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> GetAllMoviesOrderedByActorPopularityThenByRatingThenByYear()
        {
            // return moviesById.OrderBy(kvp=>ForEach(var actor in kvp.Value.Actors.actorInMovies[actor]))
            //foreach (var actor in actorInMovies.Keys)
            //{
            //    actorPopularity[actor] = actorInMovies[actor].Count;
            //}
            //movies.OrderBy(m=>ForEach(m.Actors))
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByActor(string actorName)
        {
            if (actorInMovies[actorName]==null)
            {
                throw new ArgumentException();
            }
            return actorInMovies[actorName].OrderByDescending(m => m.Rating).ThenByDescending(m => m.ReleaseYear);
        }

        public IEnumerable<Movie> GetMoviesByActors(List<string> actors)
        {
            if (movies.Where(m => !m.Actors.Except(actors).Any()) == null)
            {
                throw new ArgumentException();
            }
            return this.movies
                .Where(m => !m.Actors.Except(actors).Any())
                .OrderByDescending(m => m.Rating)
                .ThenByDescending(m => m.ReleaseYear).ToList();
        }

        public IEnumerable<Movie> GetMoviesByYear(int releaseYear)
        {
            return movies.Where(m => m.ReleaseYear == releaseYear).OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesInRatingRange(double lowerBound, double upperBound)
        {
            return movies.Where(m => lowerBound <= m.Rating && m.Rating <= upperBound).OrderByDescending(m => m.Rating);
        }

        public void RemoveMovie(string movieId)
        {
            if (!moviesById.ContainsKey(movieId))
            {
                throw new ArgumentException();
            }
            var movieToRemove = moviesById[movieId];

            moviesById.Remove(movieId);
            movies.Remove(movieToRemove);

            foreach (var movie in actorInMovies.Values)
            {
                if (movie.Contains(movieToRemove))
                {
                    movie.Remove(movieToRemove);
                }
            }

        }
    }
}
