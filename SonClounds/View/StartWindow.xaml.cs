using SonClounds.ViewModel;
using SunClounds.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SonClounds.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainViewModel mb = new MainViewModel();
            mb.default_values();
        }

        /*private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            var ah = ActualHeight;
            var aw = ActualWidth;
            var h = Height;
            var w = Width;
            if (w == 880)
            {
                MessageBox.Show(aw + " " + w);
            }
            Trace.WriteLine(aw);
            Console.WriteLine(aw);
            //MessageBox.Show(aw + " " + w);
        }*/


       
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {
            }
        }
    }
}
