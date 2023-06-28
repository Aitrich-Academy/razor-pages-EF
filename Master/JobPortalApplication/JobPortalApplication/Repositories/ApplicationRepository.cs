﻿using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;

namespace JobPortalApplication.Repositories
{
	public class ApplicationRepository: IApplicationRepository
	{

		List<Application> _applications = new List<Application>();
		public List<Application> GetAll(Guid userId)
		{
			return _applications.Where(e => e.User?.Id == userId).ToList();
		}
		public void AddApplication(User user, Job job)
		{
			//_applications.Add(new Application(job, user, "Pending"));
		}
	}
}
