

using BullkyBook.DataAccess.Data;
using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;

namespace BullkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
