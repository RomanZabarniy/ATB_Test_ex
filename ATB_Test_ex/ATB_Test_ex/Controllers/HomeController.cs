using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATB_Test_ex.Models.DB_Context;
using ATB_Test_ex.Models;
using ATB_Test_ex.Models.HelperClasses.Enums;
using ATB_Test_ex.Models.HelperClasses.Shared;

namespace ATB_Test_ex.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        public  ActionResult Index()  { return View(); }

        public ActionResult About()   { return View(); }

        public ActionResult Contact() { return View(); }

        [HttpPost]
        public JsonResult GetEmployeeList()
        {
            IEnumerable<EmployeeWrap> employes = (from e in db.Employes
                                                 join d in db.Departments on e.DepartmentId equals d.DepartmentId
                                                 select new EmployeeWrap
                                                 {
                                                     EmployeeId = e.EmployeeId,
                                                     FullName = e.FullName,
                                                     DepartmentName = d.DepartmentName,
                                                     DepartmentId = e.DepartmentId,
                                                     Adress = e.Adress,
                                                     City = e.City,
                                                     Phone = e.Phone,
                                                     BirsdayDate = e.BirsdayDate,
                                                     //BDateString = e.BirsdayDate == null ? "" : DateConverterHelper.DateForWeb(e.BirsdayDate),
                                                     BDateString = null,
                                                     Sex = e.Sex
                                                 }).ToList();
            return Json(employes);
        }
    }
}