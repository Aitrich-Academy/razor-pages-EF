using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class JobListModel : PageModel { 
	 [BindProperty]
     
		public List<Job> jobs { get; set; }
		public JobService jobService = new JobService();
		
		public void OnGet()
		{ 

			jobs= jobService.GetJobs();

        }
    }
}
