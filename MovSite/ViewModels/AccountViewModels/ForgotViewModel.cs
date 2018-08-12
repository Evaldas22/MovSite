using System.ComponentModel.DataAnnotations;

namespace MovSite.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}