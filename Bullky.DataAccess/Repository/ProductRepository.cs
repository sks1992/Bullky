using BullkyBook.DataAccess.Data;
using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;


namespace BullkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        //Here we need to add db ocntect because we need provide repository
        //a db context by using DI we provide db contect and by using base
        //we can provide to it all base classes
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price50 = obj.Price50;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Description = obj.Description;
                objFromDb.Author = obj.Author;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}


