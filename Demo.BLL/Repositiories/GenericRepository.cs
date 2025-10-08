using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositiories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MvcAppG02DbContext _dbContext;
        public GenericRepository(MvcAppG02DbContext dbContext)
        {
            _dbContext = dbContext;
        }
       public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();

        }
        public Employee Get(int id)
        {
            return _dbContext.Employees.Find(id);
        }
        public int Add(T item)
        {
            _dbContext.Add(item);
            return _dbContext.SaveChanges();
        }
        public int Delete(T item)
        {
           _dbContext.Remove(item);   
            return _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
             return _dbContext.Set<T>().Find();
        }

        public int Update(T item)
        {
            _dbContext.Update(item);
            return _dbContext.SaveChanges();
        }

    }
}
