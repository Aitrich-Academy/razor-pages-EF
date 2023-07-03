
using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireMeNow_JobSeekerApp.Pages.Public
{
    public class JobsListModel : PageModel
    {
		private readonly IUserService userService;
        private readonly IJobService jobService;
		private readonly IMapper _mapper;

		public JobsListModel(IUserService userService, IMapper mapper,IJobService _jobService)
		{
			userService = userService;
			_mapper = mapper;
            jobService = _jobService;
		}

		[BindProperty]
        public List<Job> jobs { get; set; } = new List<Job>();
       

        public void OnGet()
        {
           var userId= HttpContext.Session.GetInt32("UserId");
            TempData["UserId"] =userId;
           jobs= jobService.GetJobs();
           

        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    return Page();
        //}

        [ValidateAntiForgeryToken]
        public IActionResult OnPostButtonClick()
        {
          
            var userid = TempData["UserId"];
            //User user = userService.getById(Guid.new(userid));
            //TempData.Keep("UserId");

            if (int.TryParse(Request.Form["parameter"], out int jobid))
            {

                //jobService.ApplyJob(jobid);
                return RedirectToPage("/JobSeeker/AppliedJobs");

            }



            return Page();
            

         
        }
    }
}
