﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PropertyEntity;
using PropertyEntity.DTO;

namespace PropertyAPI.Extention
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO,User>();
            CreateMap<Country,CountryDTO>();
            CreateMap<CountryDTO,Country>();
            CreateMap<State,StateDTO>();
            CreateMap<StateDTO, State>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

        }

    }
}
