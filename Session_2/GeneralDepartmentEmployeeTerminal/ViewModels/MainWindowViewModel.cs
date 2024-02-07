using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DynamicData;

namespace GeneralDepartmentEmployeeTerminal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MainWindow Owner { get; set; }
        private HttpClient HttpClient { get; set; }
        private List<Application> Visitors { get; set; }
        public Application Visitor { get; set; }
        public List<Application> StartVisitors { get; }
        public FlatTreeDataGridSource<Application> Source { get; set; }
        public string Departament { get; set; }
        public int Type { get; set; }
        public MainWindowViewModel(MainWindow owner, List<Application> visitors, HttpClient HttpClient)
        {
            Owner = owner;
            Visitors = visitors;
            StartVisitors = Visitors;
            this.HttpClient = HttpClient;
            Create_TreeDataFrid();
        }
        public void Reload()
        {
            var visitors = Visitors;
            Visitors = null;
            Visitors = visitors;
        }
        public void Edit()
        {
            int VisitorIndex = Source.RowSelection.SelectedIndex.LastOrDefault();
            if(VisitorIndex == null) 
            {
                return;
            }
            EditWindow editWindow = new EditWindow();
            Application Visitor = Visitors.First(v => v.Id == (VisitorIndex + 1));
            editWindow.DataContext = new EditWindowViewModel(Visitor, editWindow, HttpClient);
            editWindow.Show();

        }
        public void Filtration()
        {
            List<Application> NewVisitors = new List<Application>(StartVisitors);
            List<Application> t_visitors = new List<Application>();
            foreach (var visitor in NewVisitors)
            {
                if(Departament != " " && visitor.Employee.Department.Name == Departament)
                {
                    t_visitors.Add(visitor);
                }
            }
            NewVisitors.RemoveMany(t_visitors);
            t_visitors = new List<Application>();
            foreach (var visitor in NewVisitors)
            {
                if (Type == 1 && visitor.Group.Visitors.Count == 1)
                    t_visitors.Add(visitor);
            }
            NewVisitors.RemoveMany(t_visitors);
            t_visitors = new List<Application>();
            foreach (var visitor in NewVisitors)
            {
                if (Type == 2 && visitor.Group.Visitors.Count != 1)
                    t_visitors.Add(visitor);
            }
            Source.Items = null;
            Source.Items = NewVisitors;
            
        }
        public void Create_TreeDataFrid()
        {
            Source = new(Visitors)
            {
                Columns =
                    {
                    new TextColumn<Application, int>("Id", a => a.Id),
                    new TextColumn<Application, string>("Цель", a => a.Purpose),
                    new TextColumn<Application, string>("Жел.вр.нач.действ.пропуска", a => Convert.ToString(a.DesiredStartDate)),
                    new TextColumn<Application, string>("Жел.вр.оконч.действ.пропуска", a => Convert.ToString(a.DesiredEndDate)),
                    new TextColumn<Application, string>("Ф-я сотр.", a => a.Employee.Surname),
                    new TextColumn<Application, string>("Им.сотр.", a => a.Employee.Name),
                    new TextColumn<Application, string>("От-л", a => a.Employee.Department.Name),
                    new TextColumn<Application, string>("Гр-а", a => a.Group.Name),
                    new TextColumn<Application, string>("Л-н", a => a.Group.Visitors.FirstOrDefault().Login),
                    new TextColumn<Application, string>("Пароль", a => a.Group.Visitors.FirstOrDefault().Password),
                    new TextColumn<Application, string>("Ф-я", a => a.Group.Visitors.FirstOrDefault().Surname),
                    new TextColumn<Application, string>("И.", a => a.Group.Visitors.FirstOrDefault().Name),
                    new TextColumn<Application, string>("Почта", a => a.Group.Visitors.FirstOrDefault().Mail),
                    new TextColumn<Application, string>("Дата р.", a => a.Group.Visitors.FirstOrDefault().DateOfBirth),
                    new TextColumn<Application, string>("Ном.тел.", a => a.Group.Visitors.FirstOrDefault().NumberPhone),
                    new TextColumn<Application, int>("Ном.пасп.", a => a.Group.Visitors.FirstOrDefault().PasportNumber),
                    new TextColumn<Application, int>("Серия пасп.", a => a.Group.Visitors.FirstOrDefault().PasportSeria),
                    },

            };
        }
    }
}
