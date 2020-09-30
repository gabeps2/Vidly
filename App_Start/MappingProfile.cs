using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rental, NewRentalsDto>();


            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MoviesDto, Movies>();
            Mapper.CreateMap<NewRentalsDto, Rental>();


            // Mapper.CreateMap<Customer, CustomerDto>().ForMember(m => m.id, opt => opt.Ignore());
            // Mapper.CreateMap<Movies, MoviesDto>().ForMember(m => m.id, opt => opt.Ignore());

        }
    }
}