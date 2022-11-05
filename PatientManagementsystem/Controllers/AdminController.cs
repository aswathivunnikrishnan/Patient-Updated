using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admi
        public ActionResult DashBoard(int id)
        {
            ViewBag.Hos_Id = id;
            return View();
        }
    }
}