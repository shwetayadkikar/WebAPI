using APIWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_client.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _productService;

        

        // GET: Product
        public async  Task<ActionResult> Index()
        {
            this._productService = new ProductService();
            var products = await this._productService.GetProducts(x => new { x.Id, x.Name, x.Price });
            return View("Products",products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            this._productService = new ProductService();
            var product = await this._productService.GetProduct(id,x => new { x.Id, x.Name, x.Price,x.ShelfLife, x.UnitsInStock });
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
