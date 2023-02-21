using Attendance.Data.Repository;
using Attendance.Service.SchoolLevelServices;
using Attendance.Service.StagingLevelServices;
using Attendance.Service.StagingSchoolLevelServices;
using Attendance.Service.StudentAttendanceServices;
using Attendance.Service.StudentServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.Injection
{
    public static class ExtensionMethod
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IStudentAttendanceService, StudentAttendanceService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISchoolLevelService, SchoolLevelService>();
            services.AddScoped<IStagingLevelService, StagingLevelService>();
            services.AddScoped<IStagingSchoolLevelService, StagingSchoolLevelService>();
        }
    }
}
