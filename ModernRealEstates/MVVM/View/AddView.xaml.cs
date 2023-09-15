using Modern_Real_Estates_by_Joar_H_C;
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
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        BuildingTypes currentBT;

        public AddView()
        {
            InitializeComponent();
            DataContext = SharedData.Instance;

            LoadCountriesComboBox();

            currentBT = BuildingTypes.Residential;
        }

        private void LoadCountriesComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Countries)))
            {
                countryComboBox.Items.Add(item);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
                    
            
        }

        private bool AddResidentialFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(addStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(addCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(addZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfBathroomsTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfBedroomsTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfRoomsTextBox.Text))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
        }

        private enum BuildingTypes
        {
            Residential,
            Institutional,
            Commercial
        }

        private void ClearResidentialForm()
        {
            addPriceTextBox.Clear();
            addSquareFtTextBox.Clear();
            addFeeTextBox.Clear();
            addCityTextBox.Clear();
            addStreetTextBox.Clear();
            addZipCodeTextBox.Clear();
            addNrOfBathroomsTextBox.Clear();
            addNrOfBedroomsTextBox.Clear();
            addNrOfRoomsTextBox.Clear();

            countryComboBox.Text = null;
            addHasGarageCheckBox.IsChecked = false;
        }

        private void addSubmitButton_Click(object sender, RoutedEventArgs e)
        {

            switch (currentBT)
            {
                case BuildingTypes.Residential:

                    if (AddResidentialFormIsCompleted())
                    {                      
                        if (int.TryParse(addNrOfBathroomsTextBox.Text, out int numberOfBathrooms) &&
                            int.TryParse(addNrOfBedroomsTextBox.Text, out int numberOfBedrooms) &&
                            int.TryParse(addNrOfRoomsTextBox.Text, out int numberOfRooms) &&
                            int.TryParse(addPriceTextBox.Text, out int price) &&
                            int.TryParse(addSquareFtTextBox.Text, out int squareFeet) &&
                            int.TryParse(addFeeTextBox.Text, out int monthlyFee) &&
                            countryComboBox.SelectedItem != null)
                        {
                            string buildingType = addComboBox.Text;

                            if (buildingType == "Apartment")
                            {
                                Estate estate;
                                Estate estate1;
                                Address address;

                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());

                                estate = new Apartment(price, squareFeet, monthlyFee, addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString(),
                                    numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value);

                                estate1 = new Apartment(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value);

                                SharedData.Instance.EstatesList.Add(estate);
                                SharedData.Instance.EstatesList.Add(estate1);

                                ClearResidentialForm();
                            }
                            else if (buildingType == "Townhouse")
                            {
                                Estate estate;
                                estate = new Townhouse(price, squareFeet, monthlyFee, addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString(),
                                    numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value);
                                SharedData.Instance.EstatesList.Add(estate);
                                ClearResidentialForm();
                            }
                            else if (buildingType == "Villa")
                            {
                                Estate estate;
                                estate = new Villa(price, squareFeet, monthlyFee, addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString(),
                                    numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value);
                                SharedData.Instance.EstatesList.Add(estate);
                                ClearResidentialForm();
                            }                           
                        }
                        break;
                    }
                    break;
                case BuildingTypes.Institutional:
                    break;
                case BuildingTypes.Commercial:
                    break; 
                default:
                    break;
            }
        }

        private void HandleComboBoxSelection()
        {
            switch (addComboBox.SelectedIndex)
            {
                case 0:
                    currentBT = BuildingTypes.Residential;
                    break;
                case 1:
                    currentBT = BuildingTypes.Residential;
                    break;
                case 2:
                    currentBT = BuildingTypes.Residential;
                    break;
                case 3:
                    currentBT = BuildingTypes.Commercial;
                    break;
                case 4:
                    currentBT = BuildingTypes.Commercial;
                    break;
                case 5:
                    currentBT = BuildingTypes.Institutional;
                    break;
                case 6:
                    currentBT = BuildingTypes.Institutional;
                    break;
                case 7:
                    currentBT = BuildingTypes.Institutional;
                    break;
                default:
                    break;
            }
        }

        private void addComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HandleComboBoxSelection();
        }
    }
}
