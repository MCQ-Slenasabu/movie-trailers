using System.Net;
using Newtonsoft.Json;
using movie_trailers.Interfaces;
using movie_trailers.Models;

namespace movie_trailers.Custom_Apis
{
    public class OpendbApi : IMovie
    {
        public Movie GetMovieInformation(string search)
        {
            Movie _movie;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://www.omdbapi.com/?t=" + search + "&y=&plot=short&r=json");
                _movie = JsonConvert.DeserializeObject<Movie>(json);
            }
            return _movie;
        }
    }
}