using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATB_Test_ex.Models.DB_Context;
using ATB_Test_ex.Models;
using ATB_Test_ex.Models.HelperClasses.Enums;

namespace ATB_Test_ex.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        public  ActionResult Index()
        {
            IEnumerable<EmployeeWrap> employes = from e in db.Employes
                                                 join d in db.Departments on e.DepartmentId equals d.DepartmentId
                                                 select new EmployeeWrap
                                                 {
                                                     EmployeeId = e.EmployeeId,
                                                     FullName = e.FullName,
                                                     Department = d.DepartmentName,
                                                     Adress = e.Adress,
                                                     City = e.City,
                                                     Phone = e.Phone,
                                                     BirsdayDate = e.BirsdayDate,
                                                     Sex = e.Sex                                           
                                                 };
            ViewBag.Employes = employes;


            //ViewBag.CityList =  DropDownContent.GetCityStringAsync();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}