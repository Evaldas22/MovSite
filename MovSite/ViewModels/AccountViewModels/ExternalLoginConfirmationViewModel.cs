using System.ComponentModel.DataAnnotations;

namespace MovSite.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        public string Username { get; set; }

        //[Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}