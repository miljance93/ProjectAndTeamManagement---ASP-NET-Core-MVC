using Microsoft.AspNetCore.Mvc;

namespace ProjectTeamManagment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
