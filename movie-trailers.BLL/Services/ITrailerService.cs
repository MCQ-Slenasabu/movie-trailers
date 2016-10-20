using movie_trailers.Models;

namespace movie_trailers.BLL.Services
{
    public interface ITrailerService
    {
        Movie GetTrailerInformation(string search);
    }
}