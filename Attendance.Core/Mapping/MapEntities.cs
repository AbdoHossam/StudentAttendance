using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Attendance.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Attendance.Core.Mapping
{
    public static class MapEntities
    {
        
        public static void AttendanceMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAttendance>().ToTable("Attendance", "dbo");
            modelBuilder.Entity<StudentAttendance>().HasKey(x => x.Id);
            modelBuilder.Entity<StudentAttendance>().Property(x => x.HomeWork).IsRequired();
            modelBuilder.Entity<StudentAttendance>().Property(x => x.Exam).IsRequired();
            modelBuilder.Entity<StudentAttendance>().Property(x => x.Exam ).IsRequired();
            modelBuilder.Entity<StudentAttendance>().Property(x => x.Payed).IsRequired();
            modelBuilder.Entity<StudentAttendance>().Property(x => x.Notes).IsRequired();
            modelBuilder.Entity<StudentAttendance>().Property(x => x.CreationDate).IsRequired();
            modelBuilder.Entity<StudentAttendance>().Property(x => x.ModifationDate).IsRequired();
            modelBuilder.Entity<StudentAttendance>().HasOne(x => x.Student).WithMany(x => x.Attendances).HasForeignKey(x => x.StudentId);
        }
        public static void StudentMap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student", "dbo");
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.Code).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Phone).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Mobile).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Notes).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Address).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.City).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.Region).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.CreationDate).IsRequired();
            modelBuilder.Entity<Student>().Property(x => x.ModifationDate).IsRequired();

        }
        public static void SchoolLevelMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolLevel>().ToTable("SchoolLevel", "dbo");
            modelBuilder.Entity<SchoolLevel>().HasKey(x => x.Id);
            modelBuilder.Entity<SchoolLevel>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<SchoolLevel>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<SchoolLevel>().Property(x => x.CreationDate).IsRequired();
            modelBuilder.Entity<SchoolLevel>().Property(x => x.ModifationDate).IsRequired();
        }
        public static void StagingLevelMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StagingLevel>().ToTable("StagingLevel", "dbo");
            modelBuilder.Entity<StagingLevel>().HasKey(x => x.Id);
            modelBuilder.Entity<StagingLevel>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<StagingLevel>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<StagingLevel>().Property(x => x.CreationDate).IsRequired();
            modelBuilder.Entity<StagingLevel>().Property(x => x.ModifationDate).IsRequired();
        }
        public static void StagingSchoolLevelMapping(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<StagingSchoolLevel>().ToTable("StagingSchoolLevel", "dbo");
            modelBuilder.Entity<StagingSchoolLevel>().HasKey(x => x.Id);
            modelBuilder.Entity<StagingSchoolLevel>().Property(x => x.CreationDate).IsRequired();
            modelBuilder.Entity<StagingSchoolLevel>().Property(x => x.ModifationDate).IsRequired();
            modelBuilder.Entity<StagingSchoolLevel>().HasOne(x=>x.StagingLevel).WithMany(z=>z.StagingSchoolLevels).HasForeignKey(x=>x.StagingLevelId);
            modelBuilder.Entity<StagingSchoolLevel>().HasOne(x=>x.SchoolLevels).WithMany(z=>z.StagingSchoolLevels).HasForeignKey(x=>x.SchoolLevelId);
            modelBuilder.Entity<StagingSchoolLevel>().HasMany(x => x.Students).WithOne(x => x.StagingSchoolLevel).HasForeignKey(x => x.StagingSchoolLevelId);
        }
    }
}
