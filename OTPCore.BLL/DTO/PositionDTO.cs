using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPCore.BLL.DTO
{
    public class PositionDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name must be inputted")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The grade must be inputted")]
        [Range(1, 15, ErrorMessage = "The value of Grade must be between 1 and 15")]
        public int Grade { get; set; }
    }
}
