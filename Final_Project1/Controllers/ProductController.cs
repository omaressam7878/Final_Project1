using Final_Project1.Context;
using Final_Project1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Final_Project1.Controllers
{
    public class ProductController : Controller
    {
        CompanyContext db = new CompanyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var _Products = db.Products.Include(pro => pro.Category);
            return View(_Products);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Singlepro = db.Products.Include(cate => cate.Category).FirstOrDefault(pro => pro.ProductId == id);
            if (_Singlepro == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Singlepro);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "CategoryId", "Name", "Description");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var oldProduct = db.Products.Include(cate => cate.Category).FirstOrDefault(pro => pro.CategoryId == id);
            if (oldProduct == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Departments = new SelectList(db.Categories, "CategoryId", "Name", "Description");
            return View(oldProduct);
        }

        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            var oldProduct = db.Products.FirstOrDefault(pro => pro.ProductId == Product.ProductId);
            if (oldProduct == null)
            {
                return RedirectToAction("Index");
            }
            oldProduct.ProductId = Product.ProductId;
            oldProduct.Title = Product.Title;
            oldProduct.Price = Product.Price;
            oldProduct.Description = Product.Description;
            oldProduct.Quantity = Product.Quantity;
            oldProduct.ImagePath = Product.ImagePath;
            oldProduct.CategoryId = Product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var productToDelete = db.Products.Find(id);
            if (productToDelete == null)
            {
                return RedirectToAction("Index");
            }
            db.Products.Remove(productToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
