using JobPortalApplication.Models;

namespace JobPortalApplication.Interfaces
{
	public interface IInterviewRepository
	{
		Interview shduleInterview(Interview interview);
		List<Interview> sheduledInterviewList();
		void removeInterview(Guid id);
		
	}
}
