using AutoMapper;
using JobPortalApplication.Dtos;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobProvider
{
    public class ConfirmDeleteModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public ConfirmDeleteModel(IUserService userService, ICompanyService companyService, IMapper mapper)
        {
            _userService = userService;
            _companyService = companyService;
            _mapper = mapper;
        }
        [BindProperty]
       public  UserDto member { get; set; }
        public Guid companyId = new Guid("d1b10b2d-13c8-4aff-bb4a-e7b1d779c497");
        [BindProperty(SupportsGet = true)]
        public string userId { get; set; }
        //PublicService publicService = new PublicService();
        public void OnGet(string id)
        {
            userId= id;
            //users=publicService.getCompanyMembers();
            if (id != null)
            {
                var member1 = _userService.getById(Guid.Parse(id));
                member = _mapper.Map<UserDto>(member1);
            }
            //var companyMembers = _userService.memberListing(companyId);
            //string id4 = Request.Form["parameter"];



        }

     
            public IActionResult OnPostButtonClick()
        {
            _companyService.memberDeleteById(new Guid(userId));
            return  RedirectToPage("/jobprovider/listcompanymembers");
        }
       
    }
}
