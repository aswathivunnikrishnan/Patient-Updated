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
        public ActionResult Index(int id)
        {
            ViewBag.Hos_Id = id;
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
                    TempData["msg"] = "<script>alert('Product Created Successfully')</script>";
                    return RedirectToAction("Index", "Product", new { id = p.Hospital_id });
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

        public ActionResult GetAllProduct(int id)
        {

            try
            {
                ProductDBHelper helper = new ProductDBHelper();
                List<Product> Products = helper.GetAllProduct(id);
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
                    TempData["msg"] = "<script>alert('Product Updated Successfully')</script>";
                    return RedirectToAction("Index", "Product", new { id = objProduct.Hospital_id });
                    
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