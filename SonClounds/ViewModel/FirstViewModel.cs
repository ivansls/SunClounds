using SonClounds.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using LiveCharts.Definitions.Series;
using System.Runtime;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Configuration;
using System.Windows;
using Microsoft.VisualBasic;
using System.Threading;
using Api_Work;
using SunClounds.ViewModel;
using SonClounds.View;
using System.Windows.Media.Imaging;

namespace SonClounds.ViewModel
{
    internal class FirstViewModel : BindingHelper
    {
        private static string degr;
        private static string feel_ing;
        private static string min_value;
        private static string max_value;
        private static string press_ure;
        private static string humid_ity;
        private static string w_ind;
        private static string w_ind2;

        public bool PogWorking = true;

        private static List<WeatherCart> listweather = new List<WeatherCart> { };


        public ICommand Temperature { get; }
        public ICommand FeelsLike { get; }
        public ICommand Pressure1 { get; }

        #region Svoystva

        public List<WeatherCart> ListWeather
        {
            get { return listweather; }
            set
            {
                listweather = value;
                OnPropertyChenged();
            }
        }


        public string Degrees //Температура
        {
            get { return degr; }
            set
            {
                degr = value;
                OnPropertyChenged();
            }
        }
        public string Feeling //Ощущается
        {
            get { return feel_ing; }
            set
            {
                feel_ing = value;
                OnPropertyChenged();
            }
        }
        public string Min //Минимальная температуа
        {
            get { return min_value; }
            set
            {
                min_value = value;
                OnPropertyChenged();
            }
        }
        public string Max //Максимальная температура
        {
            get { return max_value; }
            set
            {
                max_value = value;
                OnPropertyChenged();
            }
        }
        public string Pressure //Давление
        {
            get { return press_ure; }
            set
            {
                press_ure = value;
                OnPropertyChenged();
            }
        }
        public string Humidity //Влажность
        {
            get { return humid_ity; }
            set
            {
                humid_ity = value;
                OnPropertyChenged();
            }
        }
        public string Wind //Ветер в м/с
        {
            get { return w_ind; }
            set
            {
                w_ind = value;
                OnPropertyChenged();
            }
        }
        public string Wind2 //Просто ветер
        {
            get { return w_ind2; }
            set
            {
                w_ind2 = value;
                OnPropertyChenged();
            }
        }







        private static string TimeGod = "21:00";

        public string Timegod //Время
        {
            get { return TimeGod; }
            set
            {
                TimeGod = value;
                OnPropertyChenged();
            }
        }


        private static string Bebra = "21º";

        public string bebra //Температура
        {
            get { return Bebra; }
            set
            {
                Bebra = value;
                OnPropertyChenged();
            }
        }


        private static string Vlaj = "15º";

        public string vlaj //Температура
        {
            get { return Vlaj; }
            set
            {
                Vlaj = value;
                OnPropertyChenged();
            }
        }

        private static string Ochuc = "15º";

        public string ochuc //Температура
        {
            get { return Ochuc; }
            set
            {
                Ochuc = value;
                OnPropertyChenged();
            }
        }

        
        private int fsx = 20;
        public int FontSizeX
        {
            get
            {
                return fsx;
            }
            set { fsx = value;
            OnPropertyChenged();}
        }
        private int fsy = 20;
        public int FontSizeY
        {
            get
            {
                return fsy;
            }
            set
            {
                fsy = value;
                OnPropertyChenged();
            }
        }
        private Visibility visible_prbar_1;
        public Visibility Visible_PrBar_1
        {
            get
            {
                return visible_prbar_1;
            }
            set
            {
                visible_prbar_1 = value;
                OnPropertyChenged();
            }
        }
        private Visibility visible_prbar_2;
        public Visibility Visible_PrBar_2
        {
            get { return visible_prbar_2;}
            set
            {
                visible_prbar_2 = value;
                OnPropertyChenged();
            }
        }
        private Brush bg_f = new SolidColorBrush();
        public Brush bg_first
        {
            get
            {
                return bg_f;
            }
            set
            {
                bg_f = value;
                OnPropertyChenged();
            }
        }
        private Brush bg_s = new SolidColorBrush();
        public Brush bg_second
        {
            get
            {
                return bg_s;
            }
            set
            {
                bg_s = value;
                OnPropertyChenged();
            }
        }
        private Brush bg_t = new SolidColorBrush();
        public Brush bg_third
        {
            get
            {
                return bg_t;
            }
            set
            {
                bg_t = value;
                OnPropertyChenged();
            }
        }


        private ChartValues<double> ints = new ChartValues<double>();
        public SeriesCollection SeriesCollection_ { get; set; }
        private List<string> xlabels = new List<string>();
        public List<string> XLabels
        {
            get
            {
                return xlabels;
            }
            set {
                xlabels = value;
                OnPropertyChenged() ;
            }
        }
        public int[] Ylabels { get; set; }
        //public Func<double, string> Formatter { get; set; }
        private Func<double, string> formatter;
        public Func<double, string> Formatter
        {
            get
            {
                return formatter;
            }
            set
            {
                formatter = value;
                OnPropertyChenged() ;
            }
        }
        private LineSeries LineSeries = new LineSeries();
        private bool Listen_Theme = true;
        private bool temp_pressed = true;
        private bool feels_pressed = false;
        private bool pressure_pressed = false;
        private List<NiceList> listik = Working.Left_Panel(Properties.Settings.Default.CurrentCity);
        private bool get_data = true;
        #endregion
        #region Commands

        #endregion

        public FirstViewModel()
        {
            Temperature = new BindableCommand(_ => temperature());
            FeelsLike = new BindableCommand(_ => feelsLike());
            Pressure1 = new BindableCommand(_ => pressure());
            LineSeries.Values = ints;
            LineSeries.Stroke = new SolidColorBrush(Color.FromRgb(61, 149, 185));
            LineSeries.Fill = Brushes.Transparent;
            LineSeries.Title = "Градусов:";
            LineSeries.PointForeground = new SolidColorBrush(Color.FromRgb(135, 182, 202));
            LineSeries.PointGeometrySize = 15;
            SeriesCollection_ = new SeriesCollection() { LineSeries};
            temperature();
            Theme_listening();
            Ylabels = new[] { 10, 20, 30, 40, 50};
            Pogoda();
            getting_new_data();
            cart_weath();

        }

        public void cart_weath()
        {
            List<WeatherCart> listweather1 = new List<WeatherCart> { };
            for (int i = 0; i < 9; i++)
            {
                WeatherCart weatherCart = new WeatherCart();
                switch (listik[i].Des_Main)
                {
                    case "Thunderstorm":
                        weatherCart.pic.Source = new BitmapImage(new Uri("/Resources/Picture/Thunderstorm.png", UriKind.Relative));
                        
                        break;
                    case "Rain":
                       
                        weatherCart.pic.Source = new BitmapImage(new Uri("/Resources/Picture/Thunderstorm.png", UriKind.Relative));
                            
                        
                        break;
                    case "Snow":
                        weatherCart.pic.Source = new BitmapImage(new Uri("/Resources/Picture/Snow.png", UriKind.Relative));
                        
                        break;
                    case "Clear":
                        weatherCart.pic.Source = new BitmapImage(new Uri("/Resources/Picture/Sunny.png", UriKind.Relative));
                        
                        break;
                    case "Clouds":
                        weatherCart.pic.Source = new BitmapImage(new Uri("/Resources/Picture/Cloudy.png", UriKind.Relative));
                        
                        break;
                    case "Drizzle":
                        weatherCart.pic.Source = new BitmapImage(new Uri("/Resources/Picture/Downpour.png", UriKind.Relative));
                        
                        break;

                }
                weatherCart.TextUpCen.Text = listik[i].time.ToString("HH:mm");
                if (SonClounds.Properties.Settings.Default.TempCond == false)
                {
                    weatherCart.TextDownCen.Text = Math.Round((Convert.ToInt32(listik[i].tempr) * 1.8) + 32).ToString() + "°F";//Фаренгейты
                    weatherCart.TextRghtDl.Text = Math.Round((Convert.ToInt32(listik[i].oshys) * 1.8) + 32).ToString() + "°F";
                }
                else
                {
                    weatherCart.TextDownCen.Text = listik[i].tempr.ToString() + "°C";//Цельсия
                    weatherCart.TextRghtDl.Text = listik[i].oshys.ToString() + "°C";
                }
                //weatherCart.TextDownCen.Text = listik[i].tempr.ToString();
                weatherCart.TextRghtDr.Text = listik[i].vlazn.ToString();
                //weatherCart.TextRghtDl.Text = listik[i].oshys.ToString();
                listweather1.Add(weatherCart);

            }
            ListWeather = listweather1;
        }

        private async Task Loading_Info_Into_FirstPage()
        {
            foreach (NiceList item in listik)
            {
                if (temp_pressed)
                {
                    foreach (LineSeries line in SeriesCollection_)
                    {
                        line.Title = "Температура: ";
                        await Task.Delay(100);
                    }
                    // check for C or F
                    Formatter = value => value.ToString("N0") + "°C";
                    ints.Add(Convert.ToDouble(item.tempr));
                    await Task.Delay(100);
                    XLabels.Add(item.time.Hour.ToString() + ":00");
                    await Task.Delay(100);
                }
                else if (feels_pressed)
                {
                    foreach (LineSeries line in SeriesCollection_)
                    {
                        line.Title = "Ощущается как: ";
                        await Task.Delay(100);
                    }
                    // check for C or F
                    Formatter = value => value.ToString("N0") + "°C";
                    ints.Add(Convert.ToDouble(item.oshys));
                    await Task.Delay(100);
                    XLabels.Add(item.time.Hour.ToString() + ":00");
                    await Task.Delay(100);
                }
                else
                {
                    foreach (LineSeries line in SeriesCollection_)
                    {
                        line.Title = "Давление: ";
                        await Task.Delay(100);
                    }
                    Formatter = value => value.ToString("N0") + "мм.рт.с.";
                    ints.Add(Convert.ToDouble(item.pressure));
                    await Task.Delay(100);
                    XLabels.Add(item.time.Hour.ToString() + ":00");
                    await Task.Delay(100);
                }
                
            }
        }
        private async void Load_Info()
        {
            Visible_PrBar_1 = Visibility.Visible;
            Visible_PrBar_2 = Visibility.Visible;
            await Loading_Info_Into_FirstPage();
            Visible_PrBar_1 = Visibility.Hidden;
            Visible_PrBar_2 = Visibility.Hidden;
        }
        public void temperature()
        {
            XLabels.Clear();
            ints.Clear();
            temp_pressed = true;
            feels_pressed = false;
            pressure_pressed = false;
            if(App.Theme == "MorningTheme" || App.Theme == "DayTheme")
            {
                bg_first = new SolidColorBrush(Color.FromRgb(61, 149, 185));
                bg_second = new SolidColorBrush(Color.FromRgb(135, 182, 202));
                bg_third = new SolidColorBrush(Color.FromRgb(135, 182, 202));
            }
            else
            {
                bg_first = new SolidColorBrush(Color.FromRgb(248, 197, 180));
                bg_second = new SolidColorBrush(Color.FromRgb(89, 30, 110));
                bg_third = new SolidColorBrush(Color.FromRgb(89, 30, 110));
            }
            Load_Info();
        }
        public void feelsLike()
        {
            XLabels.Clear();
            ints.Clear();
            feels_pressed = true;
            temp_pressed = false;
            pressure_pressed = false;
            if (App.Theme == "MorningTheme" || App.Theme == "DayTheme")
            {
                bg_first = new SolidColorBrush(Color.FromRgb(135, 182, 202));
                bg_second = new SolidColorBrush(Color.FromRgb(61, 149, 185));
                bg_third = new SolidColorBrush(Color.FromRgb(135, 182, 202));
            }
            else
            {
                bg_first = new SolidColorBrush(Color.FromRgb(89, 30, 110));
                bg_second = new SolidColorBrush(Color.FromRgb(248, 197, 180));
                bg_third = new SolidColorBrush(Color.FromRgb(89, 30, 110));
            }
            Load_Info() ;
        }
        public void pressure()
        {
            XLabels.Clear();
            ints.Clear();
            pressure_pressed = true;
            temp_pressed = false;
            feels_pressed = false;
            if (App.Theme == "MorningTheme" || App.Theme == "DayTheme")
            {
                bg_first = new SolidColorBrush(Color.FromRgb(135, 182, 202));
                bg_second = new SolidColorBrush(Color.FromRgb(135, 182, 202));
                bg_third = new SolidColorBrush(Color.FromRgb(61, 149, 185));
            }
            else
            {
                bg_first = new SolidColorBrush(Color.FromRgb(89, 30, 110));
                bg_second = new SolidColorBrush(Color.FromRgb(89, 30, 110));
                bg_third = new SolidColorBrush(Color.FromRgb(248, 197, 180));
            }
            Load_Info();
        }

        private async Task Theme_Listener()
        {
            while (Listen_Theme)
            {
                foreach(LineSeries line in SeriesCollection_)
                {
                    if(App.Theme == "MorningTheme" || App.Theme == "DayTheme")
                    {
                        line.Stroke = new SolidColorBrush(Color.FromRgb(61, 149, 185));
                        line.PointForeground = new SolidColorBrush(Color.FromRgb(135, 182, 202));
                    }
                    else
                    {
                        line.Stroke = new SolidColorBrush(Color.FromRgb(248, 197, 180));
                        line.PointForeground = new SolidColorBrush(Color.FromRgb(89, 30, 110));
                    }
                }
                await Task.Delay(1800000);
            }
        }
        private async void Theme_listening()
        {
            await Theme_Listener();
        }

        private async Task Pogoda()
        {
            while (PogWorking)
            {
                Cur_Weather w = Working.Main_weather(SonClounds.Properties.Settings.Default.CurrentCity);
                if(w == null)
                {
                    /*MessageBox.Show("Error");*/ //или как-то по другому сделать
                }
                else
                {
                    if(SonClounds.Properties.Settings.Default.TempCond == false)
                    {
                        Degrees = Math.Round((w.temp*1.8)+32).ToString() + "°F";//Фаренгейты
                        Feeling = Math.Round((w.feels * 1.8) + 32).ToString() + "°F";
                        Min = Math.Round((w.min_temp * 1.8) + 32).ToString() + "°F";
                        Max = Math.Round((w.max_temp * 1.8) + 32).ToString() + "°F";
                    }
                    else
                    {
                        Degrees = w.temp + "°C";//Цельсия
                        Feeling = w.feels + "°C";
                        Min = w.min_temp + "°C";
                        Max = w.max_temp + "°C";
                    }
                    
                   
                   
                   
                    Pressure = w.pressure + " мм рт. ст";
                    Humidity = w.humidity + "%";
                    Wind = w.wind + " м/с";
                    Wind2 = w.wind2;
                    //MainViewModel.text_1 = w.temp;
                    MainViewModel.text_1 = w.desc.Substring(0, 1).ToUpper() + w.desc.Substring(1);
                    switch (w.main)
                    {
                        case "Thunderstorm":
                            MainViewModel.put1 = "/Resources/Picture/Thunderstorm.png";
                            break;
                        case "Rain":
                            MainViewModel.put1 = "/Resources/Picture/Rainy.png";
                            break;
                        case "Snow":
                            MainViewModel.put1 = "/Resources/Picture/Snow.png";
                            break;
                        case "Clear":
                            MainViewModel.put1 = "/Resources/Picture/Sunny.png";
                            break;
                        case "Clouds":
                            MainViewModel.put1 = "/Resources/Picture/Cloudy.png";
                            break;
                        case "Drizzle":
                            MainViewModel.put1 = "/Resources/Picture/Downpour.png";
                            break;
                    }
                }
            
                await Task.Delay(3600000);//Каждый час

            }
            
        }

        private async Task get_new_data()
        {
            while (get_data)
            {
                listik = Working.Left_Panel(Properties.Settings.Default.CurrentCity);
                await Task.Delay(10800000);
            }
            
        }
        public async void getting_new_data()
        {
            await get_new_data();
        }
       


    }
}
