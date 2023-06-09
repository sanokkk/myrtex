using System;
using AutoMapper;
using myrtex.DAL.DtoS;
using myrtex.Domain.Models;

namespace myrtex.DAL.Profiles
{
    public class EmployeeProfile: Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dst => dst.Id,
                    opt => opt
                        .MapFrom(src => Guid.NewGuid()))
                .ForMember(dst => dst.JobStart,
                    opt => opt
                        .MapFrom(src => DateTime.Now));
        }
        
    }
}