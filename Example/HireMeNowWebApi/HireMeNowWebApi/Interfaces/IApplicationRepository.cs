﻿using HireMeNowWebApi.Entities;

namespace HireMeNowWebApi.Interfaces
{
	public interface IApplicationRepository
	{
		public List<Application> GetAll(Guid userId);
		public void AddApplication(User user, Job job);
	}
}
