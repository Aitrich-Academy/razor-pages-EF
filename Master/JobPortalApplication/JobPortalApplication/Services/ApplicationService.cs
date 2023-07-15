using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Repositories;
using System.ComponentModel.Design;

namespace JobPortalApplication.Services
{
	public class ApplicationService : IApplicationService
	{
		public IUserRepository _userRepository;
		public  IJobRepository _jobRepository;
		public IApplicationRepository _applicationRepository;
        public ApplicationService(IUserRepository userRepository, IJobRepository jobRepository, IApplicationRepository applicationRepository)
        {
			_userRepository = userRepository;
			_jobRepository = jobRepository;
			_applicationRepository = applicationRepository;

		}
        public void AddApplication(Guid JobId, Guid UserId)
		{
			User user=_userRepository.getById(UserId);
			Job job = _jobRepository.GetJobById(JobId);
			
			_applicationRepository.AddApplication(user,job);
		}
        public List<Application> GetAll(Guid userId)
		{
			return _applicationRepository.GetAll(userId);
		}

		public List<Application> GetAllApplication(Guid companyid)
		{
			return _applicationRepository.GetAllApplication(companyid);
		}

		public Application GetApplicationById(Guid id)
		{
			return _applicationRepository.GetAllApplicationById(id);
		}
	}
}
