﻿namespace BirthdaySystem.Data
{
    using System.Data.Entity;
    using System.Linq;

    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        protected IBirthdaySystemDbContext context;
        protected IDbSet<T> set;

        public EfRepository(IBirthdaySystemDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T GetById(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public int SaveChanges()
        {
            return this.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            entry.State = state;
        }
    }
}
