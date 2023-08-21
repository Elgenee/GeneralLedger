using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using GeneralLedger.Core.Repositories;

namespace GeneralLedger.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public void Add(TEntity entity)
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Context.Set<TEntity>().Add(entity);
   
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
         
            Context.Set<TEntity>().AddRange(entities);
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return Context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> FindLocal(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Local.AsQueryable().Where(predicate); 
        }

        public TEntity Get(int id)
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllLocal()
        {
            return Context.Set<TEntity>().Local.ToList();
        }

        //public EntityState GetEntityState<TEntity>(TEntity entity)
        //{
        //    return Context.Entry(entity).State;
        //}

        public void Remove(TEntity entity)
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            //Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }
    }
}
