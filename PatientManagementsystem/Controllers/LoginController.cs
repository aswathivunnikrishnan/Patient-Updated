using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;

namespace PatientManagementsystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            login log= new login();
            log.HospitalName= new SelectList(getdropdown(), "Value", "Text");
            return View(log);
        }

        [HttpPost]
        public ActionResult Login(login loginview)
        {
            loginDBHelper db = new loginDBHelper();
            login log = new login();
            log.HospitalName = new SelectList(getdropdown(), "Value", "Text");
          HospitalDBHelper hospitalDBHelper = new HospitalDBHelper();


            if (TryValidateModel(loginview))
            {
                loginview.HospitalID = Convert.ToInt32(loginview.H_Name);
                Employee emp = db.GetEmployeeByUserName(loginview.UserName);
                //Doctor doc = db.GetDoctorByPhoneNumber(loginview.UserName);
                if (emp != null)
                {
                    if (emp.UserName == loginview.UserName && emp.Password == loginview.Password)
                    {
                        if(emp.Designation== "SUPERADMIN")
                        {
                            FormsAuthentication.SetAuthCookie(loginview.UserName, true);
                            return RedirectToAction("Index", "Hospital");
                        }
                        else if(emp.HospitalId == loginview.HospitalID)
                        {
                            Hospital hos = hospitalDBHelper.GetHospitalDetailsById(emp.HospitalId);
                            FormsAuthentication.SetAuthCookie(loginview.UserName, true);
                            return RedirectToAction("DashBoard", "Admin",new {id=emp.HospitalId, name = hos.Hospital_Name });
                        }
                        else
                            ModelState.AddModelError("", "Invalid Hospital id");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid password");

                    }
                    return View(log);
                }
                ModelState.AddModelError("", "Not a Registered User");

                return View(log);
            }
            return View(log);

           

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("login", "login");
        }

        private List<SelectListItem> getdropdown()
        {
            HospitalDBHelper hospitalDB= new HospitalDBHelper();
            List<Hospital> hospitals = hospitalDB.GetAllHospitalDetails();
            List<SelectListItem> dropdown = new List<SelectListItem>();

            foreach (var x in hospitals)
            {
                var item = new SelectListItem { Text = x.Hospital_Name, Value = x.Hospital_Id.ToString() };
                dropdown.Add(item);
            }
            return dropdown;
        }
    }

}