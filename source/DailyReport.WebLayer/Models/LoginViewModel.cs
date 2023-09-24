using System.ComponentModel.DataAnnotations;

namespace DailyReport.WebLayer.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "RememberMe?")]
        public bool RememberMe { get; set; }
    }
}
