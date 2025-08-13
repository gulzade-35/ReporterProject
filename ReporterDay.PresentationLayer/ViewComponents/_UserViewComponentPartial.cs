using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReporterDay.EntityLayer.Entities;

namespace ReporterDay.PresentationLayer.ViewComponents
{
    public class _UserViewComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UserViewComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new UserViewModel
            {
                FullName = user != null ? user.Name + " " + user.Surname : "Misafir",
                ImageUrl = user?.ImageUrl ?? "/sneat-1.0.0/assets/img/avatars/profile-img.jpeg"
            };
            return View(model);
        }

        public class UserViewModel
        {
            public string FullName { get; set; }
            public string ImageUrl { get; set; }
        }
    }
}
