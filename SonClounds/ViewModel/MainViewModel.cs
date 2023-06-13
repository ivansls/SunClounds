using SonClounds;
using SonClounds.ViewModel.Helpers;
using System.Windows.Controls;
using System.Windows.Input;

namespace SunClounds.ViewModel
{

    internal class MainViewModel : BindingHelper
    {
        
        private static Page Frame_Page = new Second();

       

        public Page framePage
        {
            get { return Frame_Page; }
            set
            {
                Frame_Page = value;
                OnPropertyChenged();
            }
        }





        public MainViewModel()
        {
            ToSettings = new BindableCommand(_ => to_settings());
            ToWeather = new BindableCommand(_ => to_weather());
        }

        public ICommand ToSettings { get; }
        public ICommand ToWeather { get; }

        private void to_settings()
        {
            
        }


        private void to_weather()
        {

        }



    }
}
