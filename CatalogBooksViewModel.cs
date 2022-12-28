using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Проект2
{
    public enum TypeDialog
    {
        InfoType,
        ErrorType,
        ConfirmationType
    }
    public enum DialogResult
    {
        Ok,
        Yes,
        No
    }
    public enum CommandExecutedResult
    {
        Ok,
        Error
    }

    public class CommandExecutedEventsArgs : EventArgs
    {
       

        public CommandExecutedResult CommandExecutedResult
        {
            get; private set;
        }

        public string ErrorMessage { get; private set; }

        public CommandExecutedEventsArgs(CommandExecutedResult commandExecutedResult, string errorMessage = null)
        {
            CommandExecutedResult = commandExecutedResult;
            ErrorMessage = errorMessage;
        }
    }

    public class CatalogBooksViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SectionFilter> sectionFilters { get; private set; }
        INavigationService<AddEditBookViewModel> _navigationService =
            ServiceContainer.Instance.GetService<INavigationService<AddEditBookViewModel>>();

        private Command _editCommand;
        public Command EditComamnd
        {
            get
            {
                return _editCommand ?? (_editCommand = new Command(obj =>
                {
                    _navigationService.ShowView(new AddEditBookViewModel(obj as Материал));
                    _navigationService.CloseView += (o, e) => UpdateBookList();
                }, obj => obj != null));
            }
        }

        private Command _addCommand;
        public Command AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(obj =>
                {
                    _navigationService.ShowView(new AddEditBookViewModel());
                    _navigationService.CloseView += (o, e) => UpdateBookList();
                }, obj => true));
            }
        }


        public ObservableCollection<SectionFilter> SectionFilters { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Материал> Материал { get; set; }

        public delegate void CommandExecutedEventHandler(object obj, CommandExecutedEventsArgs commandExecuted);
        public event CommandExecutedEventHandler CommandExecuted;
        protected void OnCommandExecuted(CommandExecutedResult commandExecutedResult, string errorMessage = null)
            => CommandExecuted?.Invoke(this, new CommandExecutedEventsArgs(commandExecutedResult, errorMessage));
        private Visibility _administratorAccess = Visibility.Hidden;
        public Visibility AdministratorAccess
        {
            get => _administratorAccess;
            private set
            {
                if (value != _administratorAccess)
                {
                    _administratorAccess = value;
                    PropertyChange();
                }
            }
        }

        public void PropertyChange([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Visibility _resetFilterActive;
        public Visibility ResetFilterActive
        {
            get => _resetFilterActive;
            private set
            {
                if (value != _resetFilterActive)
                {
                    _resetFilterActive = value;
                    PropertyChange("ResetFilterActive");
                }
            }
        }
        private Command _removeCommand;
        public Command RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new Command(obj =>
                {
                    if (MessageBox.Show("Вы уверны, что хотите удалить запись?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.Yes)
                    {
                        Материал материал = obj as Материал;
                        DataBase1.GetContext().Материал.Remove(материал);
                        DataBase1.GetContext().SaveChanges();
                        UpdateBookList();
                    }

                }, obj => obj != null));
            }
        }

        internal interface IDialogService
        {
            DialogResult ShowDialog(string message, string caption = "Диалоговое окно", TypeDialog typeDialog = TypeDialog.InfoType);
        }
        IDialogService _dialogService;

        public CatalogBooksViewModel()
        {
            AdministratorAccess = Visibility.Visible;

            Материал = new ObservableCollection<Материал>();
            SectionFilters = new ObservableCollection<SectionFilter>(DataBase1.GetContext().Фильтр.Select(p => new SectionFilter() { Фильтр = p }));
            UpdateBookList();
        }

        private int _currentCountElements = 0;
        private int _countAllElements = 0;
        public int CurrentCountElements
        {
            get => _currentCountElements;
            private set
            {
                if (_currentCountElements != value)
                {
                    _currentCountElements = value;
                    PropertyChange("CurrentCountElements");
                }
            }
        }
        public int CountAllElements
        {
            get => _countAllElements;
            private set
            {
                if (_countAllElements != value)
                {
                    _countAllElements = value;
                    PropertyChange("CountAllElements");
                }
            }
        }

        public int SelectedSort { get; set; } = 0;
        public string SearchString { get; set; } = "";
        public void UpdateBookList()
        {
            try
            {
                ResetFilterActive = Visibility.Hidden;

                Материал.Clear();
                List<Фильтр> материалFilter = SectionFilters.Where(p => p.IsChecked).Select(p => p.Фильтр).ToList();
                List<Материал> материал = DataBase1.GetContext().Материал.ToList();
                CountAllElements = материал.Count();
                //Поиск
                if (!String.IsNullOrWhiteSpace(SearchString))
                    материал = материал.Where(p => p.Название.Contains(SearchString.Trim())).ToList();
                //Фильтрация
                if (материалFilter.Count != 0)
                {                       
                    материал = материал.Where(p => p.Фильтр1.Название == материалFilter[0].Название).ToList();
                    if (материалFilter.Count == 1 || материалFilter.Count != 1)
                    {
                        ResetFilterActive = Visibility.Visible;
                    }
                }

                switch (SelectedSort)
                {
                    case 0:
                        материал = материал.OrderBy(p => p.Количество).ToList();
                        break;
                    case 1:
                        материал = материал.OrderByDescending(p => p.Количество).ToList();
                        break;
                    case 2:
                        материал = материал.OrderBy(p => p.Название).ToList();
                        break;
                    case 3:
                        материал = материал.OrderByDescending(p => p.Название).ToList();
                        break;
                    default:
                        break;
                }
                CurrentCountElements = материал.Count();

                if (материал.Count != 0)
                {
                    foreach (Материал материал1 in материал)
                        Материал.Add(материал1);
                }
                else MessageBox.Show("Ничего не найдено", "Результат поиска");


            }
            catch (Exception e)
            {
                MessageBox.Show("Возникла ошибка: " + e.Message);
            }
        }

        public void ResetFilters()
        {
            ResetFilterActive = Visibility.Hidden;
            foreach (SectionFilter sectionFilter in SectionFilters)
            {
                sectionFilter.IsChecked = false;
            }
            UpdateBookList();
        }
    }
}
