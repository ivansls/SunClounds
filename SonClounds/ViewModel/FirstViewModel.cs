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




        public ICommand Temperature { get; }
        public ICommand FeelsLike { get; }
        public ICommand Pressure1 { get; }

        #region Svoystva

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
        public string[] XLabels { get; set; }
        public int[] Ylabels { get; set; }
        public Func<double, string> Formatter { get; set; }
        private LineSeries LineSeries = new LineSeries();
        private bool Listen_Theme = true;
        #endregion
        #region Commands

        #endregion

        public FirstViewModel()
        {
            Temperature = new BindableCommand(_ => temperature());
            FeelsLike = new BindableCommand(_ => feelsLike());
            Pressure1 = new BindableCommand(_ => pressure());
            temperature();

            //if(DateTime.Now.Hour < 11)
            //{
            //    ints = new ChartValues<double> {5, 10, 45, 20, 30, 40, 38, 10, -5, 23,
            //                                         45 };
            //    XLabels = new[] { "00:00", "01:00", "02:00", "03:00", "04:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00" };
            //}
            //0 3 7 10 13 16 19 22 
            //else
            //{
            //    ints = new ChartValues<double> {30, 37, -9, -2, 3, 4, 5, 6, 7, 25,
            //                                         22, 45 };
            //    XLabels = new[] {"12:00", "13:00",
            //"14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"};
            //}

            //ints = new ChartValues<double> {5, 10, 45, 20, 30, 40, 38, 10};
            Load_Info();

            XLabels = new string[] { "00:00", "03:00", "06:00", "09:00", "12:00", "15:00", "18:00", "21:00" };
            //SeriesCollection_ = new SeriesCollection()
            //{
            //    new LineSeries
            //    {

            //        Values = ints,
            //        Stroke = new SolidColorBrush(Color.FromRgb(61, 149, 185)),
            //        Fill = Brushes.Transparent,
            //        Title = "Градусов:",
            //        PointForeground = new SolidColorBrush(Color.FromRgb(135,182,202)),
            //        PointGeometrySize = 10,


            //    }

            //};
            LineSeries.Values = ints;
            LineSeries.Stroke = new SolidColorBrush(Color.FromRgb(61, 149, 185));
            LineSeries.Fill = Brushes.Transparent;
            LineSeries.Title = "Градусов:";
            LineSeries.PointForeground = new SolidColorBrush(Color.FromRgb(135, 182, 202));
            LineSeries.PointGeometrySize = 15;
            SeriesCollection_ = new SeriesCollection() { LineSeries};
            Theme_listening();
            //возможно дэйблы для игрика стоит хранить в числовом формате и просто настроить формат
            Ylabels = new[] { 10, 20, 30, 40, 50};
            //если цельсии то:
            Formatter = value => value.ToString("N0") + "°C";
            //если фаренгейты то:
            //Formatter = value => value.ToString("N0") + "°F";

            Pogoda();

        }
        private async Task Loading_Info_Into_FirstPage()
        {
            for(int i = 0; i < 8; i++)
            {
                ints.Add(i);
                await Task.Delay(100);
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
        }
        public void feelsLike()
        {
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
        }
        public void pressure()
        {
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
        }
        // здесь будет таск для отслеживания нажатия кнопок, чтобы выводить корректные данные для диаграммы (или не будет)
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
                    Degrees = w.temp + "°";
                    Feeling = w.feels + "°";
                    Min = w.min_temp + "°";
                    Max = w.max_temp + "°";
                    Pressure = w.pressure + " мм рт. ст";
                    Humidity = w.humidity + "%";
                    Wind = w.wind + " м/с";
                    Wind2 = w.wind2;
                }
            
                await Task.Delay(3600000);//Каждый час

            }
            
        }
       


    }
}
