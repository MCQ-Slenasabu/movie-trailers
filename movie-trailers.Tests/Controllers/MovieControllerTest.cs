using Microsoft.VisualStudio.TestTools.UnitTesting;
using movie_trailers.Controllers;
using System.Web.Mvc;

namespace movie_trailers.Tests.Controllers
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void WhenNothingHasBeenFoundEmptySearchField()
        {
            MovieController _moviecontroller = new MovieController();

            ViewResult result = _moviecontroller.Index() as ViewResult;

          
        }

    }
}
