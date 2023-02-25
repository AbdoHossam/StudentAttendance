using Attendance.Core.Entities;
using Attendance.Service.SchoolLevelServices;
using Attendance.Service.StagingSchoolLevelServices;
using Attendance.Service.StudentAttendanceServices;
using Attendance.Service.StudentServices;
using Attendance.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Attendance.Web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentAttendanceService studentAttendanceService;
        private readonly IStudentService studentService;
        private readonly ISchoolLevelService schoolLevelService;
        private readonly IStagingSchoolLevelService stagingSchoolLevelService;
        private readonly IMapper mapper;
        public StudentController(IStudentAttendanceService studentAttendanceService, IStudentService studentService, ISchoolLevelService schoolLevelService, IMapper mapper, IStagingSchoolLevelService stagingSchoolLevelService)
        {
            this.studentAttendanceService = studentAttendanceService;
            this.studentService = studentService;
            this.schoolLevelService = schoolLevelService;
            this.mapper = mapper;
            this.stagingSchoolLevelService = stagingSchoolLevelService;
        }

        public IActionResult Index()
        {
            var model = new StudentListViewModel
            {
                StudentViewModels = mapper.Map<IList<StudentViewModel>>(studentService.GetAll(x => true, new List<string> { "StagingSchoolLevel" })).Select(x =>
                {
                    var payeds = studentAttendanceService.GetAll(z => z.Payed == false && z.StudentId == x.Id, null);
                    var unpaid = (payeds.Any()) ? payeds.OrderByDescending(x => x.CreationDate).FirstOrDefault() : null;
                    x.Unpaid = (payeds.Any()) ? true : false;
                    x.UnPaidDate = (payeds.Any()) ? unpaid.CreationDate.ToShortDateString() : "";
                    x.Unpaidid = payeds.Any() ? unpaid.Id : 0;
                    return x;
                }).ToList(),
                StudentViewModel = new StudentViewModel
                {
                    Stagings = stagingSchoolLevelService.GetAll(x => true, new List<string> { "SchoolLevels", "StagingLevel" }).ToList().Select(x =>
                    {
                        var selectList = new SelectListItem
                        {
                            Text = x.StagingLevel.Name + " " + x.SchoolLevels.Name,
                            Value = x.Id.ToString(),
                        };
                        return selectList;
                    }).ToList(),
                }

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddHistory([FromBody] StudentAttendanceViewModel model)
        {
            if (model != null && model.StudentId != 0)
            {
                var entity = new StudentAttendance
                {
                    Id = 0,
                    CreationDate = DateTime.Now,
                    ModifationDate = DateTime.Now,
                    Exam = model.Exam,
                    HomeWork = model.HomeWork,
                    Notes = model.Notes,
                    StudentId = model.StudentId,
                    Payed = model.Payed
                };
                studentAttendanceService.Insert(entity);
            }
            return Json(true);
        }
        public IActionResult History()
        {
            var model = new HistoryListViewModel
            {
                StudentHistoryViews = mapper.Map<IList<StudentHistoryViewModel>>(studentAttendanceService.GetAll(x => true, new List<string> { "Student" }).ToList()),
                HistoryViewModel = new StudentHistoryViewModel()
            };
            return View(model);
        }

        public IActionResult UpdateHistory(int id)
        {
            var entity = studentAttendanceService.Get(x => x.Id == id, null);
            entity.Payed = true;
            studentAttendanceService.Update(entity);
            return Json(true);
        }
        [HttpPost]
        public IActionResult AddStudent(StudentListViewModel model)
        {
            var entity = new Student
            {
                Address = model.StudentViewModel.Address,
                Mobile = model.StudentViewModel.Mobile,
                Id = model.StudentViewModel.Id,
                Name = model.StudentViewModel.Name,
                Notes = model.StudentViewModel.Notes,
                Code = model.StudentViewModel.Code,
                Phone = model.StudentViewModel.Phone,
                StagingSchoolLevelId = model.StudentViewModel.StagingSchoolLevelId,
                City="Cairo",
                Region="Nasr",
                Status = model.StudentViewModel.Status,
                ModifationDate = DateTime.Now,
                CreationDate = DateTime.Now,

            };
            studentService.Insert(entity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(StudentListViewModel model)
        {
            var student = studentService.Get(x => x.Id == model.StudentViewModel.Id, null);
            student.Address = model.StudentViewModel.Address;
            student.Mobile = model.StudentViewModel.Mobile;
            student.Id = model.StudentViewModel.Id;
            student.Name = model.StudentViewModel.Name;
            student.Notes = model.StudentViewModel.Notes;
            student.Code = model.StudentViewModel.Code;
            student.Phone = model.StudentViewModel.Phone;
            student.StagingSchoolLevelId = model.StudentViewModel.StagingSchoolLevelId;
            student.Status = model.StudentViewModel.Status;
            student.ModifationDate = DateTime.Now;

            studentService.Update(student);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditHistory(HistoryListViewModel model)
        {
            if (model.HistoryViewModel !=null && model.HistoryViewModel.Id != 0)
            {
                var entity = studentAttendanceService.Get(x => x.Id == model.HistoryViewModel.Id, null);
                entity.HomeWork = model.HistoryViewModel.HomeWork;
                entity.Payed = model.HistoryViewModel.Payed;
                entity.Notes = model.HistoryViewModel.Notes;
                entity.ModifationDate = DateTime.Now;
                entity.Payed = model.HistoryViewModel.Payed;
                studentAttendanceService.Update(entity);
            }
            return RedirectToAction("History");
        }
    }
}
