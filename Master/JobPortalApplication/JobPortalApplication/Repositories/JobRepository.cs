using JobPortalApplication.Enums;
using JobPortalApplication.Exceptions;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace JobPortalApplication.Repositories
{
    public class JobRepository : IJobRepository
    {
		HireMeNowDbContext _context=new HireMeNowDbContext();
		private List<Job> jobs = new List<Job>();
		//{ new Job("Dotnet Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich",new Guid("62ec44fb-9f30-4f45-8e3d-f3751998af89")),
		//new Job("Java Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		//new Job("Angular Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		//new Job("Dotnet Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		//new Job("Dotnet Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich")};
		//private readonly List<Job> _jobs;
	

		public void DeleteById(Guid id)
		{
			Job item = jobs.FirstOrDefault(i => i.Id == id);
			if (item != null)
			{
				jobs.Remove(item);
			}
		}

		public List<Job> getByTitle(string title)
		{
			//List<Job> job= (List<Job>)jobs.Where(e => e.Title == title);
			//return job;
			return jobs.Where(j => j.Title.ToLower().Contains( title.ToLower())).ToList();


		}

		public Job GetJobById(Guid selectedJobId)
		{
			return jobs.Where(e=>e.Id==selectedJobId).FirstOrDefault();
		}

		public List<Job> GetJobs()
        {
            return _context.Jobs.ToList();
        }

		public List<Job> GetJobsByIds(List<Guid> appliedJobsIds)
		{
			List<Job> Appliedjobs = new List<Job>();
			appliedJobsIds.ForEach(e=> Appliedjobs.Add(GetJobById(e)));
			return Appliedjobs;


		}

		

		public Job PostJob(Job job)
        {
			_context.Jobs.Add(job);
			_context.SaveChanges();


			return job;
		
        }

		public Job Update(Job Updatedjob)
		{
			int indexToUpdate = jobs.FindIndex(item => item.Id == Updatedjob.Id);
			if (indexToUpdate != -1)
			{
				// Modify the properties of the item at the found index
				jobs[indexToUpdate].Title = Updatedjob.Title ?? jobs[indexToUpdate].Title;
				jobs[indexToUpdate].Description = Updatedjob.Description ?? jobs[indexToUpdate].Description;
				jobs[indexToUpdate].Location = Updatedjob.Location ?? jobs[indexToUpdate].Location;
				jobs[indexToUpdate].Salary= Updatedjob.Salary ?? jobs[indexToUpdate].Salary;
				jobs[indexToUpdate].TypeOfWorkPlace = Updatedjob.TypeOfWorkPlace ?? jobs[indexToUpdate].TypeOfWorkPlace;
				//jobs[indexToUpdate].Experience = Updatedjob.Experience ?? jobs[indexToUpdate].Experience;
				//jobs[indexToUpdate].CompanyName = Updatedjob.CompanyName ?? jobs[indexToUpdate].CompanyName;

			}
			else
			{
				throw new NotFoundException("Job Not Found");
			}
			return jobs[indexToUpdate];
		}
	}
}
