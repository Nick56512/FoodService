using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRpository<T> : IRepository<T> where T : class
    {
        DbContext context;
        DbSet<T> table;
        public GenericRpository(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public void Create(T entity)
        {
            table.Add(entity);
        }
        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}
