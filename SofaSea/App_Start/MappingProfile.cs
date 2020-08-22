using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SofaSea.Dtos;
using SofaSea.Models;

namespace SofaSea.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.ID, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c=>c.Id, opt=>opt.Ignore());
           
        }
        
    }
}