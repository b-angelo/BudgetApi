using System.Data.Entity;
using BudgetApi.Repositories.Contracts;
using BudgetApi.Entities;
using System;

namespace BudgetApi.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BudgetApiDbContext db = new BudgetApiDbContext();

        public T GetEntity(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void CreateEntity(T Entity)
        {
            db.Entry(Entity).State = EntityState.Added;
        }

        public void UpdateEntity(T Entity)
        {
            db.Entry(Entity).State = EntityState.Modified;
        }

        void IRepository<T>.Commit()
        {
            db.SaveChanges();
        }
    }
}