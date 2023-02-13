using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.BLL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<PositionDTO> Positions { get; set; }
    }
}
