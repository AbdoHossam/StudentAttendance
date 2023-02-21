using Attendance.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, List<string> references);
        IEnumerable<T> GetAllPaginated(Expression<Func<T, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true);
        T Get(Expression<Func<T, bool>> expression, List<string> references);
        void Insert(T entity);
        void Update(T entity);
        void Update(IList<T> entity);
        void Delete(T entity);
    }
}
