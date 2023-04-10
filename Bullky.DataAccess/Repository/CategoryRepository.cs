using Bullky.DataAccess.Data;
using Bullky.DataAccess.Repository.IRepository;
using Bullky.Models;
namespace Bullky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        //Here we need to add db ocntect because we need provide repository
        //a db context by using DI we provide db contect and by using base
        //we can provide to it all base classes
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
