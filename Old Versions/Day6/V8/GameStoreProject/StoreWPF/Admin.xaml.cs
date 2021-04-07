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
using System.Diagnostics;

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
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickBtn = (Button)sender;
            if(clickBtn.Name == "logOutBtn")
            {
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                this.Close();
                mainWindow.Show();
            }
            else if (clickBtn.Name == "saveBtn")
            {
                _gameManager.Update() 
            }
            else if (clickBtn.Name == "genreCrudBtn")
            {
                GenreCrud crudWindow = new GenreCrud();
                App.Current.MainWindow = crudWindow;
                crudWindow.Show();
            }
            else if (clickBtn.Name == "devCrudBtn")
            {
                DevCrud crudWindow = new DevCrud();
                App.Current.MainWindow = crudWindow;
                crudWindow.Show();
            }

        }

        private void PopulateGameFields()
        {
            if (_gameManager.gameUpdate != null)
            {
                List<string> emptyList = new List<string>();
                DateTime dateTime = _gameManager.gameUpdate.ReleaseDate;
                gameDescTxt.Text = _gameManager.gameUpdate.Description;
                gameNameTxt.Text = _gameManager.gameUpdate.Name;
                pubNameTxt.Text = _gameManager.gameUpdate.Publisher;
                releaseTxt.Text = $"Release Date: {dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
                //devNameTxt.Text = $"Developers: {_gameManager.developerList[0]}";
                //genreTxt.Text = $"Genres: {_gameManager.genreList[0]}";
                //for (int i = 1; i < _gameManager.developerList.Count; i++)
                //{
                //    devNameTxt.Text += ", " + _gameManager.developerList[i];
                //}
                //for (int i = 1; i < _gameManager.genreList.Count; i++)
                //{
                //    genreTxt.Text += ", " + _gameManager.genreList[i];
                //}

                genreListBox.ItemsSource = emptyList;
                devListBox.ItemsSource = emptyList;
                genreListBox.ItemsSource = _gameManager.genreList;
                devListBox.ItemsSource = _gameManager.developerList;

            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox calledBox = (ListBox)sender;
            if(calledBox.Name == "ListBoxGames")
            {
                if (ListBoxGames.SelectedItem != null)
                {
                    _gameManager.SetSelectedGame(ListBoxGames.SelectedItem.ToString());
                    PopulateGameFields();
                }
            }
            //else if (calledBox.Name == "genreListBox")
            //{
            //    if (genreListBox.SelectedItem != null)
            //    {
            //        genreSelected = genreListBox.SelectedItem.ToString();
            //    }
            //}
            //else if (calledBox.Name == "devListBox")
            //{
            //    if (devListBox.SelectedItem != null)
            //    {
            //        devNameTxt.Text = devListBox.SelectedItem.ToString();
            //    }
            //}

        }
    }
}
