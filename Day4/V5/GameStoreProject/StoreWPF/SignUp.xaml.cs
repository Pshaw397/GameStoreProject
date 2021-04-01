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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            MainWindow mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }
    }
}
