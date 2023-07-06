using JobPortalApplication.Models;
using JobPortalApplication.Helpers;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Repositories;
using JobPortalApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace JobPortalApplication.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IInterviewServices, InterviewServices>();
			services.AddScoped<IInterviewRepository, InterviewRepository>();
			services.AddScoped<IJobService, JobService>();
			services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
			services.AddScoped<IApplicationService, ApplicationService>();
			    services.AddScoped<IApplicationRepository, ApplicationRepository>();
		
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<HireMeNowDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<HireMeNowDbContext>();

            return services;
        }
    }
}