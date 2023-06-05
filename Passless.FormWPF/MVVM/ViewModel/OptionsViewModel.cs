using System;
using Passless.FormWPF.Core;
using Passless.FormWPF.MVVM.View;

namespace Passless.FormWPF.MVVM.ViewModel
{
    class OptionsViewModel : ObservableObject
    {
        public RelayCommand RepositoryViewCommand { get; set; }
        public RelayCommand AppearanceViewCommand { get; set; }

        public OptionsRepositoryViewModel Reposiroty { get; set; }
        public OptionsAppearanceViewModel Appearance { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public OptionsViewModel() 
        { 
            Reposiroty = new OptionsRepositoryViewModel();
            Appearance = new OptionsAppearanceViewModel();
            
            CurrentView = Reposiroty;

            RepositoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = Reposiroty;
            });

            AppearanceViewCommand = new RelayCommand(o =>
            {
                CurrentView = Appearance;
            });
        }
    }
}
