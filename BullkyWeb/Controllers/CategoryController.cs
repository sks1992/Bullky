using BullkyWeb.Data;
using BullkyWeb.Models;
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
            return View();
        }
    }
}
    