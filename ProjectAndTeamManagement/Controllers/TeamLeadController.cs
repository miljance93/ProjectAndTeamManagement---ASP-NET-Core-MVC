using Microsoft.AspNetCore.Mvc;

namespace ProjectAndTeamManagement.Controllers
{
    public class TeamLeadController : Controller
    {
        public IActionResult AssignmentRequests()
        {
            return View();
        }

        public IActionResult CurrentAssignment()
        {
            return View();
        }

        
    }
}
