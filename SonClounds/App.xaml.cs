using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SonClounds
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static string theme;
        public static string Theme // Переменная, которая хранит в себе название файла с цветом
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
                var dict = new ResourceDictionary() // Создание словаря кодом 
                {
                    Source = new Uri($"/CustomLibrary/Themes/{value}.xaml", UriKind.Relative) // Название словаря хранится в переменной value
                };

                //$"pack://application:,,,/CustomLibrary;component/Themes/{value}.xaml"

                Current.Resources.MergedDictionaries.RemoveAt(0); // Убираем старый словарь
                Current.Resources.MergedDictionaries.Insert(0, dict); // Добавляем новый


                /*var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value); // Сохранение названия нашего словаря на рабочий стол */
               
            }
        }
        public App()
        {
            InitializeComponent();

           /* var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // При открытии подгрузка из текстового файла названия нашей темы
            if (File.Exists($"{desktop}\\theme.txt"))
            {
                Theme = File.ReadAllText($"{desktop}\\theme.txt");
            }*/
        }
    }
}
