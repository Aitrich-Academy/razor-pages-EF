
using JobPortalApplication.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobPortalApplication.Pages.JobSeeker
{
    public class ProfileModel : PageModel
    {
        PublicService publicService= new PublicService();
        [BindProperty]
        public User loggedUser { get;set;}
        [BindProperty]
        public string skill { get; set; } = null;
        [BindProperty]
        public string AboutMe { get; set; } = null;
        [BindProperty]
        public Experience Experience { get; set; } = new Experience();
        [BindProperty]
        public Education Education { get; set; } = new Education();
        int? uid;
        public IActionResult OnGet()
        {
            //string userId = HttpContext.Session.GetString("userId");

            //if (string.IsNullOrEmpty(userId))
            //{
            //    // Redirect to another page if userId is not present in session
            //    return RedirectToPage("/Public/login");
            //}
            uid = HttpContext.Session.GetInt32("UserId");
            if(uid != null)
            {
                loggedUser = publicService.GetUserById((int)uid);
            }
            else
            {
                return RedirectToPage("/Public/login");
            }
            return Page();
        }
     
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            loggedUser.Id=HttpContext.Session.GetInt32("UserId").Value;
            User updatedUser= publicService.GetUserById(loggedUser.Id);
            updatedUser.About = loggedUser.About??updatedUser.About;
            if (skill!=null)
            {
                updatedUser.Skills.Add(skill);
                skill=null;
            }
            if(Education.Course!=null)
            {
                updatedUser.Education.Add(Education);
                Education=new Education();
            }
            if (Experience.JobTitle!=null)
            {
                updatedUser.Experiences.Add(Experience);
                Experience=new Experience();
            }
            loggedUser = publicService.UpdateUserProfile(updatedUser);
          
            Education=new Education();
            Experience=new Experience();
            skill=null;
            ModelState.Clear();
            return Page();
        }

    }
}
