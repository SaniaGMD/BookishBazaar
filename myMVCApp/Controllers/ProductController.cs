using Microsoft.AspNetCore.Mvc;
using myMVCApp.Models;

namespace myMVCApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Products> products = new List<Products>
            {
                new Products(1, "Product 1", "Description for Product 1", 10.0m, new List<string> { "Self-Help", "Motivation"}),
                new Products(2, "Product 2", "Description for Product 2", 15.0m, new List<string> { "Romance", "Drama" })
               
            };
     

        public ActionResult PIndex()
        {
            var productsList = products;
            return View(productsList);
          
        }

        public ActionResult Create()
        {
            var categories = GetCategories();
            ViewBag.Categories = categories;
            return View();
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Drama" },
                new Category { Id = 2, Name = "Self Help" },
                new Category { Id = 3, Name = "Motivation" },
                new Category { Id = 4, Name = "Crime" },
                new Category { Id = 5, Name = "Romance" },
                new Category { Id = 6, Name = "History" },
                
            };

            return categories;
        }

        [HttpPost]
        public ActionResult Create([Bind("Id,Name,Description,Price,CategoryIds")] Products product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("PIndex");
            }

            return View(product);
        }


        public ActionResult Edit(int id)
        {
            var categories = GetCategories();
            ViewBag.Categories = categories;
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

       
        [HttpPost]
        public ActionResult Edit(Products product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return HttpNotFound();

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.CategoryIds = product.CategoryIds;
         
            return RedirectToAction("PIndex");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

}
}

