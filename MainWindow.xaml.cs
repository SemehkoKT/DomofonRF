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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Проект2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static int ID;

        private void Button_auth_Click(object sender, RoutedEventArgs e)
        {
        }

        private void LogTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MWindow a = new MWindow();
            //a.Owner = this;
            //a.Show();
            //this.Hide();
            if (!string.IsNullOrEmpty(loginTextBox.Text))
            {
                if (!string.IsNullOrEmpty(passwordTextBox.Password))
                {
                    IQueryable <Пользователь> пользователь_list = DataBase1.GetContext().Пользователь.Where(p => p.Login == loginTextBox.Text && p.Password == passwordTextBox.Password);
                    if (пользователь_list != null)
                    {
                        MessageBox.Show("Добро пожаловать, дорогой пользователь!");
                        Пользователь auth = пользователь_list.First();
                        ID = (int)auth.Код_должности;
                        GLWindow mWindow = new GLWindow(auth);
                        mWindow.Owner = this;
                        mWindow.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Неверный логин или пароль.");

                }
            }

        }
    }
}
