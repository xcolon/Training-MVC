using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.Model;

namespace ProjectMVC.UI.Web.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProject()
        {
            ViewBag.BindDepartment = Business.ProjectBiz.BindDepartmentName();
            return View();
        }
        
        [HttpPost]
        public ActionResult AddProject(Model.ProjectModal projectName)
        {
            Business.ProjectBiz.Add(projectName);
            TempData["notice"] = "Successfully";
            return View("ProjectList", Business.ProjectBiz.ListOfProject());
        }

        public ActionResult ProjectList()
        {
            return View("ProjectList", Business.ProjectBiz.ListOfProject());
        }

        public ActionResult Edit(int id)
        {
            ViewBag.BindDepartment = Business.ProjectBiz.BindDepartmentName();
            return View("Edit", Business.ProjectBiz.Edit(id));
        }

        [HttpPost]
        public ActionResult Edit(Model.ProjectModal project)
        {
            Business.ProjectBiz.Update(project);
            TempData["notice"] = "Successfull";
            return View("ProjectList", Business.ProjectBiz.ListOfProject());
        }

        [HttpPost]
        public ActionResult ProjectList(string name, string location)
        {
            return View(Business.ProjectBiz.Search(name,location));
        }

        public ActionResult Delete(int id)
        {
            Business.ProjectBiz.Delete(id);
            TempData["notice"] = "Successfull";
            return View("ProjectList", Business.ProjectBiz.ListOfProject());
        }

        public JsonResult AjaxGetAllData(ProjectModal project)
        {
            return Json( new {data = Business.ProjectBiz.ListOfProject() },JsonRequestBehavior.AllowGet);
        }
    }
}