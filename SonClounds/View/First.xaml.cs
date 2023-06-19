using SonClounds.ViewModel;
using SunClounds.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SonClounds.View
{
    /// <summary>
    /// Логика взаимодействия для First.xaml
    /// </summary>
    public partial class First : Page
    {
        public First()
        {
            InitializeComponent();
            DataContext = new FirstViewModel();
            for (int i = 0; i < 5; i++)
            {
                WeatherCart izbranGoroda = new WeatherCart();
                UserEl.Children.Add(izbranGoroda);
            }

        }

       
    }
}
