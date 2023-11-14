using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/applications")]
    public class ApplicationsController : Controller
    {
        [HttpGet]
        public IActionResult GetVisitors()
        {
            KeeperBdContext db = new KeeperBdContext();
            List<Application> applications = db.Applications.ToList();
            return Ok(applications);
        }
    }
}
