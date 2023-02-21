using Attendance.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Attendance.Web.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public bool Unpaid { get; set; }
        public int Unpaidid { get; set; }
        public string UnPaidDate { get; set; }
        public IList<SelectListItem> Stagings { get; set; }
        public int StagingSchoolLevelId { get; set; }
        public virtual SchoolStagingViewModel StagingSchoolLevel { get; set; }
        public virtual StudentAttendanceViewModel StudentAttendanceViewModel { get; set; } = new StudentAttendanceViewModel();
    }
}
