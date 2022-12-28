using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
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

namespace Проект2.Pages.mainWindowPages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        CatalogBooksViewModel _catalogBooksViewModel;

        public Page1()
        { 
            InitializeComponent();

            _catalogBooksViewModel = new CatalogBooksViewModel();
            DataContext = _catalogBooksViewModel;
        }
        private void SearchTextBox_textChanged(object sender, TextChangedEventArgs e) => _catalogBooksViewModel.UpdateBookList();
        private void Filter_Checked(object sender, RoutedEventArgs e) => _catalogBooksViewModel.UpdateBookList();
        private void Filter_UnChecked(object sender, RoutedEventArgs e)
        {
            if (_catalogBooksViewModel.ResetFilterActive == Visibility.Visible)
                _catalogBooksViewModel.UpdateBookList();
        }
        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            _catalogBooksViewModel.ResetFilters();
        }

        private void SortComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            _catalogBooksViewModel.UpdateBookList();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (dataGridCatalogBooks.SelectedItem as Материал).Код_материала;

            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                DataBase1.GetContext().Материал.Remove(DataBase1.GetContext().Материал.Where(p => p.Код_материала == id).First());
                DataBase1.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
               
        }
        

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
         
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           //this.Close();

        }
    } 
}
