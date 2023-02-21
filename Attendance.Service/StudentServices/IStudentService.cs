using Attendance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StudentServices
{
    public interface IStudentService
    {
        IQueryable<Student> GetAll(Expression<Func<Student, bool>> expression, List<string> references);
        IEnumerable<Student> GetAllPaginated(Expression<Func<Student, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true);
        Student Get(Expression<Func<Student, bool>> expression, List<string> references);
        void Insert(Student entity);
        void Update(Student entity);
        void Update(IList<Student> entity);
        void Delete(Student entity);
    }
}
