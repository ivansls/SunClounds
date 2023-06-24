using SonClounds.View;
using SonClounds.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SonClounds.ViewModel
{
    internal class izbranViewModel : BindingHelper
    {
        SecondViewModel sec;
        IzbranGoroda iz;
        public izbranViewModel(SecondViewModel s, IzbranGoroda i)
        {
            sec = s;
            iz = i;
            DelFav = new BindableCommand(_ => del());
        }
        public ICommand DelFav { get; }

        public void del()
        {
            sec.DelFavorit(iz);
        }
        

    }
}
