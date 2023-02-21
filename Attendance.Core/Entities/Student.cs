using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Core.Entities
{
    public class Student : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int StagingSchoolLevelId { get; set; }
        public virtual StagingSchoolLevel StagingSchoolLevel { get; set; }
        public virtual ICollection<StudentAttendance> Attendances { get; }

    }
}
