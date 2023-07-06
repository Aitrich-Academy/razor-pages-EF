
using AutoMapper;
using JobPortalApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HireMeNow_JobSeekerApp.Pages.Public
{
    public class LoginModel : PageModel
    {
		private readonly IUserService publicService;
		private readonly IJobService jobService;
		private readonly IMapper _mapper;

		public LoginModel(IUserService userService, IMapper mapper, IJobService _jobService)
		{
			publicService = userService;
			_mapper = mapper;
			jobService = _jobService;
		}

		[BindProperty]
        public InputModel Input { get; set; }

        public string Action { get; set; }
     

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public IActionResult OnGet(string Action = null)
        {

            //if(Action == "logout")
            //{
            //    publicService.Logout();
            //    HttpContext.Session.Clear();
            //    ViewData.Clear();
            //    TempData.Clear();
            //}
            //else
            //{
            //User user = publicService.getLoggedUser();
            //if(user.Email != null)
            //{
            //  return  RedirectToPage("/JobSeeker/Profile");
            //}
            //}
            return Page();
           
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Public/jobslist");

            if (ModelState.IsValid)
            {
                var result = publicService.login(Input.Email, Input.Password);
                if (result!=null)
                {
                    HttpContext.Session.SetString("UserId", result.Id.ToString());
                    ViewData["UserId"]=result.Id;
                    TempData["UserId"] =  result.Id;
					TempData["CompanyId"] = result.CompanyId;
					return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
