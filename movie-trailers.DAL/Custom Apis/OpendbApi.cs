using System.Net;
using movie_trailers.Interfaces;
using movie_trailers.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace movie_trailers.Custom_Apis
{
    public class OpendbApi : IMovie
    {
        public Movie GetMovieInformation(string search)
        {
            Movie _movie = JsonConvert.DeserializeObject<Movie>(GetMovieByTitle(search).Data.ToString()); 
            return _movie;
        }

        private JsonResult GetMovieByTitle(string title)
        {
            JsonResult _jsonresult = new JsonResult();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://www.omdbapi.com/?t=" + title + "&y=&plot=short&r=json");
                _jsonresult.Data = json;
            }
            return _jsonresult;
        }

        private JsonResult GetMovieById(string movieId)
        {
            JsonResult _jsonresult = new JsonResult();
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://www.omdbapi.com/?=" + movieId + "&y=&plot=short&r=json");
                _jsonresult.Data = json;
            }
            return _jsonresult;
        }

        
    }
}