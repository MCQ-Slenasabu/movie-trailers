using movie_trailers.Custom_Apis;
using movie_trailers.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using movie_trailers.BLL.Services;

namespace movie_trailers.Controllers
{
    public class MovieController : Controller
    {
        private readonly ITrailerService _trailerservice;  

        public MovieController(ITrailerService trailerService)
        {
            this._trailerservice = trailerService;
        }

        public ActionResult Index(string query = "newest trailer")
        {
            return View(Search(query));
        }

        private Movie Search(string search)
        {
            CacheHelper.Add(search, _trailerservice.GetTrailerInformation(search), DateTimeOffset.UtcNow.AddMinutes(10));
            return _trailerservice.GetTrailerInformation(search);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<JsonResult> Autocomplete(string term)
        {
            TheMovieDbApi _themovieapi = new TheMovieDbApi();
            List<Movie> movies = await _themovieapi.GetSuggestions(term);
            var suggestions = _themovieapi.ReturnSuggestions(movies, term);
            return Json(suggestions, JsonRequestBehavior.AllowGet);
        }
    }
}