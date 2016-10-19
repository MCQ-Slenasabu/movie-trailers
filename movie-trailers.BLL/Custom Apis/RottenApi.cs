using System;
using movie_trailers.Models;
using movie_trailers.Interfaces;

namespace movie_trailers.Custom_Apis
{
    public class RottenApi : IMovie
    {
        public Movie GetMovieInformation(string search)
        {
            throw new NotImplementedException();
        }
    }
}