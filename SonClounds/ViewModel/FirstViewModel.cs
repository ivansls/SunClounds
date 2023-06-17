using SonClounds.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private int fsx = 15;
        public int FontSizeX
        {
            get
            {
                return fsx;
            }
            set { fsx = value;
            OnPropertyChenged();}
        }
        private int fsy = 15;
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
        private int window_w = 1000;
        public int Width_w
        {
            get { return window_w; }
            set
            {
                window_w = value;
                OnPropertyChenged();
            }
        }
        private bool Width_is_listening = true;
        public SeriesCollection SeriesCollection_ { get; set; }
        public string[] XLabels { get; set; }
        public int[] Ylabels { get; set; }
        public Func<double, string> Formatter { get; set; }
        #endregion
        #region Commands

        #endregion

        public FirstViewModel()
        {
            ChartValues<double> ints;
            if(DateTime.Now.Hour < 11)
            {
                ints = new ChartValues<double> {5, 10, 45, 20, 30, 40, 38, 10, -5, 23,
                                                     45 };
                XLabels = new[] { "00:00", "01:00", "02:00", "03:00", "04:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00" };
            }
            else
            {
                ints = new ChartValues<double> {30, 37, -9, -2, 3, 4, 5, 6, 7, 25,
                                                     22, 45 };
                XLabels = new[] {"12:00", "13:00",
            "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"};
            }
            SeriesCollection_ = new SeriesCollection()
            {
                new LineSeries
                {

                    Values = ints,
                    Stroke = new SolidColorBrush(Color.FromRgb(61, 149, 185)),
                    Fill = Brushes.Transparent,
                    Title = "Градусов:",
                    PointForeground = new SolidColorBrush(Color.FromRgb(135,182,202)),
                    PointGeometrySize = 10,
                    
                   
                    
                }
                
            };
            //возможно дэйблы для игрика стоит хранить в числовом формате и просто настроить формат
            Ylabels = new[] { 10, 20, 30, 40, 50};
            Formatter = value => value.ToString("N0") + "°";
            start_tracking_width();
        }

        private async Task Width_Listening()
        {
            while(Width_is_listening)
            {
                //if (Width_w < 800 && Width_w > 400 && Width_w > 200)
                //{
                //    FontSizeX = 15;
                //    FontSizeY = 15;
                //}
                //if (Width_w < 400 && Width_w > 200)
                //{
                //    FontSizeX = 10;
                //    FontSizeY = 10;
                //}
                //if (Width_w < 200)
                //{
                //    FontSizeX = 5;
                //    FontSizeY = 5;
                //}
                //if (Width_w > 800)
                //{
                //    FontSizeX = 20;
                //    FontSizeY = 20;
                //}
                //double a = SystemParameters.PrimaryScreenWidth;
                //if(SystemParameters.WorkArea.Width < 600 && SystemParameters.WorkArea.Width > 400)
                //{
                //    MessageBox.Show("343434");
                //}
                //if(SystemParameters.PrimaryScreenWidth < 400)
                //{
                //    MessageBox.Show("aaaaaaa");
                //}
                await Task.Delay(50);
            }
        }
        private async void start_tracking_width()
        {
            await Width_Listening();
        }
    }
}
