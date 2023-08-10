using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Repositories;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class InterviewSheduleModel : PageModel
    {
		private readonly IInterviewServices _interviewService;
		private readonly IMapper _mapper;
			private readonly IApplicationService _applicationService;
		private IJobService jobService;
		public InterviewSheduleModel(IInterviewServices interviewService, IMapper mapper, IApplicationService applicationService, IJobService _jobService)
        {
			_interviewService = interviewService;
				_applicationService  = applicationService;
			_mapper = mapper;
			jobService = _jobService;
		}
		[BindProperty]
		public InterviewDto Input { get; set; } 
		public string ReturnUrl { get; set; }

		//public void OnGet(string returnUrl = null)
		//{
		//	ReturnUrl = returnUrl;

		//}
		public Application Application { get; set; } = new();

		public IActionResult OnGet(Guid id)
		{
			Application = _applicationService.GetApplicationById(id);
			Application.Job= jobService.getJobById(Application.JobId.Value);

			if (Application == null)
			{
				return NotFound();
			}

			return Page();

		}
		[ValidateAntiForgeryToken]
		public IActionResult OnPost(Guid id)
		{

			Application = _applicationService.GetApplicationById(id);
			Input.JobId = Application.JobId.Value;
			Input.JobseekerId = Application.UserId;
			
			var interview = _mapper.Map<Interview>(Input);
			interview.Id = new Guid();
			
			//interview.JobId=Application.JobId.Value;
			_interviewService.sheduleinterview(interview);

			//var returnUrl =  Url.Content("~/jobprovider/SheduledInterView");
			return RedirectToPage("SheduledInterview");

		}
	}
}
