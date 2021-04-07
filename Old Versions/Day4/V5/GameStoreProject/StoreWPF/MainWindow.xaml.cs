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

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            if(clickBtn.Content.ToString() == "Sign Up!")
            {
                SignUp signUpWindow = new SignUp();
                App.Current.MainWindow = signUpWindow;
                this.Close();
                signUpWindow.Show();
            }
            else if (clickBtn.Content.ToString() == "Login") // Need to add extra parameters for adding the correct user information
            {
                Library libraryWindow = new Library();
                App.Current.MainWindow = libraryWindow;
                this.Close();
                libraryWindow.Show();
            }
            else if (clickBtn.Content.ToString() == "Admin") // Need to add extra parameters for adding the correct user information
            {
                Admin AdminWindow = new Admin();
                App.Current.MainWindow = AdminWindow;
                this.Close();
                AdminWindow.Show();
            }
        }
    }
}
