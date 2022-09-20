using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAndTeamManagement.Controllers
{
    [Authorize]
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
