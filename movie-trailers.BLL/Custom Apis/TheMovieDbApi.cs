using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;

/* TheMovieDbWrapper is a C# wrapper for themoviedb.org API.

A nuget package is available directly through Visual Studio: https://www.nuget.org/packages/TheMovieDbWrapper/ */


namespace movie_trailers.Custom_Apis
{
    //At the moment we're only using this Wrapper for suggestions for my personal reasons :). 
    public class TheMovieDbApi 
    {
        public TheMovieDbApi()
        {
            MovieDbFactory.RegisterSettings("79367167d634285619db4ae7d66f1f6d", "http://api.themoviedb.org/3/");
        }
        
        public List<KeyValuePair<string, string>> ReturnSuggestions(List<Models.Movie> movies, string term)
        {
            var result = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < movies.Count; i++)
            {
                result.Add(new KeyValuePair<string, string>(i.ToString(), movies[i].Title));
            }
            return result.Where(s => s.Value.ToLower().Contains(term.ToLower())).Select(w => w).ToList();
        }

        public async Task<List<Models.Movie>> GetSuggestions(string search)
        { 
            List<Models.Movie> movies = new List<Models.Movie>();
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(search);
            foreach (var result in response.Results)
            {
                movies.Add(new movie_trailers.Models.Movie { Title = result.Title });
            }
            return movies;
        }
    }
}
