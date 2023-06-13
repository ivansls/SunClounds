using pr7.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SonClounds.ViewModel
{
    internal class StartWindowViewModel:BindingHelper
    {

        #region Commands
        public BindableCommand CloseCommand { get; set; }
        public BindableCommand LessCommand { get; set; }
        public BindableCommand AllScreenCommand { get; set; }
        public BindableCommand TextStartedChangingCommand { get; set; }
        #endregion
        public StartWindowViewModel() 
        { 
            CloseCommand= new BindableCommand(_ => CloseWindow());
            AllScreenCommand = new BindableCommand(_ => OpenWideWindow());
            LessCommand = new BindableCommand(_ => OpenLessWindow());

        }

        public void TextChanging()
        {

        }

        public void CloseWindow()
        {
            MessageBox.Show("fhfhfh");
        }
        public void OpenWideWindow()
        {
            MessageBox.Show("Wide");
        }
        public void OpenLessWindow()
        {
            MessageBox.Show("Less");
        }
    }
}
