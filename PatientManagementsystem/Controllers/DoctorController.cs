using DoctorManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace DoctorManagementsystem.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDoctor()
        {
            return View();
        }
        //GET: /home/create
        [HttpPost]
        public ActionResult CreateDoctor(Doctor d)
        {
            bool result = false;
            DoctorDBHelper helper = new DoctorDBHelper();
            try
            {
                if (ModelState.IsValid)
                {
                    result = helper.CreateDoctorDetails(d);
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

    public ActionResult GetAllDoctors()
    {

        try
        {
            DoctorDBHelper DBhelper = new DoctorDBHelper();
            List<Doctor> patients = DBhelper.GetAll();
            return Json(new { data = patients }, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            string str = ex.Message;
            return View();
        }

    }

    public ActionResult Edit(int id)
    {
        DoctorDBHelper objDBHandle = new DoctorDBHelper();
        Patient objPatient = new Patient();

        var pat = objDBHandle.GetDoctorById(id);


        return View("Edit", pat);

    }

    // POST: Patient/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, Doctor objDoctor)
    {
        try
        {

            if (ModelState.IsValid)
            {

                DoctorDBHelper objDBHandle = new DoctorDBHelper();
                objDBHandle.UpdateDoctor(objDoctor);
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

        DoctorDBHelper DBhelper = new DoctorDBHelper();
        Doctor objDoctor = DBhelper.GetDoctorById(id);
        return View("Delete", objDoctor);

    }


    [HttpPost]
    public ActionResult Delete(int id, Patient patient)
    {
        bool result = false;
        try
        {
            DoctorDBHelper objDBHandle = new DoctorDBHelper();
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
