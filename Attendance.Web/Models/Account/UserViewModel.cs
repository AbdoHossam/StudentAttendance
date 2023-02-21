using System.Collections.Generic;

namespace Attendance.Web.Models.Account
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
     
    }
    public class UserListViewModel 
    {
        public RegisterViewModel Register { get; set; }
        public List<UserViewModel> UserViewModels { get; set; }
    }
}
