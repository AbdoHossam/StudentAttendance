using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attendance.Web.Models.SchoolstagingModel
{
    public class StagingSchoolModel
    {
        public int Id { get; set; }
        public int StagingLevelId { get; set; }
        public int SchoolLevelId { get; set; }
        public virtual SchoolLevelModel SchoolLevels { get; set; }
        public virtual StagingLevelsModel StagingLevel { get; set; }
        public IList<SelectListItem> SchoolLevelitems { get; set; }
    }
    public class StagingLevelsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
