using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
	public class PostJobModel : PageModel
	{
		private readonly IJobService jobService;
		private readonly IMapper _mapper;	 

		public PostJobModel(IMapper mapper, IJobService _jobService)
		{
			jobService = _jobService;
			_mapper = mapper;
		}
		[BindProperty]
		public JobDto Input { get; set; }
		public string ReturnUrl { get; set; }
		public object companyId { get; set; }
		public void OnGet(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			 companyId = TempData["CompanyId"];
			TempData.Keep();
		}
		public async Task<IActionResult> OnPost(string returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Content("Public/JobList");
			companyId = TempData["CompanyId"];
			TempData.Keep();
			if (ModelState.IsValid)
			{
				//var CompanyId = HttpContext.Session.GetInt32("UserId");
				Input.CompanyId = new Guid(companyId.ToString());
				var res = jobService.PostJob(_mapper.Map<Job>(Input));
			

				if (res != null)
				{
					TempData["SuccessMessage"] = "Job posted successfully.";

					return RedirectToAction(returnUrl);
				}
				else
				{
					ModelState.AddModelError(string.Empty, "JobPost failed..");
					return Page();
				}

			}
			return Page();
		}

		
	}
}