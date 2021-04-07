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
    /// Interaction logic for GenreCrud.xaml
    /// </summary>
    public partial class GenreCrud : Window
    {
        private CRUD_GenreMethods _genreManager = new CRUD_GenreMethods();
        public GenreCrud()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            ListBoxGenres.ItemsSource = _genreManager.RetrieveAll();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox calledBox = (ListBox)sender;
            if (calledBox.Name == "ListBoxGenres")
            {
                if (ListBoxGenres.SelectedItem != null)
                {
                    _genreManager.SetSelectedGame(ListBoxGenres.SelectedItem.ToString());
                    PopulateGenreFields();
                    Debug.WriteLine("Test");
                }
            }
        }

        private void PopulateGenreFields()
        {
            if (_genreManager.GenreUpdate != null)
            {
                genreUpdateText.Text = _genreManager.GenreUpdate.GenreName;
                genreNameDeleteBox.Text = _genreManager.GenreUpdate.GenreName;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btnClick = (Button)sender;
            if(btnClick.Name == "createBtn")
            {
                if(genreCreateBox.Text != "")
                {
                    if (_genreManager.Create(genreCreateBox.Text))
                    {
                        MessageBox.Show("Genre Created Successfully");
                        genreCreateBox.Text = "";
                        genreNameDeleteBox.Text = "";
                        genreUpdateText.Text = "";
                        PopulateListBox();
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Value Entered - Value not added");
                    }
                }
                else
                {
                    MessageBox.Show("Input box empty - input valid value");
                }
            }
            else if (btnClick.Name == "deleteBtn")
            {
                if (genreNameDeleteBox.Text != "")
                {
                    _genreManager.Delete(_genreManager.GenreUpdate.GenreName);
                    MessageBox.Show("Genre Deleted Successfully");
                    genreCreateBox.Text = "";
                    genreNameDeleteBox.Text = "";
                    genreUpdateText.Text = "";
                    PopulateListBox();
                }
                else
                {
                    MessageBox.Show("Not Genre Select - Select genre to delete");
                }
            }
            else if (btnClick.Name == "updateBtn")
            {
                if (genreUpdateText.Text != "")
                {
                    if(_genreManager.Update(_genreManager.GenreUpdate.GenreName, genreUpdateText.Text))
                    {
                        MessageBox.Show("Genre Update Successfully");
                        genreCreateBox.Text = "";
                        genreNameDeleteBox.Text = "";
                        genreUpdateText.Text = "";
                        PopulateListBox();
                    }
                    else
                    {
                        MessageBox.Show("New Genre entered already exists");
                    }
                }
                else
                {
                    MessageBox.Show("Not Genre Select - Select genre to update");
                }
            }

        }
    }
}
