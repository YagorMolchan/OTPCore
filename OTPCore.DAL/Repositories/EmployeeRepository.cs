using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTPCore.DAL.EFCore;
using OTPCore.DAL.Interfaces;
using OTPCore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace OTPCore.DAL.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly OTPDbContext _dbContext;

        public EmployeeRepository(OTPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetAll()
        {
            return _dbContext.Employees.Include(e => e.Positions).ToList();
        }

        public Employee Get(int id)
        {
            return _dbContext.Employees.Include(e => e.Positions).FirstOrDefault(p => p.Id == id);
        }

        public void Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            //_dbContext.Entry(employeeOld).State = EntityState.Detached;
            //_dbContext.Attach(employee);
            //_dbContext.Entry(employee).State = EntityState.Modified;
            //_dbContext.Set<Employee>().Attach(employeeNew);
            //_dbContext.Entry(employeeNew).State = EntityState.Modified;
            _dbContext.Employees.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
