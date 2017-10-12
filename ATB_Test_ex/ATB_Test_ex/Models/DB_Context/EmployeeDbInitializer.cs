using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ATB_Test_ex.Models.DB_Context;
using ATB_Test_ex.Models;

namespace ATB_Test_ex.Models.DB_Context
{
    public class EmployeeDbInitializer : DropCreateDatabaseAlways <EmployeeContext>
    {
        protected override void Seed(EmployeeContext db) {
            db.Employes.Add(new Employee { FullName = "Мельников Еремей Ростиславович", Sex = "m", Adress = "692604, ул. Бассейная, дом 97, квартира 224", City = "Львов", Phone = "(067) 399-89-82", BirsdayDate = new DateTime(20/7/1979), DepartmentId = 1 });
            db.Employes.Add(new Employee { FullName = "Семёнова Элеонора Парфеньевна", Sex = "f", Adress = "644017 ул. Баженова, дом 31, квартира 1", City = "Николаев", Phone = "(063) 291-85-65", BirsdayDate = new DateTime(14/05/1995), DepartmentId = 1 });
            db.Employes.Add(new Employee { FullName = "Морозова Тамара Игоревна", Sex = "f", Adress = "162583,  ул. Академическая, дом 16, квартира 145", City = "Херсон", Phone = "(093) 890-17-43", BirsdayDate = new DateTime(1/9/1993), DepartmentId = 2 });
            db.Employes.Add(new Employee { FullName = "Тарасова Агата Геннадьевна", Sex = "f", Adress = "456915, ул. Авиаторов, дом 66, квартира 289", City = "Чернигов", Phone = "(099) 708-32-33", BirsdayDate = new DateTime(12/03/1988), DepartmentId = 2 });
            db.Employes.Add(new Employee { FullName = "Белозёров Ким Егорович", Sex = "m", Adress = "679380, ул. Бауманская, дом 42, квартира 123", City = "Харьков", Phone = "(097) 428-62-49", BirsdayDate = new DateTime(5/01/1983), DepartmentId = 3 });

            db.Departments.Add(new Department { DepartmentName = "Администрация" });
            db.Departments.Add(new Department { DepartmentName = "Бухгалтерия" });
            db.Departments.Add(new Department { DepartmentName = "Проектный отдел" });

            base.Seed(db);
        }
    }
}