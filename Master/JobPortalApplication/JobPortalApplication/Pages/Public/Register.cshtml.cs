
using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HireMeNow_JobSeekerApp.Pages.Public
{
    public class RegisterModel : PageModel
    {
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public RegisterModel(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}


		[BindProperty]
        public UserDto Input { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("User.Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

        //public class InputModel
        //{
        //    [Required]
        //    [EmailAddress]
        //    public string Email { get; set; }

        //    [Required]
        //    public string Password { get; set; }

        //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //    public string ConfirmPassword { get; set; }
        //}
        
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var res= _userService.register(_mapper.Map<User>(Input));
                if(res!=null)
                    return LocalRedirect(returnUrl);
                else
                    ModelState.AddModelError(string.Empty, "Registration failed..");
               
            }

            return Page();
        }
    }
}
