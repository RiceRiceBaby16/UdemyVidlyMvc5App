using AutoMapper;
using CourseByMosh.Dtos;
using CourseByMosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseByMosh.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}