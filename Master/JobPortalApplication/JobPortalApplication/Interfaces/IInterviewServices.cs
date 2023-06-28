using JobPortalApplication.Models;

namespace JobPortalApplication.Interfaces
{
	public interface IInterviewServices
	{
		Interview sheduleinterview(Interview interview);
		List<Interview> sheduledInterviewList();
		void removeInterview(Guid id);

	}
}
