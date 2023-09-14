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
        public RelayCommand NavigateToShowViewCommand { get; set; }
        public RelayCommand NavigateToAddViewCommand { get; set; }
        public RelayCommand NavigateToChangeViewCommand { get; set; }
        public RelayCommand NavigateToDeleteViewCommand { get; set; }
        public RelayCommand NavigateToSettingsViewCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToHomeCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            NavigateToSettingsViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);
            NavigateToShowViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<ShowViewModel>(); }, canExecute: o => true);
            NavigateToAddViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<AddViewModel>(); }, canExecute: o => true);
            NavigateToChangeViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<ChangeViewModel>(); }, canExecute: o => true);
            NavigateToDeleteViewCommand = new RelayCommand(execute: o => { Navigation.NavigateTo<DeleteViewModel>(); }, canExecute: o => true);
        }
    }
}
