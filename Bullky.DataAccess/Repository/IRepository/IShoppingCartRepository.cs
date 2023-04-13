using BullkyBook.Models;

namespace BullkyBook.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository :IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
    }
}
