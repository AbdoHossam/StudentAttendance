namespace Attendance.Core.Entities
{
    public class StudentAttendance : BaseEntity
    {
        public int StudentId { get; set; }
        public bool HomeWork { get; set; }
        public string Exam { get; set; }
        public bool Payed { get; set; }
        public string Notes { get; set; }
        public virtual Student Student { get; set; }
    }
}