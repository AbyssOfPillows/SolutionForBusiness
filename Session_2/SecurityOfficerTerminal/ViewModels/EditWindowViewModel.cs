using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Application = API.Models.Application;
using Log = API.Models.Log;

namespace SecurityOfficerTerminal.ViewModels
{
    public class EditWindowViewModel : ViewModelBase
    {
        public EditWindowViewModel(EditWindow Owner, HttpClient httpClient, Application app) 
        {
            this.Owner = Owner;
            HttpClient = httpClient;
            Application = app;
        }
        private EditWindow Owner { get; set; }
        private HttpClient HttpClient { get; set; }
        public Application Application { get; set; }
        public bool Access { get; set; }
        public string ArrivalTime { get; set; } = DateTime.Now.ToString();
        public string DeaprtureTime { get; set; } = DateTime.Now.ToString();
        public async void Save()
        {
            Log log = new Log();
            log.Application = Application;
            log.Access = Access;
            log.ArrivalTime = DateTime.Parse(ArrivalTime);
            log.DeaprtureTime = DateTime.Parse(DeaprtureTime);
            var response = await HttpClient.GetAsync($"/logs/api={Application.Id}&arrival_time={ArrivalTime}&deaprture_time={DeaprtureTime}&access={Access}");
            if(response.IsSuccessStatusCode == true)
            {
                Owner.Close();
            }
            
        }
    }
}
