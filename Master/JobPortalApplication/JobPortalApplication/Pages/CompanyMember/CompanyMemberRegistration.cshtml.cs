using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.CompanyMember
{
    public class CompanyMemberRegistrationModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        [BindProperty]
        public UserDto Input { get; set; }
        public string ReturnUrl { get; set; }


        public void OnGet(string returnUrl=null)
        {
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/companyMember/companyMemberRegistration");

            if (ModelState.IsValid)
            {
                var res = _userService.registerMember(_mapper.Map<User>(Input));
                if (res != null)
                    return LocalRedirect(returnUrl);
                else
                    ModelState.AddModelError(string.Empty, "Registration failed..");

            }

            return Page();
        }
    }
}
