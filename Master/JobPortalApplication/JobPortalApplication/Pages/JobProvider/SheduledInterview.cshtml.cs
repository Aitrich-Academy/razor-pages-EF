using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobPortalApplication.Pages.JobProvider
{
    public class SheduledInterviewModel : PageModel
    {
		private readonly IInterviewServices _interviewService;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public SheduledInterviewModel(IInterviewServices interviewService, IMapper mapper, IUserService userService)
		{

			_interviewService = interviewService;
			_mapper = mapper;
			_userService = userService;
		}
		[BindProperty]
		public List<Interview> Interviews { get; set; }
		public void OnGet()

		{
			String companyId = HttpContext.Session.GetString("CompanyId");

			Guid companid = new Guid(companyId);
			//var interview = _interviewService.GetAll(companid);
			var interview = _interviewService.GetAll(companid);

			Interviews = _mapper.Map<List<Interview>>(interview);
			////var userId = HttpContext.Session.GetInt32("UserId");
			////TempData["UserId"] = userId;
			
		}
    }
}
