using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;

namespace JobPortalApplication.Repositories
{
	public class ApplicationRepository: IApplicationRepository
	{
        private HireMeNowDbContext _context = new HireMeNowDbContext();
        List<Application> _applications = new List<Application>();
		
		public List<Application> GetAll(Guid userId)
		{
			return _context.Applications.Where(e =>e.User.Id == userId).ToList();

		}
		public void AddApplication(User user, Job job)
		{
			Application app = new Application();
			//app.User= user;
			//app.Job = job;
			app.UserId = user.Id;
			app.JobId = job.Id;
			app.Status = "Pending";
			_context.Applications.Add(app);
			_context.SaveChanges();
			
		}
	}
}
