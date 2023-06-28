

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
            services.AddSingleton<IUserRepository, UserRepository>();
			services.AddScoped<IInterviewServices, InterviewServices>();
			services.AddSingleton<IInterviewRepository, InterviewRepository>();
			services.AddScoped<IJobService, JobService>();
			services.AddSingleton<IJobRepository, JobRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
			services.AddScoped<IApplicationService, ApplicationService>();
			services.AddSingleton<IApplicationRepository, ApplicationRepository>();
		
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<HireMeNowDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
			services.AddTransient<HireMeNowDbContext>();

			return services;
        }
    }
}