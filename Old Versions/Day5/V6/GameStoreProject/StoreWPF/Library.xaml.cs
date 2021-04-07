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
    /// Interaction logic for Library.xaml
    /// </summary>
    public partial class Library : Window
    {
        private CRUD_GameMethods _gameManager = new CRUD_GameMethods();
        
        public Library()
        {
            InitializeComponent();
            PopulateListBox();

            LoginMethods loginMethods = new LoginMethods();
            welcomeUserBox.Text = loginMethods.currentUser.Username;
        }
        private void PopulateListBox()
        {
            ListBoxGames.ItemsSource = _gameManager.RetrieveAllLibrary(); // THIS NEEDS TO BE CHANGED TO ONLY INCLUDE GAMES OWNED (NEED TO RETRIEVE CURRENT USERID)
            // TRY SETTING "WELCOME" string to test that
        }

        private void ListBoxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxGames.SelectedItem != null)
            {
                _gameManager.SetSelectedGame(ListBoxGames.SelectedItem.ToString());
                PopulateGameFields();
            }
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

        private void PopulateGameFields()
        {
            if (_gameManager.gameUpdate != null)
            {
                DateTime dateTime = _gameManager.gameUpdate.ReleaseDate;
                gameNameBox.Text = _gameManager.gameUpdate.Name;
                descriptionBox.Text = _gameManager.gameUpdate.Description;
                publisherBox.Text = $"Publisher: {_gameManager.gameUpdate.Publisher}";
                releaseDateBox.Text = $"Release Date: {dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
                developerBox.Text = $"Developers: {_gameManager.developerList[0]}";
                genreBox.Text = $"Genres: {_gameManager.genreList[0]}";
                for (int i = 1; i < _gameManager.developerList.Count; i++)
                {
                    developerBox.Text += ", " + _gameManager.developerList[i];
                }
                for (int i = 1; i < _gameManager.genreList.Count; i++)
                {
                    genreBox.Text += ", " + _gameManager.genreList[i];
                }

            }
        }
    }
}
