using BullkyBook.DataAccess.Data;
using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;
namespace BullkyBook.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        //Here we need to add db ocntect because we need provide repository
        //a db context by using DI we provide db contect and by using base
        //we can provide to it all base classes
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
       

        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
