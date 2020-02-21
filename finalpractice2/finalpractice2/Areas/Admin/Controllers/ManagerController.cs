using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalpractice2.Areas.Admin.Models;
using finalpractice2.Models;
using finalproject2.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finalpractice2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ManagerController : Controller
    {
        private IManagerService _managerService;
        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        public IActionResult Index()
        {
            var model = new ManagerViewModel();
            return View(model);
        }
        public IActionResult GetManagers()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ManagerViewModel();
            var data = model.GetManagers(tableModel);
            return Json(data);
        }
        public IActionResult Add()
        {
            var model = new ManagerUpdateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ManagerUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddNewManager();
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new ManagerUpdateModel();
            model.Load(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ManagerViewModel();
            model.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ManagerUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditManager();
            }
            return View(model);
        }
    }
}