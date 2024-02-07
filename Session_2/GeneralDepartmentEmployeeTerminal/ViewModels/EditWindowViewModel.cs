using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Application = API.Models.Application;

namespace GeneralDepartmentEmployeeTerminal.ViewModels
{
    internal class EditWindowViewModel : ViewModelBase
    {
        public EditWindowViewModel(Application visitor, EditWindow owner, HttpClient HttpClient)
        {
            Visitor = visitor;
            Owner = owner;
            this.HttpClient = HttpClient;
        }
        HttpClient HttpClient { get; set; }
        private EditWindow Owner { get; set; }
        public Application Visitor { get; set; }
        public bool Approve { get; set; }
        public string DateVisit { get; set; } = Convert.ToString(DateTime.Now);


        public async void Save()
        {
            var response3 = await HttpClient.GetAsync($"/applications/id={Visitor.Id}&datetime={DateVisit}&approve={Approve}");
            {
                Owner.Close();
            }
                
        }
    }
}
