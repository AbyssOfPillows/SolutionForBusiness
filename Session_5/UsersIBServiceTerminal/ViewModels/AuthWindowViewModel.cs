using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersIBServiceTerminal.Models;
using UsersIBServiceTerminal.Views;

namespace UsersIBServiceTerminal.ViewModels
{
    public class AuthWindowViewModel
    {
        public AuthWindowViewModel(AuthWindow Owner)
        {
            this.Owner = Owner;
            db = new Session4Context();
            Types = db.UserTypes.ToList();
        }
        private Session4Context db { get; set; }
        private AuthWindow Owner { get; set; }
        public List<UserType> Types { get; set; }
        public UserType Type { get; set; }
        public string? Login { get; set; } = "YUrin68";
        public string? Password { get; set; } = "hibljzslmv";
        public string? SecretWord { get; set; } = "Спутник";

        public void Auth()
        {
            User user = db.Users.FirstOrDefault(u => u.Login == Login);
            if (user == null)
            {
                return;
            }
            else
            {
                if ((user.UserType.Id == 2) && (user.Password == Password) && user.SecretWord == SecretWord)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = new MainWindowViewModel(mainWindow, db, user);
                    mainWindow.Show();
                    Owner.Close();
                }
            }
        }
    }
}
