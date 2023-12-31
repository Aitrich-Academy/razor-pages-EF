﻿using AutoMapper;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Entities;

namespace HireMeNowWebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, User>().ReverseMap();
			CreateMap<InterviewDto, Interview>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<JobDto,Job>().ReverseMap();
		}
	}
}
