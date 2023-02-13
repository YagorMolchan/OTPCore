using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTPCore.DAL.Entities;
using OTPCore.BLL.DTO;
using AutoMapper;

namespace OTPCore.BLL.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(e => e.Positions, opt => opt.MapFrom(src => src.Positions));
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(e => e.Positions, opt => opt.MapFrom(src => src.Positions));

        }
    }
}
