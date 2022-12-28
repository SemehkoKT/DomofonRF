using Проект2.Pages.mainWindowPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Проект2.views
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private void PropertyChange(string property) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public event PropertyChangedEventHandler PropertyChanged;

        public Пользователь Пользователь { get; private set; }
        public ObservableCollection<Page> PageCollection { get; private set; }
        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    PropertyChange("CurrentPage");
                }
            }
        }
        public MainWindowViewModel(Пользователь пользователь)
        {
            Пользователь = пользователь;
            PageCollection = new ObservableCollection<Page>();
            if (пользователь.Должность.Код_должности == 1)
            {
                PageCollection.Add(new Page1());
                PageCollection.Add(new Page2());
                PageCollection.Add(new Page3());
            }
            else if (пользователь.Должность.Код_должности == 2)
            {
                PageCollection.Add(new Page1());
                PageCollection.Add(new Page2());
            }
            CurrentPage = PageCollection[0];
        }
    }
}
