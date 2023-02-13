using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName + ' ' + Patronymic;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Position> Positions { get; set; }

        public Employee()
        {
            Positions = new List<Position>();
        }
    }
}
