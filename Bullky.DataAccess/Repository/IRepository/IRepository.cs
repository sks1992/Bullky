using System.Linq.Expressions;

namespace Bullky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //assume T-> Category class
        //functio to get all the class data mean get All CategoryData
        IEnumerable<T> GetAll();
        //FirstOrDefault(u=>u.Id==id) is = to Expression<Func<T, bool>> filter
        //function to get asingle class data meam get Single Category data
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
