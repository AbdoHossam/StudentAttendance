using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Attendance.Web.Models.Account
{
    public class CompleteProfileViewModel
    {
        public int ProgramDurationId { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
