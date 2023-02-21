using Attendance.Core.Entities;
using Attendance.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.SchoolLevelServices
{
    public class SchoolLevelService : ISchoolLevelService
    {
        private readonly IRepository<SchoolLevel> PaymentRepository;

        public SchoolLevelService(IRepository<SchoolLevel> PaymentRepository)
        {
            this.PaymentRepository = PaymentRepository;
        }

        public void Delete(SchoolLevel entity)
        {
            PaymentRepository.Delete(entity);
        }

        public SchoolLevel Get(Expression<Func<SchoolLevel, bool>> expression, List<string> references)
        {
            var entity = PaymentRepository.Get(expression, references);
            return entity;
        }

        public IQueryable<SchoolLevel> GetAll(Expression<Func<SchoolLevel, bool>> expression, List<string> references)
        {
            var entities = PaymentRepository.GetAll(expression, references);
            return entities;
        }

        public IEnumerable<SchoolLevel> GetAllPaginated(Expression<Func<SchoolLevel, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true)
        {
            var entities = PaymentRepository.GetAllPaginated(expression, page, pageSize, references);
            return entities;
        }

        public void Insert(SchoolLevel entity)
        {
            PaymentRepository.Insert(entity);
        }

        public void Update(SchoolLevel entity)
        {
            PaymentRepository.Update(entity);
        }

        public void Update(IList<SchoolLevel> entity)
        {
            PaymentRepository.Update(entity);
        }
    }
}
