using JobPortalApplication.Interfaces;
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

		public void DeleteItemById(Guid id)
		{
			interviewRepository.removeInterview(id);
		}

		public List<Interview> GetAll(Guid companid)
		{
			return interviewRepository.sheduledInterviewList(companid);
		}

		public Interview GetInterviewById(Guid id)
		{
			return interviewRepository.GetInterviewById(id);
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
