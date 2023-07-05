
using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireMeNow_JobSeekerApp.Pages.Public
{
    public class AppliedJobsModel : PageModel
    {
		private readonly IUserService userService;
        private readonly IJobService jobService;
        private readonly IApplicationService applicationService;
        private readonly IMapper _mapper;

		public AppliedJobsModel(IUserService _userService, IMapper mapper,IJobService _jobService, IApplicationService _applicationService)
		{
			userService = _userService;
			_mapper = mapper;
            jobService = _jobService;
            applicationService = _applicationService;   
		}

		[BindProperty]
       
        public List<Application> Applications { get; set; } = new List<Application>();
         
        public User users { get; set; }
       

        public void OnGet()
        {
            Guid userid = new Guid("18467CD4-2B85-4B2E-AB33-C78353D8B36D");
         
           Applications= applicationService.GetAll(userid);
            Applications.ForEach((e) =>
            {
                e.Job = jobService.getJobById(e.JobId.Value);
                //e.User = userService.getById(e.UserId.Value);
            });

            users = userService.getById(userid);
        




        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    return Page();
        //}

     
    }
}
