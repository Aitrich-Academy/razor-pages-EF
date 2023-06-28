using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Models;

namespace JobPortalApplication.Helpers
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
