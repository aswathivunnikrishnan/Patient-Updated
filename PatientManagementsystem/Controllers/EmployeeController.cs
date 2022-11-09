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
        public ActionResult Index(int id)
        {

            ViewBag.Hos_Id = id;
            return View();
        }

        public ActionResult DoctorIndex(int id)
        {

            ViewBag.Hos_Id = id;
            return View();
        }



        // GET: /home/create
        [HttpGet]
        public ActionResult CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.HospitalId = id;
            return View(employee);
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
                    TempData["msg"] = "<script>alert('Employee Created Successfully')</script>";
                    return RedirectToAction("Index", "Employee", new { id = e.HospitalId });

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

        public ActionResult GetAllEmployee(int id)
        {

            try
            {
                EmployeeDBHelper DBhelper = new EmployeeDBHelper();
                List<Employee> Employees = DBhelper.GetAllEmployees(id);
                return Json(new { data = Employees }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return View();
            }

        }

        public ActionResult GetAllDoctor(int id)
        {

            try
            {
                EmployeeDBHelper DBhelper = new EmployeeDBHelper();
                List<Employee> Employees = DBhelper.GetAllDoctor(id);
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
            ViewBag.Hos_Id = objEmployee.HospitalId;
            try
            {

                if (ModelState.IsValid)
                {

                    EmployeeDBHelper objDBHandle = new EmployeeDBHelper();
                    objDBHandle.UpdateEmployee(objEmployee);
                    TempData["msg"] = "<script>alert('Employee Updated Successfully')</script>";
                    return RedirectToAction("Index","Employee", new {id = objEmployee.HospitalId});
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message+ex.StackTrace);
                return View(objEmployee);
            }
            finally
            {
                ViewData["Final"] = "Final excecuted!";
            }
        }

        public ActionResult EditDoctor(int id)
        {
            EmployeeDBHelper objDBHandle = new EmployeeDBHelper();
            Employee objEmployee = new Employee();

            var pat = objDBHandle.GetEmployeeById(id);


            return View("Edit", pat);

        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditDoctor(int id, Employee objEmployee)
        {
            ViewBag.Hos_Id = objEmployee.HospitalId;
            try
            {

                if (ModelState.IsValid)
                {

                    EmployeeDBHelper objDBHandle = new EmployeeDBHelper();
                    objDBHandle.UpdateEmployee(objEmployee);
                    return RedirectToAction("DoctorIndex", "Employee", new { id = objEmployee.HospitalId });
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.StackTrace);
                return View(objEmployee);
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
                EmployeeDBHelper helper = new EmployeeDBHelper();
                Employee objEmployee = helper.GetEmployeeById(id);
                result = objDBHandle.DeleteData(id);
                TempData["msg"] = "<script>alert('Employee Deleted Successfully')</script>";
                return RedirectToAction("Index", "Employee", new { id = objEmployee.HospitalId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message + ex.StackTrace);
                return View();
            }
            
        }

    }


}