﻿using System.Linq.Expressions;

namespace BullkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //assume T-> Category class
        //functio to get all the class data mean get All CategoryData
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter =null, string? includeProperties = null);
        //FirstOrDefault(u=>u.Id==id) is = to Expression<Func<T, bool>> filter
        //function to get asingle class data meam get Single Category data
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null,bool tracked =false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
