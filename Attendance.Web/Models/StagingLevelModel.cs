using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace Attendance.Web.Models
{
    public class StagingLevelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<SelectListItem> SchoolLevel { get; set; }
    }
}
