using JobPortalApplication.Models;

namespace JobPortalApplication.Interfaces
{
	public interface IInterviewRepository
	{
		Interview shduleInterview(Interview interview);
		List<Interview> sheduledInterviewList(Guid companid);
		void removeInterview(Guid id);
	List<Interview> sheduledInterviewList();
		Interview GetInterviewById(Guid id);
	}
}
