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
using System.Linq;

namespace SunClounds.ViewModel
{

    public class MainViewModel : BindingHelper
    {
        public MainViewModel()
        {
            Time_Track();
            ToSettings = new BindableCommand(_ => to_settings());
            ToWeather = new BindableCommand(_ => to_weather());
            CloseCommand = new BindableCommand(_ => CloseWindow());
            AllScreenCommand = new BindableCommand(_ => OpenWideWindow());
            LessCommand = new BindableCommand(_ => OpenLessWindow());
            ScaleWindow = new BindableCommand(_ => start_Scale());
            Drag = new BindableCommand(_ => drag());
            start_Scale();
            CityName = SonClounds.Properties.Settings.Default.CurrentCity;
            For_Left_Panel();
        }

        //public SecondViewModel second = new SecondViewModel(this);
        private static Page Frame_Page = new First();
        private static string city_name;
        public static string put1;
        private static string put2;
        private static string put3;
        private static string put4;
        private static string timeFirst;
        private static string timeSecond;
        private static string timeThird;
        public static string text_1;
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

        private async Task Scale()
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
            await Scale();
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



        public ICommand Drag { get; }

        public ICommand ToSettings { get; }
        public ICommand ToWeather { get; }
        

        public BindableCommand ScaleWindow { get; }
        public BindableCommand CloseCommand { get; set; }
        public BindableCommand LessCommand { get; set; }
        public BindableCommand AllScreenCommand { get; set; }
        private void to_settings()
        {
            framePage = new Second(this);
            


        }

        private void drag()
        {
            Application.Current.Windows.OfType<StartWindow>().FirstOrDefault().DragMove();



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
                await Task.Delay(1800000);
            }
        }
        private async void Time_Track()
        {
            await time();
        }

        public void For_Left_Panel()
        {
            Cur_Weather w = Working.Main_weather(SonClounds.Properties.Settings.Default.CurrentCity);
            List<NiceList> listik = Working.Left_Panel(SonClounds.Properties.Settings.Default.CurrentCity);
            if (SonClounds.Properties.Settings.Default.TempCond == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    listik[i].tempr = Math.Round((Convert.ToInt32(listik[i].tempr) * 1.8) + 32).ToString() + "°F";//Фаренгейты
                    listik[i].oshys = Math.Round((Convert.ToInt32(listik[i].oshys) * 1.8) + 32).ToString() + "°F";
                }
                
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    listik[i].tempr += "°C";//Фаренгейты
                    listik[i].oshys += "°C";
                }
            }
            Text2 = listik[0].desc.Substring(0,1).ToUpper() + listik[0].desc.Substring(1) + ". " + listik[0].tempr + "° " + "Ощущается как " + listik[0].oshys + "°";//Большая первая буква
            Text3 = listik[1].desc.Substring(0, 1).ToUpper() + listik[1].desc.Substring(1) + ". " + listik[1].tempr + "° " + "Ощущается как " + listik[1].oshys + "°"; ;
            Text4 = listik[2].desc.Substring(0, 1).ToUpper() + listik[2].desc.Substring(1) + ". " + listik[2].tempr + "° " + "Ощущается как " + listik[2].oshys + "°"; ;
            timeFirst = listik[0].time.Hour.ToString() + ":00";
            timeSecond = listik[1].time.Hour.ToString() + ":00";
            timeThird = listik[2].time.Hour.ToString() + ":00";
            for (int i = 0; i < 3; i++)
            {
                switch(listik[i].Des_Main)
                {
                    case "Thunderstorm":
                        switch(i)
                        {
                            case 0:
                                PutSecond = "/Resources/Picture/Thunderstorm.png";
                                break;
                            case 1:
                                PutThird = "/Resources/Picture/Thunderstorm.png";
                                break;
                            case 2:
                                PutFourth = "/Resources/Picture/Thunderstorm.png"; 
                                break;
                        }
                        break;
                    case "Rain":
                        switch (i)
                        {
                            case 0:
                                PutSecond = "/Resources/Picture/Rainy.png";
                                break;
                            case 1:
                                PutThird = "/Resources/Picture/Rainy.png";
                                break;
                            case 2:
                                PutFourth = "/Resources/Picture/Rainy.png";
                                break;
                        }
                        break;
                    case "Snow":
                        switch (i)
                        {
                            case 0:
                                PutSecond = "/Resources/Picture/Snow.png";
                                break;
                            case 1:
                                PutThird = "/Resources/Picture/Snow.png";
                                break;
                            case 2:
                                PutFourth = "/Resources/Picture/Snow.png";
                                break;
                        }
                        break;
                    case "Clear":
                        switch (i)
                        {
                            case 0:
                                PutSecond = "/Resources/Picture/Sunny.png";
                                break;
                            case 1:
                                PutThird = "/Resources/Picture/Sunny.png";
                                break;
                            case 2:
                                PutFourth = "/Resources/Picture/Sunny.png";
                                break;
                        }
                        break;  
                    case "Clouds":
                        switch (i)
                        {
                            case 0:
                                PutSecond = "/Resources/Picture/Cloudy.png";
                                break;
                            case 1:
                                PutThird = "/Resources/Picture/Cloudy.png";
                                break;
                            case 2:
                                PutFourth = "/Resources/Picture/Cloudy.png";
                                break;
                        }
                        break;
                    case "Drizzle":
                        switch (i)
                        {
                            case 0:
                                PutSecond = "/Resources/Picture/Downpour.png";
                                break;
                            case 1:
                                PutThird = "/Resources/Picture/Downpour.png";
                                break;
                            case 2:
                                PutFourth = "/Resources/Picture/Downpour.png";
                                break;
                        }
                        break;

                }

                
            }
            if (SonClounds.Properties.Settings.Default.TempCond == false)
            {
                w.temp = (int)Math.Round((w.temp * 1.8) + 32);//Фаренгейты
                w.feels = (int)Math.Round((w.feels * 1.8) + 32);
                Text1 = w.desc.Substring(0, 1).ToUpper() + w.desc.Substring(1) + ". " + w.temp + "°" + "Ощущается как " + w.feels + "°F";
            }
            else
            {
                Text1 = w.desc.Substring(0, 1).ToUpper() + w.desc.Substring(1) + ". " + w.temp + "°" + "Ощущается как " + w.feels + "°С";
            }

            switch (w.main)
            {
                case "Thunderstorm":
                    PutFirst = "/Resources/Picture/Thunderstorm.png";
                    break;
                case "Rain":
                    PutFirst = "/Resources/Picture/Rainy.png";
                    break;
                case "Snow":
                    PutFirst = "/Resources/Picture/Snow.png";
                    break;
                case "Clear":
                    PutFirst = "/Resources/Picture/Sunny.png";
                    break;
                case "Clouds":
                    PutFirst = "/Resources/Picture/Cloudy.png";
                    break;
                case "Drizzle":
                    PutFirst = "/Resources/Picture/Downpour.png";
                    break;
            }
        }





    }
}
