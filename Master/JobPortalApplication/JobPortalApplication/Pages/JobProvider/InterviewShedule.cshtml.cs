using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class InterviewSheduleModel : PageModel
    {
		private readonly IInterviewServices _interviewService;
		private readonly IMapper _mapper;
        public InterviewSheduleModel(IInterviewServices interviewService, IMapper mapper)
        {
			_interviewService = interviewService;
			_mapper = mapper;
		}
        [BindProperty]
		public Interview Input { get; set; }
		public string ReturnUrl { get; set; }
		
		public void OnGet(string returnUrl = null)
        {
			ReturnUrl = returnUrl;

		}
		public void OnPost()
		{
			
			var interview = _mapper.Map<Interview>(Input);
			_interviewService.sheduleinterview(interview);
			RedirectToPage("jobprovider/SheduledInterView");
		}
	}
}
