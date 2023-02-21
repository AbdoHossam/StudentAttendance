﻿

using System;

namespace Attendance.Web.Models
{
    public class StudentHistoryViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public bool HomeWork { get; set; }
        public bool Exam { get; set; }
        public bool Payed { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifationDate { get; set; }
        public virtual StudentViewModel Student { get; set; }
    }
}