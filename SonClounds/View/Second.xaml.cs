﻿using SonClounds.View;
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

namespace SonClounds
{
    /// <summary>
    /// Логика взаимодействия для Second.xaml
    /// </summary>
    public partial class Second : Page
    {
        public Second(MainViewModel main)
        {
            InitializeComponent();
            DataContext = new SecondViewModel(main);
        }

    }
}
