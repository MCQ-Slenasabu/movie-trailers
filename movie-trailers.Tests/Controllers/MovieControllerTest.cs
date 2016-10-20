using Microsoft.VisualStudio.TestTools.UnitTesting;
using movie_trailers.Controllers;
using System.Web.Mvc;
using movie_trailers.BLL.Services;
using movie_trailers.Models;

namespace movie_trailers.Tests.Controllers
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void WhenNothingHasBeenFoundEmptySearchField()
        {
            MovieController moviecontroller = new MovieController(new StubTrailerService());

            ViewResult result = moviecontroller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenAMovieHasbeenFound()
        {
            var service = new StubTrailerService();
            service.GetTrailerInformation("Jason Bourne");

            MovieController moviecontroller = new MovieController(service);

            ViewResult result = moviecontroller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

    }

    public class StubTrailerService : ITrailerService
    {
        public Movie GetTrailerInformation(string search)
        {
            if (search == null)
            {
                return new Movie();
            }
            return ReturnMockMovie();
        }

        private Movie ReturnMockMovie()
        {
            return new Movie
            {
                Actors = "Matt Damon",
                Awards = "none",
                Country = "USA",
                Director = "Paul Greengrass",
                Genre = "Action",
                EmbeddedSrc = string.Empty,
                Language = "English",
                Metascore = "high",
                Plot = "interesting",
                Poster = "john doe",
                Released = "2016",
                Runtime = "2 hours",
                Src = "yeah on youtube",
                Title = "Jason Bourne",
                Writer = "Paulie again",
                Year = "2016"
            };
        }
    }
}
