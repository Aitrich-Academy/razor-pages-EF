using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace JobPortalApplication.Repositories
{
	public class ApplicationRepository: IApplicationRepository
	{
        private HireMeNowDbContext _context = new HireMeNowDbContext();
        List<Application> _applications = new List<Application>();
		
		public List<Application> GetAll(Guid userId)
		{
			return _context.Applications.Where(e =>e.User.Id == userId).Include(a=>a.User)
				.Include(a => a.Company)
				.Include(a => a.Job).ToList();

		}
		public List<Application> GetAllApplication(Guid CompanyId)
		{
			return _context.Applications.Where(e => e.User.CompanyId == CompanyId).Include(a => a.User)
				.Include(a => a.Company)
				.Include(a => a.Job).ToList();

			//var list= _context.Applications.Where(e => e.User.CompanyId == CompanyId).ToList();
			//list.ForEach(x => { x.Job = _context.Jobs.Find(x.JobId); }) ;
			//return list;
		}
		public void AddApplication(User user, Job job)
		{
			Application app = new Application();
			//app.User= user;
			//app.Job = job;
			app.UserId = user.Id;
			app.JobId = job.Id;
			app.CompanyId = job.CompanyId;
			app.Status = "Pending";
				app.AppliedDate=DateTime.Now;
			_context.Applications.Add(app);
			_context.SaveChanges();
			
		}

		public Application GetAllApplicationById(Guid id)
		{
			//var result = from Job in _context.Jobs
			//			 join Application in _context.Applications on Job.Id equals Application.JobId
			//			 select new
			//			 {
			//				 ApplicationId = Application.Id,
			//				 JobTitle = Job.Title
			//			 };
			//var applicationdata=
			//var job = _context.Jobs;
			//var application = _context.Applications;
			//return new Application();
			return _context.Applications.FirstOrDefault(a => a.Id == id);

		}
	}
}
