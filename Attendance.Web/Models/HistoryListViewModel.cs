using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendance.Web.Models
{
    public class HistoryListViewModel
    {
        public StudentHistoryViewModel HistoryViewModel { get; set; }
        public IList<StudentHistoryViewModel> StudentHistoryViews { get; set; }
    }
}
