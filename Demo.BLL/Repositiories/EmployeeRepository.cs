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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private MvcAppG02DbContext _dbContext;
        public EmployeeRepository(MvcAppG02DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetEmployeesByAdrees(string adrees)
        {
            return _dbContext.Employees.Where(e => e.Address == adrees);
        }
        //public int Add(Employee item)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Delete(Employee item)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Employee GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Update(Employee item)
        //{
        //    throw new NotImplementedException();
        //}

    }
}