using System.ComponentModel.DataAnnotations;

namespace Attendance.Web.Models.Account
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name="Role")]
        public string RoleName { get; set; }
    }
}
