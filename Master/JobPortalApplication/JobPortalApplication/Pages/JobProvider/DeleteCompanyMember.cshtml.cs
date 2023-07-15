using AutoMapper;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class DeleteCompanyMemberModel : PageModel
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public DeleteCompanyMemberModel(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        public void OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            TempData["UserId"] = userId;

        }
        public IActionResult OnPostButtonClick()
        {
            //Input.Role=Enums.Roles.CompanyMember;
            //Input.companyId=1;
            //publicService.Register(Input);
            //_companyService.memberDeleteById(id);
            return RedirectToPage("jobprovider/listCompanyMembers");
        }
    }
}
