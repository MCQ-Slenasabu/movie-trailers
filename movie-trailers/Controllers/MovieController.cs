using movie_trailers.Custom_Apis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace movie_trailers.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index(string query = "newest trailer")
        {
            ViewBag.Message = "";
            ViewBag.Name = "";
            return View(Search(query));
        }


        private Models.Movie Search(string search)
        {
            Models.Movie model = new Models.Movie();
            TrailerService _trailerservice = new TrailerService();
            model = _trailerservice.GetTrailerInformation(search);
            CacheHelper.Add(search, model, DateTimeOffset.UtcNow.AddMinutes(10));
            return model;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<JsonResult> Autocomplete(string term)
        {
            TheMovieDbApi _themovieapi = new TheMovieDbApi();
            List<Models.Movie> movies = await _themovieapi.GetSuggestions(term);
            var suggestions = _themovieapi.ReturnSuggestions(movies, term);
            return Json(suggestions, JsonRequestBehavior.AllowGet);
        }
    }
}