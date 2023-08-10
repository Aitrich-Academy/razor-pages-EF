using JobPortalApplication.Enums;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using System.ComponentModel.Design;

namespace JobPortalApplication.Repositories
{
	public class InterviewRepository : IInterviewRepository
	{
		private HireMeNowDbContext _context = new HireMeNowDbContext();

		public void removeInterview(Guid id)
		{
			var interview = _context.Interviews.Find(id);
			if (interview != null)
			{
				_context.Interviews.Remove(interview);
				_context.SaveChanges();
			}
		}

		//List<Interview> interviews = new();
		//List<Interview> { new Interview(new Guid(), "TCS", "Developer", "10/02/2023", "Mumbai", "10.00"), new Interview(new Guid(), "Wipro", "Developer", "11/02/2023", "EKm", "12.00"), new Interview(new Guid(), "anglo", "Accountant", "24/02/2023", "Tcr", "12.00") };
		public Interview shduleInterview(Interview interview)
		{
			//app.User= user;
			//app.Job = job;
			//////interviews.JobId = interview.JobId;
			interview.Status = "A";
			
		
			_context.Interviews.Add(interview);
			_context.SaveChanges();


			return interview;
		}

		public List<Interview> sheduledInterviewList()
		{
		
			var List =	_context.Interviews.ToList();
			return List;
		}

		public List<Interview> sheduledInterviewList(Guid companid)
		{
			//return _context.Interviews.Where(e => e.CompanyId == companid).Include(a => a.)
			//	.Include(a => a.Company)
			//	.Include(a => a.Job).ToList();

			var list = _context.Interviews.Where(e => e.CompanyId == companid).ToList();
			
			return list;
		}
		//public List<Interview> sheduledInterviewList()
		//{
		//	//List<Interview> listofinterviews = interviews.ToList()
		//	//return listofinterviews;
		//	return interview;
		//}
		//public void removeInterview(Guid id)
		//{
		//	Interview interview = interviews.FirstOrDefault(e => e.Id == id);
		//	if(interview!=null)
		//	{
		//		interviews.Remove(interview);
		//	}

		//}
		public Interview GetInterviewById(Guid id)
		{ 
			return _context.Interviews.FirstOrDefault(a => a.Id == id);

		}
	}
}
