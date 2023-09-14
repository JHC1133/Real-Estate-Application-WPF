using ModernRealEstates.Core;
using ModernRealEstates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernRealEstates.MVVM.ViewModel
{
    internal class MainViewModel : Core.ViewModel
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

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToSettingsViewCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToHomeCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            NavigateToSettingsViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);

        }
    }
}
