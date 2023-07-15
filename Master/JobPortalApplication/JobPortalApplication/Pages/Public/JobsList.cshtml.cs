
using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireMeNow_JobSeekerApp.Pages.Public
{
    public class JobsListModel : PageModel
    {
        private readonly IUserService userService;
        private readonly IJobService jobService;
        private readonly IApplicationService applicationService;
        private readonly IMapper _mapper;

        public JobsListModel(IUserService userService, IMapper mapper, IJobService _jobService, IApplicationService _applicationService)
        {
            userService = userService;
            _mapper = mapper;
            jobService = _jobService;
            applicationService = _applicationService;
        }

        [BindProperty]
        public List<Job> jobs { get; set; } = new List<Job>();
        public ApplicationDto input { get; set; }
        public string userId {get;set;}

		public void OnGet()
        {
             userId = HttpContext.Session.GetString("UserId");
            //TempData["UserId"] =userId;
            jobs = jobService.GetJobs();
           

        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    return Page();
        //}

        [ValidateAntiForgeryToken]
        public IActionResult OnPostButtonClick()
        {
            //var Application = _mapper.Map<Application>(input);

			//////Guid userid =new Guid("18467cd4-2b85-4b2e-ab33-c78353d8b36d");
			//string userid = (string)TempData["UserId"];

			////User user = userService.getById(new Guid(userid));
			//TempData.Keep("UserId");
			userId = HttpContext.Session.GetString("UserId");                                                               
			if (Guid.TryParse(Request.Form["parameter"], out Guid jobid))
            {

                applicationService.AddApplication(jobid, (new Guid(userId)));
                return RedirectToPage("/JobSeeker/AppliedJobs");

            }



            return Page();
            

         
        }
    }
}
