using MovSite.Models;
using MovSite.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MovSite.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Movies/Wishlist
        [HttpGet]
        public ViewResult Wishlist()
        {
            return View();
        }

        // GET: Movies/AlreadySeen
        [HttpGet]
        public ViewResult AlreadySeen()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New(bool seen)
        {
            MovieFormsViewModel movieViewModel = new MovieFormsViewModel()
            {
                PageTitle = "New Movie",
                ActionName = "New"
            };

            return seen ? View("MovieSeenForm", movieViewModel) : View("MovieWishlistForm", movieViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id, bool seen)
        {
            string userId = User.Identity.GetUserId();
            Movie movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id && m.UserID == userId);

            if (movie == null) return HttpNotFound();

            MovieFormsViewModel movieViewModel = new MovieFormsViewModel(movie)
            {
                PageTitle = "Edit Movie",
                ActionName = "Edit"
            };

            return seen ? View("MovieSeenForm", movieViewModel) : View("MovieWishlistForm", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie, bool seen, string actionName)
        {
            MovieFormsViewModel movieViewModel = new MovieFormsViewModel(movie);

            string userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return seen ? View("MovieSeenForm", movieViewModel) : View("MovieWishlistForm", movieViewModel);
            }
            
            // Now it's time to check if such movie already exists in db FOR THAT USERS ONLY (EDIT mode doesn't count)
            if(_dbContext.Movies.Any(m => m.Name == movie.Name && m.UserID == userId) 
                && actionName.Equals("New"))
            { 
                ModelState["Name"].Errors.Add("Movie with that name already exists");
                TryValidateModel(movie);
                return seen ? View("MovieSeenForm", movieViewModel) : View("MovieWishlistForm", movieViewModel);
            }

            Movie movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == movie.Id);

            // create new if not existing, and update if already exists
            if (movieInDb == null)
            {
                movie.Seen = seen;
                movie.UserID = userId;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.WhenSeen = movie.WhenSeen;
                movieInDb.RatingInIMDB = movie.RatingInIMDB;
                movieInDb.MyRating = movie.MyRating;
                movieInDb.Seen = seen;
            }
            _dbContext.SaveChanges();

            return seen ? RedirectToAction("AlreadySeen", "Movies") :
                RedirectToAction("Wishlist", "Movies");
        }

        [HttpGet]
        public ActionResult MovieSeen(int id)
        {
            ViewBag.Text = "Please enter your rating";
            string userId = User.Identity.GetUserId();

            Movie movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id && m.UserID == userId);

            if (movieInDb == null) return HttpNotFound();

            movieInDb.Seen = true;

            MovieFormsViewModel movieViewModel = new MovieFormsViewModel(movieInDb)
            {
                MyRating = null,
                ActionName = "MovieSeen"
            };

            return View("MovieSeenForm", movieViewModel);
        }

        // this action is not used. To delete record API call + jquery are used
        public ActionResult DeleteMovie(int id, bool seen)
        {
            Movie movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return seen ? RedirectToAction("AlreadySeen", "Movies") :
                RedirectToAction("Wishlist", "Movies");
        }
    }
}