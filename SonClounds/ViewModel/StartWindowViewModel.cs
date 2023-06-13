using pr7.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public BindableCommand ClearAllTextCommand { get; set; }
        #endregion
        #region Svoystava
        private WindowState Window_State = new WindowState();
        private bool flag = false;
        public WindowState W_S
        {
            get { return Window_State; }
            set
            {
                Window_State = value;
                OnPropertyChenged();
            }
        }
        #endregion
        public StartWindowViewModel() 
        { 
            CloseCommand= new BindableCommand(_ => CloseWindow());
            AllScreenCommand = new BindableCommand(_ => OpenWideWindow());
            LessCommand = new BindableCommand(_ => OpenLessWindow());
            TextStartedChangingCommand = new BindableCommand(_ => TextChanging());
            ClearAllTextCommand = new BindableCommand(_ => ClearText());

        }

        public void TextChanging()
        {
            //
        }
        public void ClearText() 
        { 
            //
        }

        public void CloseWindow()
        {
            Application.Current.Shutdown();
        }
        public void OpenWideWindow()
        {
            W_S = WindowState.Maximized;
            flag = false;
        }
        public void OpenLessWindow()
        {
            if(!flag)
            {
                W_S = WindowState.Normal;
                flag = true;
            }
            else
            {
                W_S = WindowState.Minimized;
            }
        }
    }
}
