using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Task2.Application.Dtos;
using Task2.Domain.Entities;

namespace Task1.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }

}