using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PatientManagementsystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(login loginview)
        {
            loginDBHelper db = new loginDBHelper();
           
            if (ModelState.IsValid)
            {

                Employee emp = db.GetEmployeeByUserName(loginview.UserName);
                Doctor doc = db.GetDoctorByPhoneNumber(loginview.UserName);
                if (emp != null)
                {
                    if (emp.UserName == loginview.UserName && emp.Password == loginview.Password)
                    {
                        if (emp.HospitalId == loginview.HospitalID)
                        {
                            FormsAuthentication.SetAuthCookie(loginview.UserName, true);
                            return RedirectToAction("Index", "Hospital");
                        }
                        else
                            ModelState.AddModelError("", "Invalid Hospital id");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid password");

                    }
                    return View();
                }
                else if (doc != null)
                {

                    if (doc.D_PhoneNumber == loginview.UserName && doc.Password == loginview.Password)
                    {
                        if (doc.Hospital_id == loginview.HospitalID)
                        {
                            FormsAuthentication.SetAuthCookie(loginview.UserName, true);
                            return RedirectToAction("Index", "Patient");

                        }
                        else
                            ModelState.AddModelError("", "Invalid Hospital id");

                    }
                    else
                        ModelState.AddModelError("", "Invalid password");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", " Not a Registered user");
                    return View();
                }
            }
            return View();

           

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("login", "login");
        }
    }
}