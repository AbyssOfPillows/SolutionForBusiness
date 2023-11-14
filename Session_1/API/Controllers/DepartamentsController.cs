using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("/departaments")]
    public class DepartamentsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            KeeperBdContext db = new KeeperBdContext();
            List<Department> departments = db.Departments.ToList();
            return Ok(JsonSerializer.Serialize(departments));
        }
    }
}
