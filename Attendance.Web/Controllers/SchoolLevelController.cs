using Attendance.Core.Entities;
using Attendance.Service.SchoolLevelServices;
using Attendance.Service.StagingLevelServices;
using Attendance.Service.StagingSchoolLevelServices;
using Attendance.Web.Models;
using Attendance.Web.Models.SchoolstagingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Attendance.Web.Controllers
{
    public class SchoolLevelController : Controller
    {
        private readonly IStagingSchoolLevelService stagingSchoolLevelService;
        private readonly IStagingLevelService stagingLevelService;
        private readonly ISchoolLevelService schoolLevelService;


        public SchoolLevelController(IStagingLevelService stagingLevelService, IStagingSchoolLevelService stagingSchoolLevelService, ISchoolLevelService schoolLevelService)
        {
            this.stagingLevelService = stagingLevelService;
            this.stagingSchoolLevelService = stagingSchoolLevelService;
            this.schoolLevelService = schoolLevelService;
        }

        public ActionResult Index()
        {
            var model = stagingSchoolLevelService.GetAll(x => true, new List<string> { "SchoolLevels", "StagingLevel" }).ToList().Select(x =>
            {
                return new StagingSchoolModel
                {
                    Id = x.Id,
                    SchoolLevelId = x.SchoolLevelId,
                    StagingLevelId= x.StagingLevelId,
                    SchoolLevels = new SchoolLevelModel 
                    {
                        Id= x.SchoolLevels.Id,
                        Description = x.SchoolLevels.Description,
                        Name = x.SchoolLevels.Name
                    },
                    StagingLevel = new StagingLevelsModel
                    {
                        Id= x.StagingLevelId,
                        Description= x.StagingLevel.Description,
                        Name = x.StagingLevel.Name
                    }
                };
            }).ToList();
            return View(model);
        }

        public ActionResult AddNewSchool()
        {
            var model = new StagingSchoolModel {

                SchoolLevelitems = schoolLevelService.GetAll(x => true, null).ToList().Select(x => {
                    var select = new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    };
                    return select;
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddNewSchool(StagingSchoolModel model)
        {
            var stagingSchool = new StagingLevel
            {
                Id = model.StagingLevel.Id,
                Name = model.StagingLevel.Name,
                Description = model.StagingLevel.Description,
                CreationDate = DateTime.Now,
                ModifationDate = DateTime.Now,
            };
            if (model.Id == 0)
            {
                stagingLevelService.Insert(stagingSchool);
                var entity = new StagingSchoolLevel
                {
                    Id = model.Id,
                    StagingLevelId = stagingSchool.Id,
                    SchoolLevelId = model.SchoolLevelId,
                    CreationDate = DateTime.Now,
                    ModifationDate = DateTime.Now,
                };
                stagingSchoolLevelService.Insert(entity);
            }
            else
            {
                stagingLevelService.Update(stagingSchool);
                var entity = new StagingSchoolLevel
                {
                    Id = model.Id,
                    StagingLevelId = stagingSchool.Id,
                    SchoolLevelId = model.SchoolLevelId,
                    CreationDate = DateTime.Now,
                    ModifationDate = DateTime.Now,
                };
                stagingSchoolLevelService.Update(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: LevelController/Edit/5
        public ActionResult EditSchool(int id)
        {
            var entity = stagingSchoolLevelService.Get(x => x.Id == id, new List<string> { "SchoolLevels", "StagingLevel" });
            var model = new StagingSchoolModel
            {
                Id = entity.Id,
                SchoolLevelId = entity.SchoolLevelId,
                StagingLevelId = entity.StagingLevelId,
                SchoolLevels = new SchoolLevelModel
                {
                    Id = entity.SchoolLevels.Id,
                    Description = entity.SchoolLevels.Description,
                    Name = entity.SchoolLevels.Name
                },
                StagingLevel = new StagingLevelsModel
                {
                    Id = entity.StagingLevelId,
                    Description = entity.StagingLevel.Description,
                    Name = entity.StagingLevel.Name
                },
                SchoolLevelitems = schoolLevelService.GetAll(x => true, null).ToList().Select(x => {
                     var select = new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.Name
                     };
                     return select;
                 }).ToList()
            };
            return View("AddNewSchool", model);
        }
    }
}
