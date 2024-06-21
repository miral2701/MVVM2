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
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace MVVM.Views
{
    public class ViewModel:INotifyPropertyChanged
    {
        private readonly Command convertCommand;
        public ICommand ConvertCommand => convertCommand;

        private User user;
        public User User => user;

        public ViewModel()
        {
            user=new User();
            user.Fahranheit = 0;
            user.Celsius = 0;
            user.Kelvin = 0;

            convertCommand = new DelegateCommand(
            () => Convert()
            );
          
            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(nameof(Celsius)))
                {
                    convertCommand.RaiseCanExecuteChanged();
                }
                if (e.PropertyName.Equals(nameof(Fahrenheit)))
                {
                    convertCommand.RaiseCanExecuteChanged();
                }
                if (e.PropertyName.Equals(nameof(Kelvin)))
                {
                    convertCommand.RaiseCanExecuteChanged();
                }
            };
        }

        public void Convert()
        {
            if (Celsius != 0)
            {
                Fahrenheit = (Celsius*9/5)+32;
                Kelvin = Celsius+273;
            }
            else if (Fahrenheit != 0)
            {
                Celsius = (Fahrenheit-32)*5/9;
                Kelvin = (Fahrenheit - 32) * 5 / 9 +273;
            }
            else if (Kelvin != 0)
            {
                Celsius = Kelvin-273;
                Fahrenheit = (Kelvin-273)*9/5+32;
            }
            
            
        }
        public int Celsius
        {
            get { return user.Celsius; }
            set { user.Celsius = value; NotifyPropertyChanged(); }
        }

        public int Fahrenheit
        {
            get { return user.Fahranheit; }
            set { user.Fahranheit = value; NotifyPropertyChanged(); }
        }

        public int Kelvin
        {
            get { return user.Kelvin; }
            set { user.Kelvin = value; NotifyPropertyChanged(); }
        }
   
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
