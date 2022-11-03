using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        // GET: /home/create
        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        //GET: /home/create
        [HttpPost]
        public ActionResult CreateProduct(Product p)
        {
            bool result = false;
            ProductDBHelper helper = new ProductDBHelper();
            try
            {
                if (ModelState.IsValid)
                {
                    result = helper.CreateProductDetails(p);
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

        public ActionResult GetAll()
        {

            try
            {
                ProductDBHelper helper = new ProductDBHelper();
                List<Product> Products = helper.GetAllProduct();
                return Json(new { data = Products }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            ProductDBHelper objDBHandle = new ProductDBHelper();
            Product objProduct = new Product();

            var pat = objDBHandle.GetProductById(id);


            return View("Edit", pat);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    ProductDBHelper objDBHandle = new ProductDBHelper();
                    objDBHandle.UpdateProduct(objProduct);
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