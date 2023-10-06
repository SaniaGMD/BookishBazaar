using Microsoft.AspNetCore.Mvc;

namespace myMVCApp.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult BookingForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InfoForm(string name, string gender, int age, string[] languages)
        {
            // Process the form data here (e.g., save to database)
            // For this example, we'll just display the data in a view
            ViewBag.Name = name;
            ViewBag.Gender = gender;
            ViewBag.Age = age;
            ViewBag.Languages = languages;

            return View("displayInfo");
        }
    }
}
