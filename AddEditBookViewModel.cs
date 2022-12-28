using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Проект2
{
    class AddEditBookViewModel : CatalogBooksViewModel
    {
        public string Title;

        private Материал _материал;
        public Материал Материал
        {
            get => _материал;
            set
            {
                if (_материал != null)
                {
                    _материал = value;
                    PropertyChange();
                }
            }
        }

        public AddEditBookViewModel()
        {
            _материал = new Материал();
            _isAddМатериал = true;

            Title = "Добавить";

            Фильтрs = DataBase1.GetContext().Фильтр.ToList();
        }

        public AddEditBookViewModel(Материал материал)
        {
            if (материал == null)
            {
                _материал = new Материал();
                _isAddМатериал = true;
                Title = "Добавить";
            }
            else
            {
                _материал = материал;
                Title = "Редактировать";
            }

            Фильтрs = DataBase1.GetContext().Фильтр.ToList();
        }

        private bool _isAddМатериал;
        private Command _saveCommand;

        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(obj =>
                {
                    if (_isAddМатериал)
                    {
                        DataBase1.GetContext().Материал.Add(Материал);
                        _isAddМатериал = false;
                    }
                    try
                    {
                        DataBase1.GetContext().SaveChanges();
                        OnCommandExecuted(CommandExecutedResult.Ok);
                    }
                    catch (Exception ex)
                    {
                        OnCommandExecuted(CommandExecutedResult.Error, ex.Message);
                    }
                }, obj => obj != null));
            }
        }

        public List<Фильтр> Фильтрs { get; private set; }
    }
}
