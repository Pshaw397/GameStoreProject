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
using Microsoft.Win32;
using StoreData;

namespace StoreWPF
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private CRUD_GameMethods _gameManager = new CRUD_GameMethods();
        private CRUD_GameGenreMethods _GameGenreManager = new CRUD_GameGenreMethods();
        private CRUD_GameDeveloperMethods _GameDevManager = new CRUD_GameDeveloperMethods();
        string path;
        decimal oldGenreID, newGenreID, oldDevID, newDevID;
        public Admin()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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
                if(imgPathText.Text != "")
                {
                    string decStr = priceTxt.Text;
                    decimal dec = Convert.ToDecimal(decStr);
                    DateTime selectedDate = releaseDatePicker.SelectedDate.Value;
                    _gameManager.Update(_gameManager.gameUpdate.Name, gameNameTxt.Text, gameDescTxt.Text, imgPathText.Text, dec, pubNameTxt.Text, selectedDate.Year, selectedDate.Month, selectedDate.Day);

                    if (comboGenres.SelectedValue != null && comboSelectedGenres.SelectedValue != null)
                    {
                        _GameGenreManager.Update(_gameManager.gameUpdate.GameId, oldGenreID, newGenreID);
                    }
                    if (comboDevs.SelectedValue != null && comboSelectedDevs.SelectedValue != null)
                    {
                        _GameDevManager.Update(_gameManager.gameUpdate.GameId, oldDevID, newDevID);
                    }
                    _gameManager.SetSelectedGame(gameNameTxt.Text);
                    PopulateGameFields();
                    PopulateListBox();
                    comboGenres.SelectedValue = "";
                    comboDevs.SelectedValue = "";
                }
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
                priceTxt.Text = _gameManager.gameUpdate.Price.ToString();
                releaseText.Text = $"Release Date: {dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
                releaseDatePicker.SelectedDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
                imgPathText.Text = _gameManager.gameUpdate.CoverImgPath;
                ImageBrush ib = new ImageBrush();
                BitmapImage bmi = new BitmapImage(new Uri(_gameManager.gameUpdate.CoverImgPath, UriKind.Relative));
                ib.ImageSource = bmi;
                coverImg.Fill = ib;

                comboSelectedDevs.ItemsSource = emptyList;
                comboSelectedDevs.ItemsSource = _gameManager.developerList;

                comboSelectedGenres.ItemsSource = emptyList;
                comboSelectedGenres.ItemsSource = _gameManager.genreList;

                using (var db = new GameMarketContext())
                {
                    var getGenresQuery = db.Genres;
                    var getDevsQuery = db.Developers;

                    List<string> genreList = new List<string>();
                    List<string> devList = new List<string>();
                    foreach (var item in getGenresQuery)
                    {
                        genreList.Add(item.GenreName);
                    }
                    foreach (var item in getDevsQuery)
                    {
                        devList.Add(item.DeveloperName);
                    }
                    comboGenres.ItemsSource = genreList;
                    comboDevs.ItemsSource = devList;

                    saveBtn.Visibility = Visibility.Visible;
                    gameNameTxt.Visibility = Visibility.Visible;
                    gameDescTxt.Visibility = Visibility.Visible;
                    pubNameTxt.Visibility = Visibility.Visible;
                    imgPathBox.Visibility = Visibility.Visible;
                    releaseText.Visibility = Visibility.Visible;
                    publisherBox.Visibility = Visibility.Visible;
                    priceTxt.Visibility = Visibility.Visible;
                    priceBox.Visibility = Visibility.Visible;
                    releaseDatePicker.Visibility = Visibility.Visible;
                    fileBtn.Visibility = Visibility.Visible;
                    comboGenres.Visibility = Visibility.Visible;
                    comboSelectedGenres.Visibility = Visibility.Visible;
                    comboDevs.Visibility = Visibility.Visible;
                    comboSelectedDevs.Visibility = Visibility.Visible;
                    curretnGenresBox.Visibility = Visibility.Visible;
                    newGenresBox.Visibility = Visibility.Visible;
                    currentDevsBox.Visibility = Visibility.Visible;
                    newDevsBox.Visibility = Visibility.Visible;
                    imgPathText.Visibility = Visibility.Visible;
                    testBtn.Visibility = Visibility.Visible;
                    coverImg.Visibility = Visibility.Visible;
                }

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

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = releaseDatePicker.SelectedDate.Value;
            releaseText.Text = $"Release Date: {selectedDate.Day}/{selectedDate.Month}/{selectedDate.Year}";
        }

        private void fileBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn_click = (Button)sender;
            if(btn_click.Name == "fileBtn")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.AddExtension = true;
                ofd.DefaultExt = ".";
                ofd.Filter = "Image Files(*.PNG; *.JPG)| *.PNG; *.JPG; | All files(*.*) | *.*";
                ofd.Multiselect = false;
                ofd.ShowDialog();
                path = ofd.FileName;
                imgPathText.Text = path;
            }
            else if (btn_click.Name == "testBtn")
            {
                if(imgPathText.Text != "")
                {
                    ImageBrush ib = new ImageBrush();
                    BitmapImage bmi = new BitmapImage(new Uri(path, UriKind.Relative));
                    ib.ImageSource = bmi;
                    coverImg.Fill = ib;
                }
                else
                {
                    MessageBox.Show("Input valid path!");
                }
            }
        }

        private void comboGenres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(var db = new GameMarketContext())
            {
                ComboBox selectedBox = (ComboBox)sender;
                if(selectedBox.Name == "comboSelectedGenres" && comboSelectedGenres.SelectedValue != null)
                {
                    var idQueryOld = db.Genres.Where(g => g.GenreName == comboSelectedGenres.SelectedValue.ToString()).FirstOrDefault();
                    oldGenreID = idQueryOld.GenreId;
                }
                else if(selectedBox.Name == "comboGenres" && comboGenres.SelectedValue != null)
                {
                    var idQueryNew = db.Genres.Where(g => g.GenreName == comboGenres.SelectedValue.ToString()).FirstOrDefault();
                    newGenreID = idQueryNew.GenreId;
                }
                else if (selectedBox.Name == "comboSelectedDevs" && comboSelectedDevs.SelectedValue != null)
                {
                    var idQueryOld = db.Developers.Where(g => g.DeveloperName == comboSelectedDevs.SelectedValue.ToString()).FirstOrDefault();
                    oldDevID = idQueryOld.DeveloperId;
                }
                else if (selectedBox.Name == "comboDevs" && comboDevs.SelectedValue != null)
                {
                    var idQueryNew = db.Developers.Where(g => g.DeveloperName == comboDevs.SelectedValue.ToString()).FirstOrDefault();
                    newDevID = idQueryNew.DeveloperId;
                }
            }

        }
    }
}
