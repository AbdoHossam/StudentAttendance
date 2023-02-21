using System.ComponentModel.DataAnnotations;

namespace Attendance.Web.Models.Account
{
    public class EditRoleViewModel
    {

        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string newRoleName { get; set; }

    }
}
