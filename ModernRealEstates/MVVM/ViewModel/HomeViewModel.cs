using ModernRealEstates.Core;
using ModernRealEstates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernRealEstates.MVVM.ViewModel
{
    internal class HomeViewModel : Core.ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }


        // Used for button on HomeView window
        public RelayCommand NavigateToSettingsViewCommand { get; set; }

        public HomeViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToSettingsViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);
        }
    }
}
