using SecurityOfficerTerminal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Application = API.Models.Application;


namespace SecurityOfficerTerminal.ViewModels
{
    public class AuthWindowViewModel : ViewModelBase
    {
        public AuthWindowViewModel(AuthWindow Owner) 
        {
            this.Owner = Owner;
        }
        private AuthWindow Owner { get; set; }
        public string? EmployeeCode { get; set; } 
        public async void Auth()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5242");
            var response = await client.GetAsync($"/auth/{EmployeeCode}&2");
            if(response.IsSuccessStatusCode == true )
            {
                var response2 = await client.GetAsync($"/applications");
                List<Application> applications = new List<Application>();
                if (response2.IsSuccessStatusCode == true )
                {
                    applications = response2.Content.ReadFromJsonAsync<List<Application>>().Result.ToList();
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = new MainWindowViewModel(mainWindow, client, applications);
                mainWindow.Show();
                
            }
            Owner.Close();
        }
    }
}
