using Attendance.Core.Entities;
using Attendance.Web.Models;
using Attendance.Web.Models.Account;
using AutoMapper;

namespace Attendance.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<AppUser, UserViewModel>().ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.FirstName +" " + x.LastName))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id));
            CreateMap<Student, StudentViewModel>();
            CreateMap<SchoolLevel, SchoolLevelViewModel>();
            CreateMap<StagingLevel, StagingLevelViewModel>();
            CreateMap<StagingSchoolLevel, SchoolStagingViewModel>().ForMember(x=>x.SchoolName,opt=>opt.MapFrom(x=>x.SchoolLevels.Name))
                        .ForMember(x => x.StagingName, opt => opt.MapFrom(x => x.StagingLevel.Name));
            CreateMap<StudentHistoryViewModel, StudentAttendance>();
            CreateMap<StudentAttendance, StudentHistoryViewModel>();
        }
    }
}
