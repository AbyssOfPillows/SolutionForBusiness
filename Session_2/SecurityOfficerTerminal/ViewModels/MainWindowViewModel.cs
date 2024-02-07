using Avalonia;
using DynamicData;
using SecurityOfficerTerminal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Application = API.Models.Application;

namespace SecurityOfficerTerminal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(MainWindow Owner, HttpClient client, List<Application> applications) 
        {
            this.Owner = Owner;
            _httpClient = client;
            Visitors = new ObservableCollection<Application>(applications);
            StartVisitors = new ObservableCollection<Application>(applications);
        }
        private HttpClient _httpClient {  get; set; }
        private MainWindow Owner { get; set; }
        public ObservableCollection<Application> Visitors { get; set; }
        public ObservableCollection<Application> StartVisitors { get; set; }
        public string Date {  get; set; }
        public string Type { get;set; }
        public string Departament { get; set; }
        public int ItemIndex { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PasportNumber { get; set; }

        public void Filtration()
        {
            ObservableCollection<Application> ListVisitors = new ObservableCollection<Application>(StartVisitors);
            ObservableCollection<Application> t_applications = new ObservableCollection<Application>();
            foreach (Application app in StartVisitors) 
            {
                if(Date != "" && Convert.ToString(app.DateOfVisit) != Date)
                {
                    t_applications.Add(app);
                }
            }
            ListVisitors.RemoveMany(t_applications);
            t_applications = new ObservableCollection<Application>();
            foreach (Application app in Visitors)
            {
                if (Type == "Individual" && app.Group.Visitors.Count != 1)
                {
                    t_applications.Add(app);
                }
                if (Type == "Group" && app.Group.Visitors.Count == 1)
                {
                    t_applications.Add(app);
                }
            }
            ListVisitors.RemoveMany(t_applications);
            t_applications = new ObservableCollection<Application>();
            foreach (Application app in Visitors)
            {
                if (Departament != "" && app.Employee.Department.Name != Departament)
                {
                    t_applications.Add(app);
                }
            }
            ListVisitors.RemoveMany(t_applications);
            t_applications = new ObservableCollection<Application>();
            Visitors = null;
            Visitors = ListVisitors;
        
        }
        public void Edit()
        {
            Application app = Visitors[ItemIndex];
            EditWindow editWindow = new EditWindow();
            editWindow.DataContext = new EditWindowViewModel(editWindow, _httpClient, app);
            editWindow.Show();
        }
        public void Search()
        {
            ObservableCollection<Application> RList = new ObservableCollection<Application>(StartVisitors);
            ObservableCollection<Application> TList = new ObservableCollection<Application>();
            if (Name != null)
            {
                foreach (var app in RList)
                {
                   if(app.Group.Visitors.First().Name != Name)
                   {
                        TList.Add(app);
                   }
                }
                RList.RemoveMany(TList);
            }
            if (Surname != null)
            {
                foreach (var app in RList)
                {
                    if (app.Group.Visitors.First().Surname != Surname)
                    {
                        TList.Add(app);
                    }
                }
                RList.RemoveMany(TList);
            }
            if (Patronymic != null)
            {
                foreach (var app in RList)
                {
                    if (app.Group.Visitors.First().Patronymic != Patronymic)
                    {
                        TList.Add(app);
                    }
                }
                RList.RemoveMany(TList);
            }
            if (PasportNumber != null)
            {
                foreach (var app in RList)
                {
                    if (app.Group.Visitors.First().PasportNumber != Convert.ToInt32(PasportNumber))
                    {
                        TList.Add(app);
                    }
                }
                RList.RemoveMany(TList);
            }
            Visitors = null;
            Visitors = RList;

        }
        public void Reload()
        {
            var old = Visitors;
            Visitors = null;
            Visitors = old;
        }

    }
}