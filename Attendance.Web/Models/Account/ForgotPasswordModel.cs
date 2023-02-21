using System.ComponentModel.DataAnnotations;

namespace Attendance.Web.Models.Account
{
    public class ForgotPasswordModel
    {
        [Required]
        public string Email { get; set; }
    }
}
