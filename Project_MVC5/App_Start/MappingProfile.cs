using AutoMapper;
using Project_MVC5.DTO;
using Project_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_MVC5.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ReverseMap();
            Mapper.CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}