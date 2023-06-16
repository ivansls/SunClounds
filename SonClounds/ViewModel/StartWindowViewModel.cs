using SonClounds.View;
using SonClounds.ViewModel.Helpers;
using SunClounds.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        public ICommand NowWeatherCommand { get; }
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
        private int titlefontsize { get; set; } = 20;
        public int TitleFontSize
        {
            get
            {
                return titlefontsize;
            }
            set
            {
                titlefontsize = value;
                OnPropertyChenged();
            }
        }
        private int basefontsize { get; set; } = 15;
        public int BaseFontSize
        {
            get
            {
                return basefontsize;
            }
            set
            {
                basefontsize = value;
                OnPropertyChenged();
            }
        }
        
        #endregion
        public StartWindowViewModel() 
        {
            Visibility = Visibility.Hidden;
            City = "Ваш город             ";
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
            
            StartWindow st = new StartWindow();
            st.Show();
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.start_Scale();
            MainWindow win = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (win != null)
            {
                win.Close();
            }
        }
        public void CloseWindow()
        {
            Application.Current.Shutdown();
        }
        public void OpenWideWindow()
        {
            W_S = WindowState.Maximized;
            flag = false;
            TitleFontSize = 40;
            BaseFontSize = 30;
        }
        public void OpenLessWindow()
        {
            if(!flag)
            {
                W_S = WindowState.Normal;
                flag = true;
                TitleFontSize = 20;
                BaseFontSize = 15;
            }
            else
            {
                W_S = WindowState.Minimized;
            }
        }
    }
}
