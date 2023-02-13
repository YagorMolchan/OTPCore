using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.DAL.Entities
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Grade { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Position()
        {
            Employees = new List<Employee>();
        }

    }
}
