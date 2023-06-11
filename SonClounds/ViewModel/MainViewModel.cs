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
            ToGame = new BindableCommand(_ => Create_());
        }

        public ICommand ToGame { get; }

        private void Create_()
        {
            /*if (_userName == null)
            {
                MessageBox.Show("Веди имя");
            }
            else
            {
               
                GameViewModel.user = UserName;
                Game game = new Game();
                game.Show();
                MainWindow win = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (win != null)
                {
                    win.Close();
                }

            }*/
        }


        
    }
}
