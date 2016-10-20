using movie_trailers.Models;

namespace movie_trailers.DAL.Interfaces
{
    public interface IMovie
    {
        Movie GetMovieInformation(string search);
    }
}
