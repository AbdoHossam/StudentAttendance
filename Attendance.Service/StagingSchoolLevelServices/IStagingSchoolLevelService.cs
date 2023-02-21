using Attendance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StagingSchoolLevelServices
{
    public interface IStagingSchoolLevelService
    {
        IQueryable<StagingSchoolLevel> GetAll(Expression<Func<StagingSchoolLevel, bool>> expression, List<string> references);
        IEnumerable<StagingSchoolLevel> GetAllPaginated(Expression<Func<StagingSchoolLevel, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true);
        StagingSchoolLevel Get(Expression<Func<StagingSchoolLevel, bool>> expression, List<string> references);
        void Insert(StagingSchoolLevel entity);
        void Update(StagingSchoolLevel entity);
        void Update(IList<StagingSchoolLevel> entity);
        void Delete(StagingSchoolLevel entity);
    }
}
