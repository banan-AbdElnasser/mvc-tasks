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
    public class DpartmentRepository : IDepartmentRepository
    {
        private MvcAppG02DbContext _dbContext;
        public DpartmentRepository(MvcAppG02DbContext dbContext)
        {
            _dbContext = dbContext;
        }
       public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList();

        }
        public Department Get(int id)
        {
            return _dbContext.Departments.Find(id);
        }
        public int Add(Department department)
        {
            _dbContext.Add(department);
            return _dbContext.SaveChanges();
        }
        public int Delete(Department department)
        {
           _dbContext.Remove(department);   
            return _dbContext.SaveChanges();
        }

        public Department GetById(int id)
        {
            var department= _dbContext.Departments.Local.Where(D=>D.Id==id).FirstOrDefault();
       return department;
        }

        public int Update(Department department)
        {
            _dbContext.Update(department);
            return _dbContext.SaveChanges();
        }

        public int Updater(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
