using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinalProjectASP.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AppRoles : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AppRoles(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole model)
        {
            if(!roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            } 
            return RedirectToAction("Index");
        }

    }
}
