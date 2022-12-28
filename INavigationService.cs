using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Проект2
{
    internal interface INavigationService<T> where T : CatalogBooksViewModel
    {
        void ShowView(T viewModel);
        event EventHandler CloseView;
    }
}
