﻿using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;
using System.Web.Services.Description;

namespace PatientManagementsystem.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index(int id)
        {
            ViewBag.Hos_Id = id;
            return View();
        }

        // GET: /home/create
        [HttpGet]
        public ActionResult CreatePatient()
        {
            return View();
        }
        //GET: /home/create
        [HttpPost]
        public ActionResult CreatePatient(Patient p)
        {
            bool result = false;
            PatientDBHelper helper = new PatientDBHelper();
            try
            {
                if (ModelState.IsValid)
                {
                    result = helper.CreatePatientDetails(p);
                    ModelState.Clear();
                    TempData["msg"] = "<script>alert('Patient Created Successfully')</script>";
                    return RedirectToAction("Index", "Patient", new { id = p.Hospital_id });
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
        
        public ActionResult GetAll(int id)
        {

            try
            {
                PatientDBHelper helper = new PatientDBHelper();
                List<Patient> patients = helper.GetAll(id);
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
            PatientDBHelper objDBHandle = new PatientDBHelper();
             Patient objPatient = new Patient();


            var pat = objDBHandle.GetPatientById(id);

            
            return View("Edit", pat);

        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Patient objPatient)
        {
            try
            {
               
                if (ModelState.IsValid)
                {

                    PatientDBHelper objDBHandle = new PatientDBHelper();
                    objDBHandle.UpdatePatient(objPatient);
                    //return RedirectToAction("Index");
                    TempData["msg"] = "<script>alert('Patient Updated Successfully')</script>";
                    return RedirectToAction("Index", "Patient", new { id = objPatient.Hospital_id });

                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.StackTrace);

                //return RedirectToAction("Index");
                return View(objPatient);

            }
            finally
            {
                ViewData["Final"] = "Final excecuted!";
            }
        }


        public ActionResult Delete(int id)
        {
           
                PatientDBHelper helper = new PatientDBHelper();
                Patient objPatient = helper.GetPatientById(id);
                return View("Delete", objPatient);

        }


        [HttpPost]
        public ActionResult Delete(int id, Patient patient)
        {
            bool result = false;
            try
            {
                PatientDBHelper objDBHandle = new PatientDBHelper();
                PatientDBHelper helper = new PatientDBHelper();
                Patient objPatient = helper.GetPatientById(id);
                result = objDBHandle.DeleteData(id);
                TempData["msg"] = "<script>alert('Patient Deleted Successfully')</script>";
                return RedirectToAction("Index", "Patient", new { id = objPatient.Hospital_id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.StackTrace);
                return View();
            }
        }

    }

}