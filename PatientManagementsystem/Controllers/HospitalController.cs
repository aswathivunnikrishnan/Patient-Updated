using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /home/create
        [HttpGet]
        public ActionResult CreateHospital()
        {
            return View();
        }
        //GET: /home/create
        [HttpPost]
        public ActionResult CreateHospital(Hospital h)
        {
            bool result = false;
            HospitalDBHelper helper = new HospitalDBHelper();
            try
            {
                if (ModelState.IsValid)
                {
                    result = helper.CreateHospitalDetails(h);
                    ModelState.Clear();
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
        [HttpGet]
        public ActionResult GetAllHospital()
        {

            try
            {
                HospitalDBHelper helper = new HospitalDBHelper();
                List<Hospital> Hospital = helper.GetAllHospitalDetails();
                return Json(new { data = Hospital }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            HospitalDBHelper objDBHandle = new HospitalDBHelper();
            Hospital objHospital = new Hospital();

            var hospital = objDBHandle.GetHospitalDetailsById(id);


            return View("Edit", hospital);

        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Hospital objHospital)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    HospitalDBHelper objDBHandle = new HospitalDBHelper();
                    objDBHandle.UpdateHospital(objHospital);
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

            HospitalDBHelper helper = new HospitalDBHelper();
            Hospital objHospital = helper.GetHospitalDetailsById(id);
            return View("Delete", objHospital);

        }


        [HttpPost]
        public ActionResult Delete(int id, Patient patient)
        {
            bool result = false;
            try
            {
                HospitalDBHelper objDBHandle = new HospitalDBHelper();
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