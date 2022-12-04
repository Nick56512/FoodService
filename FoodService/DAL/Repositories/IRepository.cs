using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        void Update(T entity);
        void SaveChanges();
        T Get(int id);
    }
}
