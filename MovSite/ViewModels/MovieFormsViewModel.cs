using Microsoft.AspNet.Identity;
using MovSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovSite.ViewModels
{
    public class MovieFormsViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Movie name is required")]
        [StringLength(255, ErrorMessage = "Movie name cannot be longer than 255 characters")]
        public string Name { get; set; }

        [Display(Name = "Release Date(yyyy)")]
        public int? ReleaseDate { get; set; }

        [Display(Name = "Seen date(yyyy-mm-dd)")]
        public DateTime? WhenSeen { get; set; }

        [Range(0, 10.0)]
        [Display(Name = "Rating in IMDB")]
        public double? RatingInIMDB { get; set; }

        [Required(ErrorMessage = "Your rating is required")]
        [Range(0, 10.0, ErrorMessage = "You rating must be between 0 and 10")]
        [Display(Name = "My rating")]
        public double? MyRating { get; set; }

        public bool? Seen { get; set; }

        public string UserID { get; set; }

        public string PageTitle { get; set; }
        public string ActionName { get; set; }

        public MovieFormsViewModel()
        {
            Id = 0;
        }

        public MovieFormsViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            WhenSeen = movie.WhenSeen;
            RatingInIMDB = movie.RatingInIMDB;
            MyRating = movie.MyRating;
            Seen = movie.Seen;
        }
    }
}