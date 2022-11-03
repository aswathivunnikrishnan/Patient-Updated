using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }
        // GET: /home/create
        [HttpGet]
        public ActionResult CreateStock()
        {
            return View();
        }
        //GET: /home/create
        [HttpPost]
        public ActionResult CreateStock(Stock s)
        {
            bool result = false;
            StockDBHelper helper = new StockDBHelper();
            try
            {
                if (ModelState.IsValid)
                {
                    result = helper.CreateStockDetails(s);
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

        public ActionResult GetAll()
        {

            try
            {
                StockDBHelper helper = new StockDBHelper();
                List<Stock> Stocks = helper.GetAllStock();
                return Json(new { data = Stocks }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            StockDBHelper objDBHandle = new StockDBHelper();
            Stock objStock = new Stock();

            var pat = objDBHandle.GetStockById(id);


            return View("Edit", pat);

        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Stock objStock)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    StockDBHelper objDBHandle = new StockDBHelper();
                    objDBHandle.UpdateStock(objStock);
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
    }
}