using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Models;
using Microsoft.Office.Interop.Excel;

namespace OrderAPassWeb.Pages
{
    public class GroupsWindowModel : PageModel
    {
        HttpClient client = new HttpClient();
        public void OnGet()
        {

         
        }
        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            string password = Request.Query["password"];
            string email = Request.Query["email"];
            var form = HttpContext.Request.Form;
            //VisitorsController visitorsController = new VisitorsController();
            Visitor visitor = new Visitor();
            visitor.Surname = form["Surname"];
            visitor.Name = form["Name"];
            visitor.Patronymic = form["Patronymic"];
            visitor.NumberPhone = form["NumberPhone"];
            visitor.EMail = form["EMail"];
            visitor.Password = password;
            visitor.DataOfPasport = form["Seria"] + " " + form["Number"];
            visitor.DateOfBirth = form["DateOfBirth"].ToString();
            visitor.Login = form["EMail"];
            string visitorJson = JsonSerializer.Serialize(visitor);
            var response = await client.PostAsJsonAsync("/visitors", visitorJson);
            return Redirect(returnUrl ?? "/Choice");
        }
    }
}
