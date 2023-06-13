using pr7.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        public void TextChanging()
        {

        }
    }
}
