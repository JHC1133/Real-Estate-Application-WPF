using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernRealEstates.MVVM.View
{
    /// <summary>
    /// Interaction logic for ShowView.xaml
    /// </summary>
    public partial class ShowView : UserControl
    {
        public ShowView()
        {
            InitializeComponent();
            DataContext = SharedData.Instance;
            estateListBox.ItemsSource = SharedData.Instance.EstateManager.List;
        }

        private void deleteSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (estateListBox.SelectedItem != null)
            {
                SharedData.Instance.EstateManager.DeleteAt(estateListBox.SelectedIndex);
                estateListBox.Items.Refresh();

                foreach (Estate estate in SharedData.Instance.EstateManager.List)
                {
                    Debug.WriteLine($"Address: {estate.Address.Street}, {estate.Address.City}, {estate.Address.Zipcode}");
                }
                estateImage.Source = null;
            }
        }

        private void estateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (estateListBox.SelectedItem is Estate selectedEstate)
            {
                estateImage.Source = new BitmapImage(new Uri(selectedEstate.ImageFilePath));
            }
        }
    }
}
