using Attendance.Core.Entities;
using Attendance.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StagingSchoolLevelServices
{
    public class StagingSchoolLevelService : IStagingSchoolLevelService
    {
        private readonly IRepository<StagingSchoolLevel> PaymentRepository;

        public StagingSchoolLevelService(IRepository<StagingSchoolLevel> PaymentRepository)
        {
            this.PaymentRepository = PaymentRepository;
        }

        public void Delete(StagingSchoolLevel entity)
        {
            PaymentRepository.Delete(entity);
        }

        public StagingSchoolLevel Get(Expression<Func<StagingSchoolLevel, bool>> expression, List<string> references)
        {
            var entity = PaymentRepository.Get(expression, references);
            return entity;
        }

        public IQueryable<StagingSchoolLevel> GetAll(Expression<Func<StagingSchoolLevel, bool>> expression, List<string> references)
        {
            var entities = PaymentRepository.GetAll(expression, references);
            return entities;
        }

        public IEnumerable<StagingSchoolLevel> GetAllPaginated(Expression<Func<StagingSchoolLevel, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true)
        {
            var entities = PaymentRepository.GetAllPaginated(expression, page, pageSize, references);
            return entities;
        }

        public void Insert(StagingSchoolLevel entity)
        {
            PaymentRepository.Insert(entity);
        }

        public void Update(StagingSchoolLevel entity)
        {
            PaymentRepository.Update(entity);
        }

        public void Update(IList<StagingSchoolLevel> entity)
        {
            PaymentRepository.Update(entity);
        }
    }
}
