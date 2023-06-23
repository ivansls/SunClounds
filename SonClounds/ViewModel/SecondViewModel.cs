
using Api_Work;
using SonClounds.Model;
using SonClounds.View;
using SonClounds.ViewModel.Helpers;
using SonClounds.ViewModel.Helpers;
using SunClounds.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SonClounds.ViewModel
{
    internal class SecondViewModel : BindingHelper
    {

        private static bool gradus = SonClounds.Properties.Settings.Default.TempCond;

        private static string Core_city;

        private static string text_city = "Название города";

        //List<WeatherClass> cityList = new List<WeatherClass>();

        private static List<IzbranGoroda> izbrans = new List<IzbranGoroda>();
        private static List<IzbranGoroda> izbrans1 = new List<IzbranGoroda>();


        public List<IzbranGoroda> List_Favorit
        {
            get { return izbrans; }
            set
            {
                izbrans = value;
                OnPropertyChenged();
            }
        }

        public string CoreCity
        {
            get { return Core_city; }
            set
            {
                Core_city = value;
                OnPropertyChenged();
            }
        }


        public string TextCity
        {
            get { return text_city; }
            set
            {
                text_city = value;
                OnPropertyChenged();
            }
        }

        public bool TempSwitch
        {
            get { return gradus; }
            set
            {
                gradus = value;
                OnPropertyChenged();
            }
        }



        public SecondViewModel()
        {
            Save = new BindableCommand(_ => Save_());
            AddCity = new BindableCommand(_ => Add_City());
            Celisiy = new BindableCommand(_ => Cel());
            Faringate = new BindableCommand(_ => Far());
            Clear = new BindableCommand(_ => clear());
            Clear_Upper_Txb = new BindableCommand(_ => clear_upper());
            Core_city = SonClounds.Properties.Settings.Default.CurrentCity;
            CartFavorit();

        }

        public ICommand Save { get; }

        public ICommand AddCity { get; }

        public ICommand Celisiy { get; }

        public ICommand Faringate { get; }

        public ICommand Clear { get; }
        public BindableCommand Clear_Upper_Txb { get; }



        private void Save_()
        {
            SonClounds.Properties.Settings.Default.CurrentCity = CoreCity;
            MessageBox.Show(CoreCity);
            SonClounds.Properties.Settings.Default.Save();
            //MainViewModel win = Application.Current.MainWindow.OfType<MainViewModel>().First();
            //win.For_Left_Panel();
            //Сюда желательно добавить метод на смену левой панели For_left_Panel но как я хз
        }

        private void Add_City()

        {
            /*WeatherClass weatherClass = new WeatherClass();
            weatherClass.NameCity = "gfgh";
            weatherClass.latitude = 56;
            weatherClass.longitude = 76;
            cityList.Add(weatherClass);*/
            Cur_Weather w = Working.Main_weather(TextCity);
            if (w == null)
            {
                MessageBox.Show("Такого города нет");
            }
            if (Properties.Settings.Default.ListFavoritCity.Contains(TextCity))
            {
               
                MessageBox.Show("Такой город уже есть");
            }
            else
            {
                Properties.Settings.Default.ListFavoritCity += TextCity + ",";
                Properties.Settings.Default.Save();
                CartFavorit();
            }
            
            

            
        }





        private void Cel()
        {
            MessageBox.Show("Cell");
            Properties.Settings.Default.TempCond = TempSwitch;
            SonClounds.Properties.Settings.Default.Save();
        }

        private void Far()
        {
            MessageBox.Show("Far");
            SonClounds.Properties.Settings.Default.TempCond = TempSwitch;
            SonClounds.Properties.Settings.Default.Save();
        }

        public void clear()
        {
            TextCity = "";

        }
        public void clear_upper()
        {
            CoreCity = "";
        }


        private void CartFavorit()
        {
            try
            {
                List_Favorit.Clear();
                for_Favorit();
            }
            catch
            {
                for_Favorit();
            }
        }

        

        private void for_Favorit()
        {
            string cit = Properties.Settings.Default.ListFavoritCity;
            string[] a = cit.Split(",");
            for (int i = 0; i < a.Length ; i++)
            {
                if (a[i] != "")
                {
                    Cur_Weather w = Working.Main_weather(a[i]);
                    if(w != null)
                    {
                        IzbranGoroda izbranGoroda = new IzbranGoroda();
                        izbranGoroda.UpText.Text = a[i];

                        izbranGoroda.DownTextL.Text = w.lat + " c.ш";
                        izbranGoroda.DownTextR.Text = w.lon + " в.д.";
                        izbrans1.Add(izbranGoroda);
                    }
                    
                    

                }
            }
            List_Favorit = null;
            List_Favorit = izbrans1;
        }
    }
}
