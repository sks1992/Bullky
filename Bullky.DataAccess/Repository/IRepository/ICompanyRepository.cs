

using BullkyBook.Models;
using System.Linq.Expressions;

namespace BullkyBook.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
