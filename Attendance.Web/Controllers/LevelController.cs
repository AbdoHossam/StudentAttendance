using Attendance.Core.Entities;
using Attendance.Service.SchoolLevelServices;
using Attendance.Service.StagingLevelServices;
using Attendance.Service.StagingSchoolLevelServices;
using Attendance.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Attendance.Web.Controllers
{
    public class LevelController : Controller
    {
        
        private readonly ISchoolLevelService schoolLevelService;


        public LevelController(ISchoolLevelService schoolLevelService, IStagingSchoolLevelService stagingSchoolLevelService, IStagingLevelService stagingLevelService)
        {
            this.schoolLevelService = schoolLevelService;

        }

        // GET: LevelController
        public ActionResult Index()
        {
            var model = schoolLevelService.GetAll(x => true, null).ToList().Select(x =>
            {
                return new SchoolLevelModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                };
            }).ToList();
            return View(model);
        }

        public ActionResult AddNewSchool()
        {
            return View(new SchoolLevelModel());
        }
        [HttpPost]
        public ActionResult AddNewSchool(SchoolLevelModel model)
        {
            var entity = new SchoolLevel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreationDate = DateTime.Now,
                ModifationDate = DateTime.Now,
            };
            if (model.Id == 0)
            {
                schoolLevelService.Insert(entity);
            }
            else
            {
                schoolLevelService.Update(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: LevelController/Edit/5
        public ActionResult EditSchool(int id)
        {
            var entity = schoolLevelService.Get(x => x.Id == id, null);
            var model = new SchoolLevelModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
            return View("AddNewSchool",model);
        }
    }
}
