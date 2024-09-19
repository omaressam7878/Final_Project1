using Final_Project1.Context;
using Final_Project1.Models;
using Microsoft.AspNetCore.Mvc;



namespace Final_Project1.Controllers
{
    public class CategoryController : Controller
    {

        CompanyContext db = new CompanyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var _Categories = db.Categories;
            return View(_Categories);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Category = db.Categories.Find(id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category Category)
        {
            db.Categories.Add(Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldDepartment = db.Categories.Find(id);
            if (oldDepartment == null)
            {
                return RedirectToAction("Index");
            }
            return View(oldDepartment);
        }

        [HttpPost]
        public IActionResult Edit(Category Category)
        {
            var oldCategory = db.Categories.FirstOrDefault(cate => cate.CategoryId == Category.CategoryId);
            if (oldCategory == null)
            {
                return RedirectToAction("Index");
            }
            oldCategory.Name = Category.Name;
            oldCategory.Description = Category.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cateToDelete = db.Categories.Find(id);
            if (cateToDelete == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(cateToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}