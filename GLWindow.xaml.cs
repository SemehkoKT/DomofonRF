using Проект2.views;
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
    /// Логика взаимодействия для GLWindow.xaml
    /// </summary>
    public partial class GLWindow : Window
    {
        public GLWindow(Пользователь пользователь)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(пользователь);
        }
        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();

        private void Window_Closed(object sender, EventArgs e) => this.Owner.Show();

    }
}
