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
using GameStoreBusiness;
using System.Diagnostics;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public decimal userID;
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CRUD_UserMethods userMethods = new CRUD_UserMethods();
            userMethods.selectedReset();
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
                LoginMethods loginMethods = new LoginMethods();
                userID = loginMethods.emailCheck(emailText.Text, passwordTxt.Password);
                if (userID > 0)
                {
                    Library libraryWindow = new Library();
                    App.Current.MainWindow = libraryWindow;
                    this.Close();
                    libraryWindow.Show();
                }
                else
                {
                    invalidLoginTxt.Text = "Login Failed - Invalid Username or Password";
                }
            }
            else if (clickBtn.Content.ToString() == "Admin") // Need to add extra parameters for adding the correct user information
            {
                Admin AdminWindow = new Admin();
                App.Current.MainWindow = AdminWindow;
                this.Close();
                AdminWindow.Show();
            }
        }

        private void emailText_TextChanged(object sender, TextChangedEventArgs e)
        {
            invalidLoginTxt.Text = "";
        }

        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            invalidLoginTxt.Text = "";
        }
    }
}
