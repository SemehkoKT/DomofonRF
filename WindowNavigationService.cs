using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Проект2
{
    class WindowNavigationService<T, P> : INavigationService<T> where T : CatalogBooksViewModel where P : Window, new()
    {
        public P Window { get; private set; }

        public event EventHandler CloseView
        {
            add
            {
                Window.Closed += value;
            }
            remove
            {
                Window.Closed -= value;
            }
        }

        public void ShowView(T viewModel)
        {
            Window = new P();
            ViewModel = viewModel;
            Window?.Show();
        }



        public T ViewModel
        {
            get
            {
                if (Window != null && Window.DataContext is T)
                    return Window.DataContext as T;
                else return null;
            }
            set
            {
                if (Window != null && value is T)
                    Window.DataContext = value;
            }
        }

    }
}
