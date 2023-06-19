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
using System.Threading.Tasks;
using Api_Work;
using System.Collections.Generic;

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
        private static string text_1;
        private static string text_2;
        private static string text_3;
        private static string text_4;
        private bool flag = false;
        private WindowState Window_State = new WindowState();

        public bool isWorking = true;

        public int width_window { get; set; } = 1500;
        public int WidthWindow
        {
            get
            {
                return width_window;
            }
            set
            {
                width_window = value;
                OnPropertyChenged();
            }
        }

        public int height_window { get; set; } = 850;
        public int HeightWindow
        {
            get
            {
                return height_window;
            }
            set
            {
                height_window = value;
                OnPropertyChenged();
            }
        }


        private async Task Tochki()
        {
            
            while (isWorking)
            {
                if (WidthWindow <= 915 && WidthWindow != 450) 
                {
                    WidthWindow = 450;
                }
                else if (HeightWindow <= 500 && HeightWindow != 300)
                {
                    HeightWindow = 300;
                }
                CityName = SonClounds.Properties.Settings.Default.CurrentCity;
                await Task.Delay(50);
               
            }
        }

        

        public async void start_Scale()
        {
            await Tochki();
        }

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
                timeFirst = value;
                OnPropertyChenged();
            }
        }

        public string Time2 //Второе время
        {
            get { return timeSecond; }
            set
            {
                timeSecond = value;
                OnPropertyChenged();
            }
        }

        public string Time3 //Третье время
        {
            get { return timeThird; }
            set
            {
                timeThird = value;
                OnPropertyChenged();
            }
        }

        public string Text1 //Первый текст
        {
            get { return text_1; }
            set
            {
                text_1 = value;
                OnPropertyChenged();
            }
        }

        public string Text2 //Второй текст
        {
            get { return text_2; }
            set
            {
                text_2 = value;
                OnPropertyChenged();
            }
        }

        public string Text3 //Третий текст
        {
            get { return text_3; }
            set
            {
                text_3 = value;
                OnPropertyChenged();
            }
        }

        public string Text4 //Четвертый текст
        {
            get { return text_4; }
            set
            {
                text_4 = value;
                OnPropertyChenged();
            }
        }
        private bool Tracking_time = true;



        public MainViewModel()
        {
            Time_Track();
            ToSettings = new BindableCommand(_ => to_settings());
            ToWeather = new BindableCommand(_ => to_weather());
            CloseCommand = new BindableCommand(_ => CloseWindow());
            AllScreenCommand = new BindableCommand(_ => OpenWideWindow());
            LessCommand = new BindableCommand(_ => OpenLessWindow());
            ScaleWindow = new BindableCommand(_ => start_Scale());
            start_Scale();
            CityName = SonClounds.Properties.Settings.Default.CurrentCity;
            For_Left_Panel();
        }

        public ICommand ToSettings { get; }
        public ICommand ToWeather { get; }
        

        public BindableCommand ScaleWindow { get; }
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
        private async Task time()
        {
            while (Tracking_time)
            {
                int hour_now = DateTime.Now.Hour;
                if (hour_now >= 0 && hour_now < 4)
                {
                    App.Theme = "NightTheme";
                }
                else if (hour_now >= 4 && hour_now < 12)
                {
                    App.Theme = "MorningTheme";
                }
                else if (hour_now >= 12 && hour_now < 17)
                {
                    App.Theme = "DayTheme";
                }
                else if (hour_now >= 17 && hour_now != 0)
                {
                    App.Theme = "MorningTheme";
                }
                await Task.Delay(600000);
            }
        }
        private async void Time_Track()
        {
            await time();
        }

        private void For_Left_Panel()
        {
            List<NiceList> listik = Working.Left_Panel(SonClounds.Properties.Settings.Default.CurrentCity);
            //text_1 = listik[0].desc;
            text_2 = listik[0].desc;
            text_3 = listik[1].desc;
            text_4 = listik[2].desc;
            timeFirst = listik[0].time.Hour.ToString() + ":00";
            timeSecond = listik[1].time.Hour.ToString() + ":00";
            timeThird = listik[2].time.Hour.ToString() + ":00";
            for (int i = 0; i < 3; i++)
            {
                switch(listik[i].desc)
                {
                    case "облачно с прояснениями":
                        switch(i)
                        {
                            case 0:
                                put2 = "/Resources/Picture/Cloudy.png";
                                break;
                            case 1:
                                put3 = "/Resources/Picture/Cloudy.png";
                                break;
                            case 2:
                                put4 = "/Resources/Picture/Cloudy.png";
                                break;
                        }
                        break;

                    case "пасмурно": //доделать
                        switch(i)
                        {
                            case 0:
                                put2 = "/Resources/Picture/Cloudy.png";
                                break;
                            case 1:
                                put3 = "/Resources/Picture/Cloudy.png";
                                break;
                            case 2:
                                put4 = "/Resources/Picture/Cloudy.png";
                                break;
                        }
                        break;

                }
            }
        }





    }
}
