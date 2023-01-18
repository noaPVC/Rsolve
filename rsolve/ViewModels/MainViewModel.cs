using Rsolve.Core;
using System.Windows.Input;

namespace Rsolve.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region Class Properties

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private bool _isShowTextTest = false;

        public bool IsShowTextTest
        {
            get => _isShowTextTest;
            set 
            {
                _isShowTextTest = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Class Commands

        public ICommand ShowTextCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            ShowTextCommand = new CallbackCommand(e =>
            {
                IsShowTextTest = !IsShowTextTest;
            });
        }
    }
}
