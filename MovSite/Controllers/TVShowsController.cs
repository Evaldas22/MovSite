using MovSite.Models;
using MovSite.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MovSite.Controllers
{
    [Authorize]
    public class TVShowsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public TVShowsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: TVShows/Wishlist
        [HttpGet]
        public ViewResult Wishlist()
        {
            string userId = User.Identity.GetUserId();
            List<TVShow> tvShows = _dbContext.TVShows.Where(t => !t.Seen && t.UserID == userId).ToList();

            return View(tvShows);
        }

        // GET: TVShowsAlreadySeen
        [HttpGet]
        public ViewResult AlreadySeen()
        {
            string userId = User.Identity.GetUserId();
            List<TVShow> tvShows = _dbContext.TVShows.Where(t => t.Seen && t.UserID == userId).ToList();

            return View(tvShows);
        }

        [HttpGet]
        public ActionResult New(bool seen)
        {
            TVShowFormsViewModel tvShowViewModel = new TVShowFormsViewModel()
            {
                PageTitle = "New TV Show",
                ActionName = "New"
            };
        
            return seen ? View("TVShowSeenForm", tvShowViewModel) : View("TVShowWishlistForm", tvShowViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id, bool seen)
        {
            string userId = User.Identity.GetUserId();
            TVShow tvShow = _dbContext.TVShows.SingleOrDefault(t => t.Id == id && t.UserID == userId);

            if (tvShow == null) return HttpNotFound();

            TVShowFormsViewModel tvShowViewModel = new TVShowFormsViewModel(tvShow)
            {
                PageTitle = "Edit TV Show",
                ActionName = "Edit"
            };

            return seen ? View("TVShowSeenForm", tvShowViewModel) : View("TVShowWishlistForm", tvShowViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TVShow tvShow, bool seen, string actionName)
        {
            TVShowFormsViewModel tvShowViewModel = new TVShowFormsViewModel(tvShow);
            string userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return seen ? View("TVShowSeenForm", tvShowViewModel) : View("TVShowWishlistForm", tvShowViewModel);
            }

            // Now it's time to check if such movie already exists in db (EDIT mode doesn't count)
            if (_dbContext.TVShows.Any(t => t.Name == tvShow.Name && t.UserID == userId) && actionName.Equals("New"))
            {
                ModelState["Name"].Errors.Add("TV Show with that name already exists");
                TryValidateModel(tvShow);
                return seen ? View("TVShowSeenForm", tvShowViewModel) : View("TVShowWishlistForm", tvShowViewModel);
            }

            TVShow showInDb = _dbContext.TVShows.SingleOrDefault(t => t.Id == tvShow.Id);

            // create new if not existing
            if (showInDb == null)
            {
                tvShow.Seen = seen;
                tvShow.UserID = userId;
                _dbContext.TVShows.Add(tvShow);
            }
            else // or update already existing record
            {
                showInDb.Name = tvShow.Name;
                showInDb.ReleaseDate = tvShow.ReleaseDate;
                showInDb.WhenSeen = tvShow.WhenSeen;
                showInDb.RatingInIMDB = tvShow.RatingInIMDB;
                showInDb.MyRating = tvShow.MyRating;
                showInDb.Seen = seen;
            }
            _dbContext.SaveChanges();

            return seen ? RedirectToAction("AlreadySeen", "TVShows") :
                RedirectToAction("Wishlist", "TVShows");
        }

        [HttpGet]
        public ActionResult TVShowSeen(int id)
        {
            ViewBag.Text = "Please enter your rating";

            string userId = User.Identity.GetUserId();
            TVShow tvShow = _dbContext.TVShows.SingleOrDefault(t => t.Id == id && t.UserID == userId);

            if (tvShow == null) return HttpNotFound();

            tvShow.Seen = true;

            TVShowFormsViewModel tvShowViewModel = new TVShowFormsViewModel(tvShow)
            {
                MyRating = null,
                ActionName = "TVShowSeen"
            };

            return View("TVShowSeenForm", tvShowViewModel);
        }
        
        public ActionResult DeleteTVShow(int id, bool seen)
        {
            string userId = User.Identity.GetUserId();
            TVShow show = _dbContext.TVShows.SingleOrDefault(t => t.Id == id && t.UserID == userId);

            if (show == null) return HttpNotFound();

            _dbContext.TVShows.Remove(show);
            _dbContext.SaveChanges();

            return seen ? RedirectToAction("AlreadySeen", "TVShows") :
                RedirectToAction("Wishlist", "TVShows");
        }
    }
}