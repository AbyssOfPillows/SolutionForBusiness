using AdminTerminal;
using AdminTerminal.Models;
using AdminTerminal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace AdminTerminal.ViewModels
{
    public class AuthWindowViewModel : ViewModelBase
    {
        public AuthWindowViewModel(AuthWindow Owner) 
        {
            this.Owner = Owner;
            db = new Session4Context();
            Types =  db.UserTypes.ToList();
        }
        private Session4Context db { get; set; }
        private AuthWindow Owner { get; set; }
        public List<UserType> Types { get; set; }
        public UserType Type { get; set; }
        public string? Login { get; set; } = "Agripina17";
        public string? Password { get; set; } = "obdxbosmqa";
        public string? SecretWord { get; set; } = "Сова";

        public void Auth()
        {
            User user = db.Users.FirstOrDefault(u => u.Login == Login);
            if (user == null)
            {
                return;
            }
            else
            {
                if((user.UserType.Id == 1) && (user.Password == Password) && user.SecretWord == SecretWord)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = new MainWindowViewModel(mainWindow ,db, user);
                    mainWindow.Show();
                }
            }
        }
    }
}
