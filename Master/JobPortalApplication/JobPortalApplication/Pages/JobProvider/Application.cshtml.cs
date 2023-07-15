using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class ApplicationModel : PageModel
    {private readonly IUserService userService;
        private readonly IJobService jobService;
        private readonly IApplicationService applicationService;
        private readonly IMapper _mapper;
        public ApplicationModel(IUserService _userService, IMapper mapper, IJobService _jobService, IApplicationService _applicationService)
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
			string CompanyId = HttpContext.Session.GetString("CompanyId");
		
			Guid Companyid = new Guid(CompanyId);

			Applications = applicationService.GetAllApplication(Companyid);
            Applications.ForEach((e) =>
            {
                e.Job = jobService.getJobById(e.JobId.Value);
               
            });

            users = userService.getById(Companyid);
        }
    }
}
