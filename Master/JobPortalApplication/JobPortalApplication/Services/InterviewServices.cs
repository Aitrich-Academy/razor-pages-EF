﻿using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Repositories;

namespace JobPortalApplication.Services
{
	public class InterviewServices : IInterviewServices
	{
		public IInterviewRepository interviewRepository;

		public InterviewServices(IInterviewRepository interviewRepository)
		{
			this.interviewRepository = interviewRepository;
		}

		public void removeInterview(Guid id)
		{
			interviewRepository.removeInterview(id);
		}

		public List<Interview> sheduledInterviewList()
		{
			return interviewRepository.sheduledInterviewList();
		}

		public Interview sheduleinterview(Interview interview)
		{
			return interviewRepository.shduleInterview(interview);
		}
	
	}
}
