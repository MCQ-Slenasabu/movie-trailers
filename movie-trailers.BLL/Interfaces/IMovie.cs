using movie_trailers.Models;

namespace movie_trailers.Interfaces
{
    interface IMovie
    {
        Movie GetMovieInformation(string search);
    }
}
