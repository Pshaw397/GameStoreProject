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
    /// Interaction logic for GenreCrud.xaml
    /// </summary>
    public partial class GenreCrud : Window
    {
        private CRUD_GenreMethods _genreManager = new CRUD_GenreMethods();
        public GenreCrud()
        {
            InitializeComponent();
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            ListBoxGenres.ItemsSource = _genreManager.RetrieveAll();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {

        }
        // NEED TO ADD FUNCTIONALITY FOR ALL BUTTONS + FILL THE TEXTBLOCKS WITH THE SELECTED DETAILS
    }
}
