using Inforvet.Areas.Identity.Data;
using Inforvet.Models;
using MediESTeca.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Inforvet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly UserManager<InforvetUser> userManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager/*, UserManager<InforvetUser> userManager*/)
        {
            _logger = logger;
            this.roleManager = roleManager;
            //this.userManager = userManager;
            SeedData.Seed(roleManager).Wait();
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}