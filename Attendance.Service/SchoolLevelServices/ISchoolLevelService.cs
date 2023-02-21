using Attendance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.SchoolLevelServices
{
    public interface ISchoolLevelService
    {
        IQueryable<SchoolLevel> GetAll(Expression<Func<SchoolLevel, bool>> expression, List<string> references);
        IEnumerable<SchoolLevel> GetAllPaginated(Expression<Func<SchoolLevel, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true);
        SchoolLevel Get(Expression<Func<SchoolLevel, bool>> expression, List<string> references);
        void Insert(SchoolLevel entity);
        void Update(SchoolLevel entity);
        void Update(IList<SchoolLevel> entity);
        void Delete(SchoolLevel entity);
    }
}
