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
    /// Interaction logic for DevCrud.xaml
    /// </summary>
    public partial class DevCrud : Window
    {
        private CRUD_DeveloperMethods _genreManager = new CRUD_DeveloperMethods();
        public DevCrud()
        {
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            ListBoxDevs.ItemsSource = _genreManager.RetrieveAll();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox calledBox = (ListBox)sender;
            if (calledBox.Name == "ListBoxDevs")
            {
                if (ListBoxDevs.SelectedItem != null)
                {
                    _genreManager.SetSelectedGame(ListBoxDevs.SelectedItem.ToString());
                    PopulateGenreFields();
                }
            }
        }

        private void PopulateGenreFields()
        {
            if (_genreManager.developerUpdate != null)
            {
                devUpdateText.Text = _genreManager.developerUpdate.DeveloperName;
                devDeleteBox.Text = _genreManager.developerUpdate.DeveloperName;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btnClick = (Button)sender;
            if (btnClick.Name == "createBtn")
            {
                if (devCreateBox.Text != "")
                {
                    if (_genreManager.Create(devCreateBox.Text))
                    {
                        MessageBox.Show("Developer Created Successfully");
                        devCreateBox.Text = "";
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
                if (devDeleteBox.Text != "")
                {
                    _genreManager.Delete(_genreManager.developerUpdate.DeveloperName);
                    MessageBox.Show("Developer Deleted Successfully");
                    devCreateBox.Text = "";
                    devDeleteBox.Text = "";
                    devUpdateText.Text = "";
                    PopulateListBox();
                }
                else
                {
                    MessageBox.Show("Not Genre Select - Select genre to delete");
                }
            }
            else if (btnClick.Name == "updateBtn")
            {
                if (devUpdateText.Text != "")
                {
                    if (_genreManager.Update(_genreManager.developerUpdate.DeveloperName, devUpdateText.Text))
                    {
                        MessageBox.Show("Developer Update Successfully");
                        devCreateBox.Text = "";
                        devDeleteBox.Text = "";
                        devUpdateText.Text = "";
                        PopulateListBox();
                    }
                    else
                    {
                        MessageBox.Show("New Developer entered already exists");
                    }
                }
                else
                {
                    MessageBox.Show("Not Developer Select - Select genre to update");
                }
            }

        }
    }
}
