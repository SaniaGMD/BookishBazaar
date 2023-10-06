using Microsoft.AspNetCore.Mvc;
using myMVCApp.Models;

namespace myMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        // Static list to simulate data storage
        private static List<Category> categories = new List<Category>();

        // GET: Category
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categories.Add(category);
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
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

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null)
                return HttpNotFound();

            existingCategory.Name = category.Name;

            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
                categories.Remove(category);

            return RedirectToAction("Index");
        }
    

}
}
