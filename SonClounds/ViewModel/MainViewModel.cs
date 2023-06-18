using SonClounds;
using SonClounds.View;
using SonClounds.ViewModel;
using SonClounds.ViewModel.Helpers;
using System.Diagnostics;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace SunClounds.ViewModel
{

    internal class MainViewModel : BindingHelper
    {
        public SecondViewModel second = new SecondViewModel();
        private static Page Frame_Page = new First();
        private static string city_name;
        private static string put1;
        private static string put2;
        private static string put3;
        private static string put4;
        private static string timeFirst;
        private static string timeSecond;
        private static string timeThird;
        private bool flag = false;
        private WindowState Window_State = new WindowState();



        public Page framePage
        {
            get { return Frame_Page; }
            set
            {
                Frame_Page = value;
                OnPropertyChenged();
            }
        }
        public WindowState W_S
        {
            get { return Window_State; }
            set
            {
                Window_State = value;
                OnPropertyChenged();
            }
        }

        public string CityName //Название города
        {
            get { return city_name; }
            set
            {
                
                city_name = value;
                OnPropertyChenged();

            }
        }

        public string PutFirst //Первая иконка
        {
            get { return put1; }
            set
            {
                put1 = value;
                OnPropertyChenged();
            }
        }

        public string PutSecond //Вторая иконка
        {
            get { return put2; }
            set
            {
                put2 = value;
                OnPropertyChenged();
            }
        }

        public string PutThird //Третья иконка
        {
            get { return put3; }
            set
            {
                put3 = value;
                OnPropertyChenged();
            }
        }

        public string PutFourth //Четвертая иконка
        {
            get { return put4; }
            set
            {
                put4 = value;
                OnPropertyChenged();
            }
        }

        public string Time1 //Первое время 
        {
            get { return timeFirst; }
            set
            {
                put4 = value;
                OnPropertyChenged();
            }
        }

        public string Time2 //Второе время
        {
            get { return timeSecond; }
            set
            {
                put4 = value;
                OnPropertyChenged();
            }
        }

        public string Time3 //Третье время
        {
            get { return timeThird; }
            set
            {
                put4 = value;
                OnPropertyChenged();
            }
        }







        public MainViewModel()
        {
            ToSettings = new BindableCommand(_ => to_settings());
            ToWeather = new BindableCommand(_ => to_weather());
            CloseCommand = new BindableCommand(_ => CloseWindow());
            AllScreenCommand = new BindableCommand(_ => OpenWideWindow());
            LessCommand = new BindableCommand(_ => OpenLessWindow());
            CityName = SonClounds.Properties.Settings.Default.CurrentCity;

        }

        public ICommand ToSettings { get; }
        public ICommand ToWeather { get; }
        public BindableCommand CloseCommand { get; set; }
        public BindableCommand LessCommand { get; set; }
        public BindableCommand AllScreenCommand { get; set; }

        private void to_settings()
        {
            framePage = new Second();
        }


        public void to_weather()
        {
            framePage = new First();
        }
        
        public void default_values() //Метод, который будет ставить дефолтные картинки
        {
            PutFirst = "/Resources/Picture/Sunny.png";
            PutSecond = "/Resources/Picture/Sunny.png";
            PutThird = "/Resources/Picture/Cloudy.png";
            PutFourth = "/Resources/Picture/Rainy.png";
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
            if (!flag)
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
