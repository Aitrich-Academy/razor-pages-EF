
using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HireMeNow_JobSeekerApp.Pages.JobProvider
{
    public class AddCompanyMemberModel : PageModel
    {

        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public AddCompanyMemberModel(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [BindProperty]
		public UserDto Input { get; set; }
        public Guid UserId;
		public void OnGet()
        {
        }
        public void OnPost() {
            //Input.Role=Enums.Roles.CompanyMember;
            //Input.companyId=1;
            //publicService.Register(Input);
            var user = _mapper.Map<User>(Input);
            _companyService.memberRegister(user);
            RedirectToPage("jobprovider/listCompanyMembers");
        }
    }
}
