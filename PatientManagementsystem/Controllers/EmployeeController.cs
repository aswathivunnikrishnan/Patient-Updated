using EmployeeManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementsystem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        // GET: /home/create
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }
        //GET: /home/create
        [HttpPost]
        public ActionResult CreateEmployee(Employee e)
        {
            bool result = false;
            EmployeeDBHelper helper = new EmployeeDBHelper();
            try
            {
                if (ModelState.IsValid)
                {
                    result = helper.CreateEmployeeDetails(e);
                    ModelState.Clear();
                    //return Json(result, JsonRequestBehavior.AllowGet);
                    return View("Index");
                }
                else
                    return View();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View();
            }
        }

        //Get :

        public ActionResult GetAllEmployee()
        {

            try
            {
                EmployeeDBHelper DBhelper = new EmployeeDBHelper();
                List<Employee> Employees = DBhelper.GetAllEmployees();
                return Json(new { data = Employees }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            EmployeeDBHelper objDBHandle = new EmployeeDBHelper();
            Employee objEmployee = new Employee();

            var pat = objDBHandle.GetEmployeeById(id);


            return View("Edit", pat);

        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee objEmployee)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    EmployeeDBHelper objDBHandle = new EmployeeDBHelper();
                    objDBHandle.UpdateEmployee(objEmployee);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            finally
            {
                ViewData["Final"] = "Final excecuted!";
            }
        }


        public ActionResult Delete(int id)
        {

            EmployeeDBHelper helper = new EmployeeDBHelper();
            Employee objEmployee = helper.GetEmployeeById(id);
            return View("Delete", objEmployee);

        }


        [HttpPost]
        public ActionResult Delete(int id, Employee Employee)
        {
            bool result = false;
            try
            {
                EmployeeDBHelper objDBHandle = new EmployeeDBHelper();
                result = objDBHandle.DeleteData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

    }


}