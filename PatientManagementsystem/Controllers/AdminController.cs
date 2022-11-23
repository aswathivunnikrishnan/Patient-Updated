using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult DashBoard(int id, string name)
        {
            ViewBag.Hos_Id = id;
            ViewBag.Hos_Name = name;
            return View();
        }
    }
}