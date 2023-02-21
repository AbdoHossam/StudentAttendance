using Attendance.Core.Entities;
using Attendance.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> PaymentRepository;

        public StudentService(IRepository<Student> PaymentRepository)
        {
            this.PaymentRepository = PaymentRepository;
        }

        public void Delete(Student entity)
        {
            PaymentRepository.Delete(entity);
        }

        public Student Get(Expression<Func<Student, bool>> expression, List<string> references)
        {
            var entity = PaymentRepository.Get(expression, references);
            return entity;
        }

        public IQueryable<Student> GetAll(Expression<Func<Student, bool>> expression, List<string> references)
        {
            var entities = PaymentRepository.GetAll(expression, references);
            return entities;
        }

        public IEnumerable<Student> GetAllPaginated(Expression<Func<Student, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true)
        {
            var entities = PaymentRepository.GetAllPaginated(expression, page, pageSize, references);
            return entities;
        }

        public void Insert(Student entity)
        {
            PaymentRepository.Insert(entity);
        }

        public void Update(Student entity)
        {
            PaymentRepository.Update(entity);
        }

        public void Update(IList<Student> entity)
        {
            PaymentRepository.Update(entity);
        }
    }
}
