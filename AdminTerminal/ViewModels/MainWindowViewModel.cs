
using AdminTerminal.Models;
using AdminTerminal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;

namespace AdminTerminal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel() { }
        public MainWindowViewModel(MainWindow Owner, Session4Context db, User user)
        {
            this.Owner = Owner;
            this.db = db;
            string[] fioArray = user.Fio.Split(" ");
            string f = fioArray[0];
            char i = fioArray[1][0];
            char j = fioArray[2][0];
            FioAdmin = f + " " + i + "." + j + ".";
        }
        private Session4Context db { get; set; }
        private MainWindow Owner { get; set; }
        public string? FioAdmin { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronimyc { get; set; }
        public int? Sex { get; set; }
        public string? Post { get; set; }
        public int Count { get; set; } = 0;
        public void SaveUser()
        {
            if (Surname == null || Name == null || Patronimyc == null || Sex == null || Post == null)
            {
                Count++;
                return;
            }
            if(Count == 2) 
            {
                var start = DateTime.UtcNow;
                var end = start.AddMinutes(5);
                var diff = TimeSpan.FromMinutes(5);
                while((DateTime.UtcNow - start) < diff)
                {

                }
                Count = 0;
                return;
            }
            User user = new User();
            user.Post = db.Posts.FirstOrDefault(p => p.Name == Post);
            user.Fio = Surname + " " + Name + " " + Patronimyc;
            if (Sex == 1)
            {
                user.Sex = "M";
            }
            else user.Sex = "Ж";
            db.Users.Add(user);
            db.SaveChanges();
            Cancel();
        }
        public void Cancel()
        {
            Surname = null;
            Name = null;
            Patronimyc = null;
            Sex = null;
            Post = null;

        }
    }
}