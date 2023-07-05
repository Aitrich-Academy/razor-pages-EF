using JobPortalApplication.Models;

namespace JobPortalApplication.Interfaces
{
	public interface IApplicationService
	{
		void AddApplication(Guid JobId, Guid UserId);
        public List<Application> GetAll(Guid userId);

    }
}
