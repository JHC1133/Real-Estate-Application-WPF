using ModernRealEstates.Core;
using ModernRealEstates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernRealEstates.MVVM.ViewModel
{
    internal class ShowViewModel : Core.ViewModel
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

        public ShowViewModel(INavigationService navigation)
        {
            Navigation = navigation;
        }
    }
}
