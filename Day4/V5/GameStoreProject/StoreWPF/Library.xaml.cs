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
using System.Windows.Shapes;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Window
    {
        public Library()
        {
            InitializeComponent();
        }

        private void ListBoxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            if (clickBtn.Content.ToString() == "Store")
            {
                Store storeWindow = new Store();
                App.Current.MainWindow = storeWindow;
                this.Close();
                storeWindow.Show();
            }
            else if (clickBtn.Content.ToString() == "Log Out")
            {
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                this.Close();
                mainWindow.Show();
            }
        }
    }
}
