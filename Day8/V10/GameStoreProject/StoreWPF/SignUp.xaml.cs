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
using GameStoreBusiness;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        CRUD_UserMethods _crudMethods = new CRUD_UserMethods();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            if(clickBtn.Name == "loginPageBtn")
            {
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                this.Close();
                mainWindow.Show();
            }
            else if (clickBtn.Name == "signUpBtn")
            {
                if (_crudMethods.Create(nameText.Text, usernameTxt.Text, emailTxt.Text, passwordText.Password))
                {
                    responseTxt.Text = "Account Created Successfully!";
                }
                else
                {
                    responseTxt.Text = "Username or Email already in use";
                }
            }
        }

        private void Txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            responseTxt.Text = "";
        }
    }
}
