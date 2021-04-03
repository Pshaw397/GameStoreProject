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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private CRUD_GameMethods _gameManager = new CRUD_GameMethods();
        public Admin()
        {
            InitializeComponent();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            ListBoxGames.ItemsSource = _gameManager.RetrieveAll();
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
            MainWindow mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }

        private void PopulateGameFields()
        {
            if (_gameManager.gameUpdate != null)
            {
                DateTime dateTime = _gameManager.gameUpdate.ReleaseDate;
                gameDescTxt.Text = _gameManager.gameUpdate.Description;
                pubNameTxt.Text = $"Publisher: {_gameManager.gameUpdate.Publisher}";
                releaseTxt.Text = $"Release Date: {dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
                devNameTxt.Text = $"Developers: {_gameManager.developerList[0]}";
                genreTxt.Text = $"Genres: {_gameManager.genreList[0]}";
                for (int i = 1; i < _gameManager.developerList.Count; i++)
                {
                    devNameTxt.Text += ", " + _gameManager.developerList[i];
                }
                for (int i = 1; i < _gameManager.genreList.Count; i++)
                {
                    genreTxt.Text += ", " + _gameManager.genreList[i];
                }

            }
        }
    }
}
