using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.CompanyMember
{
    public class MemberListingModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MemberListingModel(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [BindProperty]
        public List<User> memberList { get; set; } = new List<User>();

        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            TempData["UserId"] = userId;
            //memberList = _userService.memberListing();


        }
    }
}
