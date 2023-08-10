using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
	public class InterviewModel : PageModel
	{
		private readonly IInterviewServices _interviewService;
		private readonly IMapper _mapper;
		private readonly IApplicationService _applicationService;
		private IJobService jobService;
		public InterviewModel(IInterviewServices interviewService, IMapper mapper, IApplicationService applicationService, IJobService _jobService)
		{
			_interviewService = interviewService;
			_applicationService = applicationService;
			_mapper = mapper;
			jobService = _jobService;
		}
		[BindProperty]
		public InterviewDto Input { get; set; }
		public string ReturnUrl { get; set; }
		public Interview interview { get; set; } = new();
		public IActionResult OnGet(Guid id)
		{
			interview = _interviewService.GetInterviewById(id);

			interview.Job = jobService.getJobById(interview.JobId.Value);
			if (interview == null)
			{
				return NotFound();
			}

			return Page();


		}

		public IActionResult OnPostRemoveJob(Guid id)
		{
			
			_interviewService.DeleteItemById(id);
			return Page();
		}
	}
	}
