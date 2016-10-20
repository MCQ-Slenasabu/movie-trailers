using DM.MovieApi.MovieDb.Movies;
using movie_trailers.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Web.Mvc;
using movie_trailers.Models;
using System;

namespace movie_trailers.DAL.Services
{
    public class OpenDBService : IMovie
    {
        Models.Movie _movie;
        Models.Movie IMovie.GetMovieInformation(string search)
        {
            _movie = JsonConvert.DeserializeObject<Models.Movie>(GetMovieByTitle(search).Data.ToString());
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
