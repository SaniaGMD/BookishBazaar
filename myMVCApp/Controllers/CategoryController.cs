using Microsoft.AspNetCore.Mvc;
using myMVCApp.Models;

namespace myMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Romance", ProductIds = new List<int> { 1, 2, 3 } },
            new Category { Id = 2, Name = "Drama", ProductIds = new List<int> { 4, 5 } }
          
        };

      
        public ActionResult CIndex()
        {
            return View(categories);
        }

       
        public ActionResult CCreate()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult CCreate(Category category)
        {
            categories.Add(category);
            return RedirectToAction("CIndex");
        }

        
        public ActionResult CEdit(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

       
        [HttpPost]
        public ActionResult CEdit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
                return HttpNotFound();

            existingCategory.Name = category.Name;

            return RedirectToAction("CIndex");
        }

        
        public ActionResult CDelete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

 
}
}
