using pr7.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SonClounds.ViewModel
{
    internal class StartWindowViewModel:BindingHelper
    {

        #region Commands
        public BindableCommand CloseCommand { get; set; }
        public BindableCommand LessCommand { get; set; }
        public BindableCommand AllScreenCommand { get; set; }
        public BindableCommand TextStartedChangingCommand { get; set; }
        public BindableCommand ClearAllTextCommand { get; set; }
        public BindableCommand NowWeatherCommand { get; set; }
        #endregion
        #region Svoystava
        private WindowState Window_State = new WindowState();
        private bool flag = false;
        public WindowState W_S
        {
            get { return Window_State; }
            set
            {
                Window_State = value;
                OnPropertyChenged();
            }
        }
        private string city { get; set; }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChenged();
            }
        }
        private Visibility visibility { get; set; }
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChenged();
            }
        }
        
        #endregion
        public StartWindowViewModel() 
        {
            Visibility = Visibility.Hidden;
            City = "Ваш город";
            CloseCommand= new BindableCommand(_ => CloseWindow());
            AllScreenCommand = new BindableCommand(_ => OpenWideWindow());
            LessCommand = new BindableCommand(_ => OpenLessWindow());
            TextStartedChangingCommand = new BindableCommand(_ => TextChanging());
            ClearAllTextCommand = new BindableCommand(_ => ClearText());
            NowWeatherCommand = new BindableCommand(_ => NowWeather());

        }

        public void TextChanging()
        {
            Visibility = Visibility.Visible;
        }
        public void ClearText() 
        {
            City = "";
        }
        public void NowWeather()
        {
            //переход на второе окно с погодой, возможно, передача каких-то параметров
            MessageBox.Show("ghghgh");
        }
        public void CloseWindow()
        {
            Application.Current.Shutdown();
        }
        public void OpenWideWindow()
        {
            W_S = WindowState.Maximized;
            flag = false;
        }
        public void OpenLessWindow()
        {
            if(!flag)
            {
                W_S = WindowState.Normal;
                flag = true;
            }
            else
            {
                W_S = WindowState.Minimized;
            }
        }
    }
}
