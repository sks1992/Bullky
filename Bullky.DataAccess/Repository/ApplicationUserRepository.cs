using BullkyBook.DataAccess.Data;
using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;

namespace BullkyBook.DataAccess.Repository
{
    public class ApplicationUserRepository :Repository<ApplicationUser>,IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }
    }
}

