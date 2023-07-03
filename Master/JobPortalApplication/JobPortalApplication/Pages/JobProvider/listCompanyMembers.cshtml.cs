
using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;

namespace HireMeNow_JobSeekerApp.Pages.JobProvider
{
    public class listCompanyMembersModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public listCompanyMembersModel(IUserService userService,ICompanyService companyService, IMapper mapper)
        {
            _userService = userService;
            _companyService = companyService;
            _mapper = mapper;
        }

        [BindProperty]
        public List<UserDto> users { get; set; } = new();
        public Guid companyId=new Guid("d1b10b2d-13c8-4aff-bb4a-e7b1d779c497");
        //PublicService publicService = new PublicService();
        public void OnGet()
        {
            //users=publicService.getCompanyMembers();
            var companyMembers = _userService.memberListing(companyId);

            users = _mapper.Map<List<UserDto>>(companyMembers);
        }
    }
}
