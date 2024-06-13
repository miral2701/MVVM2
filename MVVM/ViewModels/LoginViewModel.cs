using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM.Models;
using System.Windows;

namespace MVVM.Views
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private readonly Command loginCommand;
        public ICommand LoginCommand => loginCommand;

        private User user;
        public LoginViewModel()
        {
            user= new User();
            loginCommand = new DelegateCommand(() => LoggedIn(user));
            
          
          
        }

        public string Login
        {
            get
            {
                return user.Login;
            }
            set
            {
                user.Login = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Login)));
            }
        }
        public string Password
        {
            get
            {
                return user.Password;
            }
            set
            {
                user.Password = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Password)));

            }
        }
        private void LoggedIn(object parametr)
        {
            User user1 = parametr as User;
            if(user1.Login=="admin" && user1.Password=="1234") 
            {
                MessageBox.Show("Welcome admin1");
            }
            else
            {
                MessageBox.Show("Wrong password or login");

            }
        }
       
        public User User
        {
            get => user;
        
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
