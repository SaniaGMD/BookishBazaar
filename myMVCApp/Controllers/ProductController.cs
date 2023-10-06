using Microsoft.AspNetCore.Mvc;
using myMVCApp.Models;

namespace myMVCApp.Controllers
{
    public class ProductController : Controller
    {
       
       
        // GET: Product
      
        private static List<Products> products = new List<Products>
            {
                new Products(1, "Product 1", "Description for Product 1", 10.0m, new List<int> { 1, 2 }),
                new Products(2, "Product 2", "Description for Product 2", 15.0m, new List<int> { 3, 4 })
                // Add more products as needed
            };
     

        public ActionResult PIndex()
        {
            var productsList = products;

            // Pass the products to the view
            return View(productsList);
          
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return HttpNotFound();

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            return RedirectToAction("Index");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}

