﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register(nameof(ImagePath), typeof(string),
            typeof(UserControl),
            new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty SaveDirectoryProperty =
            DependencyProperty.Register(nameof(SaveDirectory), typeof(string), typeof(UserControl), new PropertyMetadata(string.Empty));

        public string SaveDirectory
        {
            get => (string)GetValue(SaveDirectoryProperty);
            set => SetValue(ImagePathProperty, value);
        }

        public string ImagePath
        {
            get => (string)GetValue(ImagePathProperty);
            set
            {
                string oldPathImage = (string)GetValue(ImagePathProperty);
                SetValue(ImagePathProperty, value);
                if (!string.IsNullOrEmpty(oldPathImage))
                {
                    try
                    {
                        File.Delete(oldPathImage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        SetValue(ImagePathProperty, oldPathImage);
                        return;
                    }
                }
            }
        }

        private void _delBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить изображение?", "Подтверждение", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ImagePath = string.Empty;
            }
        }

        private void _cIborder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Images|*.jpg;*.jpeg;*.png;";
                if (openFileDialog.ShowDialog() == true)
                {
                    string pathSave = $"{SaveDirectory}/{DateTime.Now.ToBinary()}{System.IO.Path.GetExtension(openFileDialog.FileName)}";
                    try
                    {
                        File.Copy(openFileDialog.FileName, pathSave);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    ImagePath = pathSave;
                }
            }
        }


        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
