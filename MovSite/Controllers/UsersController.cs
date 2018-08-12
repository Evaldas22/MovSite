using Microsoft.AspNet.Identity;
using MovSite.Models;
using MovSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovSite.Controllers
{
    [Authorize(Roles = RoleName.CanManageUsers)]
    public class UsersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public UsersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        // GET: Users
        public ActionResult Index()
        {
            if (!User.IsInRole(RoleName.CanManageUsers)) return HttpNotFound();

            var users = _dbContext.Users.ToList();

            return View(users);
        }
        
        public ActionResult DeleteUser(string id)
        {
            ApplicationUser userInDb = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null) return HttpNotFound();

            // In order to delete a user, all movies/tv shows that have reference to it (userId)
            // need to be deleted. Otherwise I will get error.
            string userId = userInDb.Id;
            _dbContext.Movies.RemoveRange(_dbContext.Movies.Where(m => m.UserID == userId));
            _dbContext.TVShows.RemoveRange(_dbContext.TVShows.Where(t => t.UserID == userId));

            // And then user can safely be deleted
            _dbContext.Users.Remove(userInDb);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
    }
}