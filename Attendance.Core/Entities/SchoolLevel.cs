using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Core.Entities
{
    public class SchoolLevel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StagingSchoolLevel> StagingSchoolLevels { get; set; }
    }
    public class StagingLevel : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StagingSchoolLevel> StagingSchoolLevels { get; set; }
    }
    public class StagingSchoolLevel : BaseEntity
    {
        public int StagingLevelId { get; set; }
        public int SchoolLevelId { get; set; }
        public virtual SchoolLevel SchoolLevels { get; set; }
        public virtual StagingLevel StagingLevel { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
