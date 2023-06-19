using SonClounds.ViewModel.Helpers;
using SunClounds.ViewModel;
using System;
using System.Collections.Generic;
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
        


        private static string Core_city;

        private static string text_city = "город";
      

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

       

        public SecondViewModel()
        {
            Save = new BindableCommand(_ => Save_());
            AddCity = new BindableCommand(_ => Add_City());
            Celisiy = new BindableCommand(_ => Cel());
            Faringate = new BindableCommand(_ => Far());
            Clear = new BindableCommand(_ => clear());
            Core_city = SonClounds.Properties.Settings.Default.CurrentCity;

    }

        public ICommand Save { get; }

        public ICommand AddCity { get; }

        public ICommand Celisiy { get; }

        public ICommand Faringate { get; }

        public ICommand Clear { get; }
        


        private void Save_()
        {
            SonClounds.Properties.Settings.Default.CurrentCity = CoreCity;
            MessageBox.Show(CoreCity);
            SonClounds.Properties.Settings.Default.Save();
        }


        private void Add_City()
        {

            MessageBox.Show("add");
        }



        private void Cel()
        {
            MessageBox.Show("Cell");
        }

        private void Far()
        {
            MessageBox.Show("Far");
        }

        public void clear()
        {
            TextCity = "";

        }
    }
}
