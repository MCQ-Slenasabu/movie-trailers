using movie_trailers.Interfaces;
using movie_trailers.Models;

namespace movie_trailers.Custom_Apis
{
    public class TrailerService
    {
        public Movie GetTrailerInformation(string search)
        {
            Movie _movie = CacheHelper.GetValue(search) as Movie;
            if (_movie == null)
            {
                _movie = new Movie();
                IVideo _youtubeTrailerService = VideoFactory.Get(VideoFactory.VideoTypes.Youtube);
                IMovie _opendbTrailerService = MovieDBFactory.Get(MovieDBFactory.MovieDBTypes.Opendb);

                _movie = _opendbTrailerService.GetMovieInformation(search);
               
                if (_movie.Title != null)
                {
                    GetMovieSources(_movie, _youtubeTrailerService);
                }   
            }
            return _movie;
        }

        private void GetMovieSources(Movie movie, IVideo video)
        {
            movie.Src = video.GetVideoUrl(movie.Title, false);
            movie.EmbeddedSrc = video.GetVideoUrl(movie.Title, true);
        }
    }
}