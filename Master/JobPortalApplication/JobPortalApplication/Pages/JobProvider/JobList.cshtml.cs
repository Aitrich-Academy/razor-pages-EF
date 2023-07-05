using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class JobListModel : PageModel {
		private readonly IUserService userService;
		private readonly IJobService jobService;
		private readonly IMapper _mapper;

        public JobListModel(IUserService userService, IMapper mapper, IJobService _jobService)
        {
			userService = userService;
			_mapper = mapper;
			jobService = _jobService;
		}
        [BindProperty]

		public List<Job> jobs { get; set; } = new List<Job>();
		public void OnGet()
		{

			var userId = HttpContext.Session.GetInt32("UserId");
			TempData["UserId"] = userId;
			jobs = jobService.GetJobs();

		}
		
			public IActionResult OnPostRemoveJob(Guid id)
			{
			//jobs = jobService.GetJobs();

				////var jobToRemove = jobs.FirstOrDefault(job => job.Id == id);
				////if (jobToRemove != null)
				////{
				jobService.DeleteItemById(id);	
				return Page();
			}
		
    }
}
