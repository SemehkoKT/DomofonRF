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

namespace Проект2
{
    /// <summary>
    /// Логика взаимодействия для AddEditBookWindow.xaml
    /// </summary>
    public partial class AddEditBookWindow : Window
    {
        public AddEditBookWindow()
        {
            InitializeComponent();
        }
        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (DataContext as AddEditBookViewModel).CommandExecuted += AddEditBookWindow_CommandExecuted;
        }
        private void AddEditBookWindow_CommandExecuted(object obj, CommandExecutedEventsArgs commandExecuted)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
