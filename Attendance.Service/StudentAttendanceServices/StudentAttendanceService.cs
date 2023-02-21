using Attendance.Core.Entities;
using Attendance.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Service.StudentAttendanceServices
{
    public class StudentAttendanceService : IStudentAttendanceService
    {
        private readonly IRepository<StudentAttendance> PaymentRepository;

        public StudentAttendanceService(IRepository<StudentAttendance> PaymentRepository)
        {
            this.PaymentRepository = PaymentRepository;
        }

        public void Delete(StudentAttendance entity)
        {
            PaymentRepository.Delete(entity);
        }

        public StudentAttendance Get(Expression<Func<StudentAttendance, bool>> expression, List<string> references)
        {
            var entity = PaymentRepository.Get(expression, references);
            return entity;
        }

        public IQueryable<StudentAttendance> GetAll(Expression<Func<StudentAttendance, bool>> expression, List<string> references)
        {
            var entities = PaymentRepository.GetAll(expression, references);
            return entities;
        }

        public IEnumerable<StudentAttendance> GetAllPaginated(Expression<Func<StudentAttendance, bool>> expression, int page, int pageSize, List<string> references, bool ascending = true)
        {
            var entities = PaymentRepository.GetAllPaginated(expression, page, pageSize, references);
            return entities;
        }

        public void Insert(StudentAttendance entity)
        {
            PaymentRepository.Insert(entity);
        }

        public void Update(StudentAttendance entity)
        {
            PaymentRepository.Update(entity);
        }

        public void Update(IList<StudentAttendance> entity)
        {
            PaymentRepository.Update(entity);
        }
    }
}
