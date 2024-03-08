using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.InfraStructure.Repository
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T? Get(Guid id);
        void Delete(T entity);
        IList<T> All();

        void SaveChanges();
    }
}

