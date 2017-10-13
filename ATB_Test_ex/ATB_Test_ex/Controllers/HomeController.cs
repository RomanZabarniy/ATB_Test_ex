using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATB_Test_ex.Models.DB_Context;
using ATB_Test_ex.Models;
using ATB_Test_ex.Models.HelperClasses.Enums;
using ATB_Test_ex.Models.HelperClasses.Shared;
using System.Threading.Tasks;

namespace ATB_Test_ex.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        public async Task<ActionResult> Index()
        {
            ViewBag.CityList = await DropDownContent.GetCityStringAsync();
            return View();
        }

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

        [HttpPost]
        public JsonResult GetDepartmentsWithDef()
        {
            return Json(DropDownContent.GetDropDownDepart());
        }

        [HttpPost]
        public JsonResult SaveEmployee(EmployeeWrap data)
        {
            if (data == null)
                throw new Exception("Не указан объект сохранения!");
            Employee model = new Employee();
            try
            {
                 model.FullName = data.FullName;
                 model.City = data.City;
                 model.DepartmentId = data.DepartmentId;
                 model.EmployeeId = data.EmployeeId;
                 model.Sex = data.Sex ;
                 model.Adress = data.Adress;
                 //model.BirsdayDate = data.BirsdayDate;

            if (!ModelState.IsValid)
            {
                throw new Exception("Ошибки валидации модели");
            }
               
                 // db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Ошибка сохранения на сервере!");
            }
            return Json("Ok");
        }
    }
}