using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.InfraStructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ManagementDbContext context;

        public GenericRepository(ManagementDbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            var newEntity = context.Add(entity);
            return newEntity.Entity;
        }

        public IList<T> All()
        {
            return context.Set<T>().ToList();
        }

        public T? Get(Guid id)
        {
            return context.Find<T>(id);
        }
        public T Update(T entity)
        {
            return context.Update(entity).Entity;
        }
        public void Delete(T entity)
        {
            context.Remove(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
