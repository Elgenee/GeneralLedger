using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;


namespace GeneralLedger.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllLocal();

        //EntityState GetEntityState<TEntity>(TEntity entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindLocal(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
