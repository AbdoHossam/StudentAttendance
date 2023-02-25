namespace Attendance.Web.Models
{
    public class StudentAttendanceViewModel
    {
        public int StudentId { get; set; }
        public bool HomeWork { get; set; }
        public string Exam { get; set; }
        public bool Payed { get; set; }
        public string Notes { get; set; }
    }
}
