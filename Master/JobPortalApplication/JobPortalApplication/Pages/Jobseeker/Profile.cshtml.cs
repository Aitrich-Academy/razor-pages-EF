using JobPortalApplication.Services;
using JobPortalApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobPortalApplication.Repositories;
using JobPortalApplication.Managers;
using JobPortalApplication.Interfaces;

namespace HireMeNow_JobSeekerApp.Pages.JobSeeker
{
    public class ProfileModel : PageModel
    {
        public IUserRepository userRepository;

        [BindProperty]
        public User loggedUser { get;set;}
        [BindProperty]
        public string skill { get; set; } = null;
        [BindProperty]
        public string AboutMe { get; set; } = null;
        [BindProperty]
        public Experience Experience { get; set; } = new Experience();
        [BindProperty]
        public Qualification Education { get; set; } = new Qualification();
        string? uid;

        public ProfileModel(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public IActionResult OnGet()
        {
            //string userId = HttpContext.Session.GetString("userId");
            
            //if (string.IsNullOrEmpty(userId))
            //{
            //    // Redirect to another page if userId is not present in session
            //    return RedirectToPage("/Public/login");
            //}
            uid =( HttpContext.Session.GetString("UserId"));
            if(uid != null)
            {
                loggedUser = userRepository.getById(new Guid(uid));
            }
            else
            {
                return RedirectToPage("/Public/login");
            }
            return Page();
        }
     
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            loggedUser.Id=Guid.TryParse(HttpContext.Session.GetString("UserId"), out Guid parsedGuid) ? parsedGuid : Guid.Empty;

            ViewData["UserName"]=loggedUser.FirstName;
           
            User updatedUser= userRepository.getById(loggedUser.Id);
            
            updatedUser.About = loggedUser.About??updatedUser.About;

            if (skill != null)
            {
                Skill obj = new();
                obj.Title = skill;
                updatedUser.Skills.Add(obj);
                skill = null;
            }
            if (Education.Title != null)
            {

                updatedUser.Qualifications.Add(Education);
                Education=new Qualification();
            }
            if (Experience.JobTitle!=null)
            {
                updatedUser.Experiences.Add(Experience);
                Experience=new Experience();
            }
            loggedUser = userRepository.updateUserProfile(updatedUser);
          
            Education=new Qualification();
            Experience=new Experience();
            skill=null;
            ModelState.Clear();
            return Page();
        }

    }
}
