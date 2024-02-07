using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls;
using API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Linq;

namespace GeneralDepartmentEmployeeTerminal.ViewModels
{
    public class AuthWindowViewModel : ViewModelBase
    {
        private AuthWindow Owner { get; set; }
        public string? EnteredCode { get; set; }
        public AuthWindowViewModel(AuthWindow owner)
        {
            Owner = owner;
        }
        public async void Enter()
        {
            //Получение доступа
            HttpClient client = new()
            {
                BaseAddress = new Uri("http://localhost:5242")
            };
            var response = await client.GetAsync($"/auth/{EnteredCode}");

            //Получение данных 
            List<Application> Visitors = new();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response2 = await client.GetAsync($"/applications");
                
                if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Visitors = response2.Content.ReadFromJsonAsync<List<Application>>().Result.ToList();
                    List<Application> Visitors2 = new();
                    foreach(var visitor in Visitors)
                    {
                        if(visitor.Group.Visitors.First().Blocked != true)
                        {
                            Visitors2.Add(visitor);
                        }
                    }
                    Visitors = Visitors2;

                }
         
                MainWindow mainWindow = new();
                
                mainWindow.DataContext = new MainWindowViewModel(mainWindow, Visitors, client);
                mainWindow.Show();
                Owner.Close();
            }
            else
            {
                Owner.Close();
            }
        }
      
    }
}