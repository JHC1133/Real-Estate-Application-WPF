using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        public AddView()
        {
            InitializeComponent();
            DataContext = SharedData.Instance;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
                    
            
        }

        private bool AddApartmentFormIsNotCompleted()
        {
            if (addStreetTextBox.Text == null || addCityTextBox.Text == null || addZipCodeTextBox.Text == null || addNrOfBathroomsTextBox.Text == null || 
                addNrOfBathroomsTextBox.Text == null)
            {
                MessageBox.Show("Please fill out the form!");
                return true;
            }
            return false;
        }

        private void addSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Estate estate;
            string buildingType = addComboBox.Text;

            if (buildingType == "Apartment")
            {
                estate = new Apartment(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, int.Parse(addNrOfBathroomsTextBox.Text), int.Parse(addNrOfBathroomsTextBox.Text), addHasGarageCheckBox.IsChecked.HasValue);
                //estateListBox.Items.Add(estate.EstateToText());
                SharedData.Instance.EstatesList.Add(estate);
            }
        }
    }
}
