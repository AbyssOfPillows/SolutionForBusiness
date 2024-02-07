using System.Collections.Generic;
using System.Linq;
using UsersIBServiceTerminal.Models;
using UsersIBServiceTerminal.Views;

namespace UsersIBServiceTerminal.ViewModels
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
            TrueUsersList = db.Users.Where(u => u.Approved == true).ToList();
        }
        public Session4Context db { get; set; }
        public MainWindow Owner { get; set; }
        public string? FioAdmin { get; set; }
        public List<User> TrueUsersList { get; set; }
        public void SaveUser()
        {
            foreach (User u in TrueUsersList)
            {
                if (u.Approved == false)
                {
                    db.Users.Remove(u);
                }

            }
            db.SaveChanges();
        }
        public void ApproveAccess()
        {
            db.SaveChanges();
        }
    }
}