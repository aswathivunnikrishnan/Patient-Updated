using EmployeeManagementsystem.DAL;
using PatientManagementsystem.DAL;
using PatientManagementsystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagementsystem.Controllers
{
    [Authorize]
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
        public ActionResult CreateProduct(int id)
        {
            Product product = new Product();
            product.Hospital_id = id;
            return View(product);
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
                    return View(p);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ModelState.AddModelError("", message);
                return View(p);
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

        public ActionResult Delete(int id)
        {

            ProductDBHelper helper = new ProductDBHelper();
            Product objProduct = helper.GetProductById(id);
            return View(objProduct);

        }



        [HttpPost]

        public ActionResult Delete(int id, Product Product)
        {
            bool result = false;
            try
            {
                ProductDBHelper objDBHandle = new ProductDBHelper();
                ProductDBHelper helper = new ProductDBHelper();
                Product objProduct = helper.GetProductById(id);
                result = objDBHandle.DeleteData(id);
                TempData["msg"] = "<script>alert('Product Deleted Successfully')</script>";
                return RedirectToAction("Index", "Product", new { id = objProduct.Hospital_id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.StackTrace);
                return View();
            }

        }
    }
}