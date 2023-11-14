using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Text.Json;

namespace OrderAPassWeb.Pages
{
    public class IndividualWindowModel : PageModel
    {
        List<Department> departments;
        List<Employee> employees;
        public async void OnGet()
        {

        }
        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
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
            string date = form["DateOfBirth"].ToString();
            string dateTime = DateTime.ParseExact(date, "dd MMMM yyyy", null).ToString();
            visitor.DateOfBirth = dateTime + "года";
            visitor.Login = form["EMail"];
            var response = await client.PostAsJsonAsync("/visitors", visitor);
            return Redirect(returnUrl ?? "/Choice");
        }

    }
}
