
using Bullky.DataAccess.Data;
using Bullky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        //access db because dependency injection when we add applicationDvContext
        //to progtam.cs we can access it as DI.
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //get catrgory data from db
            List<Category> categoryList = _db.Categories.ToList();
            //send category list to view
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                //Create Custom error
                ModelState.AddModelError("name", "The Display Order cannot exactly Match the name");
            }
            /*if(category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("","test is Invalid value");
            }*/
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                //save the above changes in db
                _db.SaveChanges();
                TempData["success"] ="Category Created SuccessFully";
                //RedirectToAction it will take to index page
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            //find only work with primary keys
            //Category categoryFromDb =_db.Categories.Find(id);
            Category categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category categoryFromDb1 =_db.Categories.Where(u=>u.Id ==id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated SuccessFully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            { return NotFound(); }
            Category categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted SuccessFully";

            return RedirectToAction("Index");
        }
    }
}
