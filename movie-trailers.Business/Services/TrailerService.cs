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
                IVideo _youtubeapi = VideoFactory.Get(VideoFactory.VideoTypes.Youtube);
                IMovie _opendbapi = MovieDBFactory.Get(MovieDBFactory.MovieDBTypes.Opendb);

                _movie = _opendbapi.GetMovieInformation(search);
                if(_movie.Title != null)
                {
                    _movie.Src = _youtubeapi.GetVideoUrl(_movie.Title, false);
                    _movie.EmbeddedSrc = _youtubeapi.GetVideoUrl(_movie.Title, true);
                }   
            }
            return _movie;
        }
    }
}