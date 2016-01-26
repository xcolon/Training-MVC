using ProjectMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.UI.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllEmployee()
        {
            ViewBag.BindDepartment = Business.EmployeeBiz.BindDepartment();
            return View();
        }
        //public ActionResult AddEmployee(Model.EmployeeModel employee)
        //{
        //    Business.EmployeeBiz.Add(employee);     
        //    return View("");
        //}

        [HttpPost]
        public ActionResult AjaxGetAllEmployee(DataTableModel datatableData)
        {            
            return Json(new
            {
                draw = datatableData.draw,
                
                data = Business.EmployeeBiz.AllEmployee(datatableData)
            }, JsonRequestBehavior.AllowGet);
        }
        
    }
}