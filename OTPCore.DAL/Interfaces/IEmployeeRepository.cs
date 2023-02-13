using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTPCore.DAL.Entities;

namespace OTPCore.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();

        Employee Get(int id);

        void Create(Employee employee);

        void Update(Employee employee);

        void Delete(Employee employee);
    }
}
