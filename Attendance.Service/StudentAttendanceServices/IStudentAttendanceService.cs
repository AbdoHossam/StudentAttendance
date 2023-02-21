using Attendance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StudentAttendanceServices
{
    public interface IStudentAttendanceService
    {
        IQueryable<StudentAttendance> GetAll(Expression<Func<StudentAttendance, bool>> expression, List<string> references);
        IEnumerable<StudentAttendance> GetAllPaginated(Expression<Func<StudentAttendance, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true);
        StudentAttendance Get(Expression<Func<StudentAttendance, bool>> expression, List<string> references);
        void Insert(StudentAttendance entity);
        void Update(StudentAttendance entity);
        void Update(IList<StudentAttendance> entity);
        void Delete(StudentAttendance entity);
    }
}
