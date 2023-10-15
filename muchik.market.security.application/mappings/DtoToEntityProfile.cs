using AutoMapper;
using muchik.market.security.application.dto;
using muchik.market.security.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muchik.market.security.application.mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<UserDto, User>();
            //CreateMap<CreateUserDto, User>();
        }
    }
}
