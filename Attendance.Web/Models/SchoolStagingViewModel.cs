namespace Attendance.Web.Models
{
    public class SchoolStagingViewModel
    {
        public int Id { get; set; }
        public string StagingName { get; set; }
        public string SchoolName { get; set; }
    }
    public class SchoolLevelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StagingLevelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
