using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            KeeperBdContext db = new KeeperBdContext();
            List<Employee> employees = db.Employees.ToList();
            return Ok(JsonSerializer.Serialize(employees));
        }
        [HttpGet]
        [Route("{code}")]
        public IActionResult AuthGeneralDepartamentEmployee(int code)
        {
            KeeperBdContext db = new KeeperBdContext();
            Employee employee = db.Employees.FirstOrDefault(e => e.Code == code);
            if(employee == null)
            {
                return BadRequest("Такого сотрудника не существует");
            }
            if(employee.DepartmentId != 6) 
            {
                return BadRequest("Сотрудник не имеет доступа");
            }
            return Ok("Ok");
        }
    }
}
