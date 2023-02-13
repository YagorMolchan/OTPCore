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
    public class PositionProfile:Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDTO>()
                .ForMember(p => p.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(p => p.Grade, opt => opt.MapFrom(src => src.Grade));
            CreateMap<PositionDTO, Position>()
                .ForMember(p => p.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(p => p.Grade, opt => opt.MapFrom(src => src.Grade));
            //CreateMap<Position, PositionDTO>()
            //    .ForMember(p => p.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(p => p.Name, opt => opt.MapFrom(src => src.Grade))
            //    .ForMember(p => p.Grade, opt => opt.MapFrom(src => src.Grade));


            //CreateMap<PositionDTO, Position>();

            //CreateMap<EmployeePosition, PositionDTO>()
            //    .ForMember(p => p.Id, opt => opt.MapFrom(src => src.PositionId))
            //    .ForMember(p => p.Name, opt => opt.MapFrom(src => src.Position.Name))
            //    .ForMember(p => p.Grade, opt => opt.MapFrom(src => src.Position.Grade));

            //CreateMap<PositionDTO, EmployeePosition>()
            //    .ForMember(e => e.PositionId, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(e => e.Position.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(e => e.Position.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(e => e.Position.Grade, opt => opt.MapFrom(src => src.Grade));

        }
    }
}
