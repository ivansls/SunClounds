using SonClounds.View;
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
using SunClounds.ViewModel;

namespace SonClounds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainViewModel mb = new MainViewModel();
            mb.default_values();
        }

        //private void Button_Click(object sender, RoutedEventArgs e) !!!ЗАГОТОВКА ДЛЯ КНОПОК СО СМЕНОЙ ТЕМЫ!!!
        //{
        //    App.Theme = "PurpleTheme"; ЭТО НАЗВАНИЕ СЛОВАРЯ в Resources/Theme
        //}
        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    App.Theme = "OrangeTheme"; ЭТО НАЗВАНИЕ СЛОВАРЯ в Resources/Theme
        //}
    }
}
