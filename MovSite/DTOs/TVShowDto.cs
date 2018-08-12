using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovSite.DTOs
{
    public class TVShowDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "TV Show name is required")]
        [StringLength(255, ErrorMessage = "TV Show name cannot be longer than 255 characters")]
        public string Name { get; set; }
        
        public int? ReleaseDate { get; set; }
        
        public DateTime? WhenSeen { get; set; }

        [Range(0, 10.0)]
        public double? RatingInIMDB { get; set; }

        [Required(ErrorMessage = "Your rating is required")]
        [Range(0, 10.0, ErrorMessage = "You rating must be between 0 and 10")]
        public double MyRating { get; set; }

        public bool Seen { get; set; }
    }
}