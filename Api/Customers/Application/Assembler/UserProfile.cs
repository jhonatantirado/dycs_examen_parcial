using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Users;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<SignUpDto, User>()
                .ForMember(
                    dest => dest.Username,
                    x => x.MapFrom(src => src.Username)
                )
                .ForMember(dest => dest.Password,
                x => x.MapFrom(src => src.Password))
                ;
        }
    }
}
