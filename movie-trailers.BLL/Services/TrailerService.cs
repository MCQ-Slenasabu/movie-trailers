using movie_trailers.DAL.Interfaces;
using movie_trailers.Models;

namespace movie_trailers.BLL.Services
{
    public class TrailerService : ITrailerService
    {
        public Movie GetTrailerInformation(string search)
        {
            Movie movie = CacheHelper.GetValue(search) as Movie;
            if (movie == null)
            {
                movie = new Movie();
                IVideo youtubeTrailerService = VideoFactory.Get(VideoFactory.VideoTypes.Youtube);
                IMovie opendbTrailerService = MovieDBFactory.Get(MovieDBFactory.MovieDBTypes.Opendb);

                movie = opendbTrailerService.GetMovieInformation(search);
               
                if (movie.Title != null)
                {
                    GetMovieSources(movie, youtubeTrailerService);
                }   
            }
            return movie;
        }

        private void GetMovieSources(Movie movie, IVideo video)
        {
            movie.Src = video.GetVideoUrl(movie.Title, false);
            movie.EmbeddedSrc = video.GetVideoUrl(movie.Title, true);
        }
    }
}