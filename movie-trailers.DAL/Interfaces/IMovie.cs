using movie_trailers.Models;

namespace movie_trailers.Interfaces
{
    public interface IMovie
    {
        Movie GetMovieInformation(string search);
    }
}
