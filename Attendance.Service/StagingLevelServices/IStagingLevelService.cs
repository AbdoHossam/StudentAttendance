using Attendance.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StagingLevelServices
{
    public interface IStagingLevelService
    {
        IQueryable<StagingLevel> GetAll(Expression<Func<StagingLevel, bool>> expression, List<string> references);
        IEnumerable<StagingLevel> GetAllPaginated(Expression<Func<StagingLevel, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true);
        StagingLevel Get(Expression<Func<StagingLevel, bool>> expression, List<string> references);
        void Insert(StagingLevel entity);
        void Update(StagingLevel entity);
        void Update(IList<StagingLevel> entity);
        void Delete(StagingLevel entity);
    }
}
