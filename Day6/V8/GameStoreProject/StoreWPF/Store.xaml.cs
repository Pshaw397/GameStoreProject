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
using StoreData;
using System.Diagnostics;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        private CRUD_GameMethods _gameManager = new CRUD_GameMethods();
        CRUD_PurchaseMethods purchaseMethods = new CRUD_PurchaseMethods();
        User selectedUser = new User();
        public Store()
        {
            InitializeComponent();
            PopulateListBox();
            LibraryMethods libraryMethods = new LibraryMethods();
            selectedUser = libraryMethods.selectedUser();
        }
        private void PopulateListBox()
        {
            ListBoxGames.ItemsSource = _gameManager.RetrieveAllStore(selectedUser.UserId);
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            if (clickBtn.Content.ToString() == "Library")
            {
                Library libraryWindow = new Library();
                App.Current.MainWindow = libraryWindow;
                this.Close();
                libraryWindow.Show();
            }
            else if (clickBtn.Content.ToString() == "Log Out")
            {
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                this.Close();
                mainWindow.Show();
            }
            else if (clickBtn.Content.ToString() == "Purchase")
            {
                Debug.WriteLine((int)selectedUser.UserId + " " + (int)_gameManager.gameUpdate.GameId);
                purchasedBox.Visibility = Visibility.Visible;
                buyBtn.IsEnabled = false;
                //purchaseMethods.Create();
            }
        }

        private void ListBoxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxGames.SelectedItem != null)
            {
                _gameManager.SetSelectedGame(ListBoxGames.SelectedItem.ToString());
                PopulateGameFields();
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
                priceBox.Text = $"£{_gameManager.gameUpdate.Price.ToString()}";
                ImageBrush ib = new ImageBrush();
                BitmapImage bmi = new BitmapImage(new Uri(_gameManager.gameUpdate.CoverImgPath, UriKind.Relative));
                ib.ImageSource = bmi;
                coverImg.Fill = ib;
                for (int i = 1; i < _gameManager.developerList.Count; i++)
                {
                    developerBox.Text += ", " + _gameManager.developerList[i];
                }
                for (int i = 1; i < _gameManager.genreList.Count; i++)
                {
                    genreBox.Text += ", " + _gameManager.genreList[i];
                }
                gameNameBox.Visibility = Visibility.Visible;
                descriptionBox.Visibility = Visibility.Visible;
                publisherBox.Visibility = Visibility.Visible;
                releaseDateBox.Visibility = Visibility.Visible;
                developerBox.Visibility = Visibility.Visible;
                genreBox.Visibility = Visibility.Visible;
                coverImg.Visibility = Visibility.Visible;
                buyBtn.Visibility = Visibility.Visible;
                priceBox.Visibility = Visibility.Visible;
                buyBtn.IsEnabled = true;

            }
        }
    }
}
