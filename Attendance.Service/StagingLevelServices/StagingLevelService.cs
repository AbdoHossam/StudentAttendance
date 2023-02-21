using Attendance.Core.Entities;
using Attendance.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StagingLevelServices
{
    public class StagingLevelService : IStagingLevelService
    {
        private readonly IRepository<StagingLevel> PaymentRepository;

        public StagingLevelService(IRepository<StagingLevel> PaymentRepository)
        {
            this.PaymentRepository = PaymentRepository;
        }

        public void Delete(StagingLevel entity)
        {
            PaymentRepository.Delete(entity);
        }

        public StagingLevel Get(Expression<Func<StagingLevel, bool>> expression, List<string> references)
        {
            var entity = PaymentRepository.Get(expression, references);
            return entity;
        }

        public IQueryable<StagingLevel> GetAll(Expression<Func<StagingLevel, bool>> expression, List<string> references)
        {
            var entities = PaymentRepository.GetAll(expression, references);
            return entities;
        }

        public IEnumerable<StagingLevel> GetAllPaginated(Expression<Func<StagingLevel, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true)
        {
            var entities = PaymentRepository.GetAllPaginated(expression, page, pageSize, references);
            return entities;
        }

        public void Insert(StagingLevel entity)
        {
            PaymentRepository.Insert(entity);
        }

        public void Update(StagingLevel entity)
        {
            PaymentRepository.Update(entity);
        }

        public void Update(IList<StagingLevel> entity)
        {
            PaymentRepository.Update(entity);
        }
    }
}
