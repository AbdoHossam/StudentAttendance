using System.Collections.Generic;

namespace Attendance.Web.Models
{
    public class StudentListViewModel
    {
        public IList<StudentViewModel> StudentViewModels { get; set; }
        public StudentViewModel StudentViewModel { get; set; } = new StudentViewModel();
    }
}
