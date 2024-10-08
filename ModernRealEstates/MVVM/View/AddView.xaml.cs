﻿using Modern_Real_Estates_by_Joar_H_C;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using Modern_Real_Estates_by_Joar_H_C.Buildings.CommercialBuildings;
using Modern_Real_Estates_by_Joar_H_C.Buildings.InstitutionalBuildings;
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
            HideDefaultControls();

            currentBT = BuildingTypes.Residential;
            addComboBox.SelectedIndex = 0;
        }

        

        private void LoadCountriesComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Countries)))
            {
                countryComboBox.Items.Add(item);
            }
        }

        private enum BuildingTypes
        {
            Residential,
            Institutional,
            Commercial
        }

        private void HandleComboBoxSelection()
        {
            switch (addComboBox.SelectedIndex)
            {
                case 0:
                    currentBT = BuildingTypes.Residential; // Apartment
                    ShowResidentialStackPanelOnly();
                    Debug.WriteLine("Case: residential");
                    break;
                case 1:
                    currentBT = BuildingTypes.Residential; // Townhouse
                    ShowResidentialStackPanelOnly();
                    Debug.WriteLine("Case: residential");
                    break;
                case 2:
                    currentBT = BuildingTypes.Residential; // Villa
                    ShowResidentialStackPanelOnly();
                    Debug.WriteLine("Case: residential");
                    break;
                case 3:
                    currentBT = BuildingTypes.Commercial; // Shop
                    ShowCommericalStackPanelOnly();
                    Debug.WriteLine("Case: Commercial");
                    break;
                case 4:
                    currentBT = BuildingTypes.Commercial; // Warehouse
                    ShowCommericalStackPanelOnly();
                    Debug.WriteLine("Case: Commercial");
                    break;
                case 5:
                    currentBT = BuildingTypes.Institutional; // Hospital
                    ShowInstitutionalStackPanelOnly();
                    Debug.WriteLine("Case: Institutional");
                    break;
                case 6:
                    currentBT = BuildingTypes.Institutional; // School
                    ShowInstitutionalStackPanelOnly();
                    Debug.WriteLine("Case: Institutional");
                    break;
                case 7:
                    currentBT = BuildingTypes.Institutional; // University
                    ShowInstitutionalStackPanelOnly();
                    Debug.WriteLine("Case: Institutional");
                    break;
                default:
                    break;
            }
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

        private void ClearCommercialForm()
        {
            addPriceTextBox.Clear();
            addSquareFtTextBox.Clear();
            addFeeTextBox.Clear();
            addCityTextBox.Clear();
            addStreetTextBox.Clear();
            addZipCodeTextBox.Clear();
            addNrOfFloorsTextBox.Clear();
            addNrOfParkingTextBox.Clear();

            addSaleOrRentComboBox.Text = null;
            addHasInventoryComboBox.Text = null;
            countryComboBox.Text = null;
            addHasParkingCheckBox.IsChecked = false;
            addHasInventoryCheckBox.IsChecked = false;
        }

        private void ClearInstitutionalForm()
        {
            addPriceTextBox.Clear();
            addSquareFtTextBox.Clear();
            addFeeTextBox.Clear();
            addCityTextBox.Clear();
            addStreetTextBox.Clear();
            addZipCodeTextBox.Clear();
            addNrOfParkingInstitTextBox.Clear();
            addNrOfFloorsInstitTextBox.Clear();

            countryComboBox.Text = null;
            addHasParkingInstitCheckBox.IsChecked = false;
            addHasInventoryInstitCheckBox.IsChecked = false;
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

        private bool AddCommercialFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(addStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(addCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(addZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfFloorsTextBox.Text) ||
                string.IsNullOrWhiteSpace(addSaleOrRentComboBox.Text))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
        }

        private bool AddInstitutionalFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(addStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(addCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(addZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfFloorsInstitTextBox.Text))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
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
                            countryComboBox.SelectedItem != null &&
                            addComboBox.SelectedItem != null)
                        {
                            string buildingType = addComboBox.Text;
                            Estate estate;
                            Address address;

                            if (buildingType == "Apartment")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new Apartment(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value, addComboBox.Text.ToString());

                                SharedData.Instance.EstatesList.Add(estate);
                                ClearResidentialForm();
                            }
                            else if (buildingType == "Townhouse")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new Townhouse(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value, addComboBox.Text.ToString());
                                SharedData.Instance.EstatesList.Add(estate);
                                ClearResidentialForm();
                            }
                            else if (buildingType == "Villa")
                            {                              
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new Villa(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value, addComboBox.Text.ToString());
                                SharedData.Instance.EstatesList.Add(estate);
                                ClearResidentialForm();
                            }                           
                        }
                        break;
                    }
                    break;

                case BuildingTypes.Institutional:

                    if (AddInstitutionalFormIsCompleted())
                    {
                        if (int.TryParse(addNrOfFloorsInstitTextBox.Text, out int numberOfFloors) &&
                            int.TryParse(addNrOfParkingInstitTextBox.Text, out int numberOfParking) &&
                            int.TryParse(addPriceTextBox.Text, out int price) &&
                            int.TryParse(addSquareFtTextBox.Text, out int squareFeet) &&
                            int.TryParse(addFeeTextBox.Text, out int monthlyFee) &&
                            countryComboBox.SelectedItem != null &&
                            addComboBox.SelectedItem != null)
                        {
                            string buildingType = addComboBox.Text;
                            Estate estate;
                            Address address;

                            if (buildingType == "Hospital")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new Hospital(price, monthlyFee, address, squareFeet, numberOfFloors, addHasParkingInstitCheckBox.IsChecked.Value, numberOfParking, addHasInventoryInstitCheckBox.IsChecked.Value, addComboBox.Text.ToString());

                                SharedData.Instance.EstatesList.Add(estate);
                                Debug.WriteLine("Added Hospital");
                                ClearInstitutionalForm();
                            }
                            else if (buildingType == "School")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new School(price, monthlyFee, address, squareFeet, numberOfFloors, addHasParkingInstitCheckBox.IsChecked.Value, numberOfParking, addHasInventoryInstitCheckBox.IsChecked.Value, addComboBox.Text.ToString());

                                SharedData.Instance.EstatesList.Add(estate);
                                Debug.WriteLine("Added school");
                                ClearInstitutionalForm();
                            }
                            else if (buildingType == "University")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new University(price, monthlyFee, address, squareFeet, numberOfFloors, addHasParkingInstitCheckBox.IsChecked.Value, numberOfParking, addHasInventoryInstitCheckBox.IsChecked.Value, addComboBox.Text.ToString());

                                SharedData.Instance.EstatesList.Add(estate);
                                Debug.WriteLine("Added Uni");
                                ClearInstitutionalForm();
                            }
                        }
                        break;
                    }
                    break;

                case BuildingTypes.Commercial:

                    if (AddCommercialFormIsCompleted())
                    {
                        if (int.TryParse(addNrOfFloorsTextBox.Text, out int numberOfFloors) &&
                            int.TryParse(addNrOfParkingTextBox.Text, out int numberOfParking) &&
                            int.TryParse(addPriceTextBox.Text, out int price) &&
                            int.TryParse(addSquareFtTextBox.Text, out int squareFeet) &&
                            countryComboBox.SelectedItem != null &&
                            addComboBox.SelectedItem != null)
                        {
                            string buildingType = addComboBox.Text;
                            Estate estate;
                            Address address;

                            if (buildingType == "Shop")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new Shop(price, addSaleOrRentComboBox.Text, squareFeet, address, numberOfFloors, addHasParkingCheckBox.IsChecked.Value, numberOfParking, addHasInventoryCheckBox.IsChecked.Value, addHasInventoryComboBox.Text, addComboBox.Text.ToString());

                                SharedData.Instance.EstatesList.Add(estate);
                                ClearCommercialForm();
                            }
                            else if (buildingType == "Warehouse")
                            {
                                address = new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
                                estate = new Warehouse(price, addSaleOrRentComboBox.Text, squareFeet, address, numberOfFloors, addHasParkingCheckBox.IsChecked.Value, numberOfParking, addHasInventoryCheckBox.IsChecked.Value, addHasInventoryComboBox.Text, addComboBox.Text.ToString());

                                SharedData.Instance.EstatesList.Add(estate);
                                ClearCommercialForm();
                            }
                        }
                        break;
                    }
                    break; 
                default:
                    break;
            }
        }

      

        private void addComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HandleComboBoxSelection();
        }

        private void ShowResidentialStackPanelOnly()
        {
            ShowResidentialStackPanelItems();
            HideCommercialStackPanelItems();
            HideInstitutionalStackPanelItems();
        }

        private void ShowCommericalStackPanelOnly()
        {
            ShowCommercialStackPanelItems();
            HideResidentialStackPanelItems();
            HideInstitutionalStackPanelItems();
        }

        private void ShowInstitutionalStackPanelOnly()
        {
            ShowInstitutionalStackPanelItems();
            HideResidentialStackPanelItems();
            HideCommercialStackPanelItems();
        }

        private void HideResidentialStackPanelItems()
        {
            foreach (UIElement child in residentialStackPanel.Children)
            {
                child.Visibility = Visibility.Collapsed;
            }
        }
        private void HideCommercialStackPanelItems()
        {
            foreach (UIElement child in commercialStackPanel.Children)
            {
                child.Visibility = Visibility.Collapsed;
            }

            foreach (UIElement child in commercialStackPanel2.Children)
            {
                child.Visibility = Visibility.Collapsed;
            }
        }

        private void HideInstitutionalStackPanelItems()
        {
            foreach (UIElement child in institutionalStackPanel.Children)
            {
                child.Visibility = Visibility.Collapsed;
            }

            foreach (UIElement child in institutionalStackPanel2.Children)
            {
                child.Visibility = Visibility.Collapsed;
            }
        }

        private void ShowCommercialStackPanelItems()
        {
            foreach (UIElement child in commercialStackPanel.Children)
            {
                child.Visibility = Visibility.Visible;
            }

            foreach (UIElement child in commercialStackPanel2.Children)
            {
                child.Visibility = Visibility.Visible;
            }
        }

        private void ShowInstitutionalStackPanelItems()
        {
            foreach (UIElement child in institutionalStackPanel.Children)
            {
                child.Visibility = Visibility.Visible;
            }

            foreach (UIElement child in institutionalStackPanel2.Children)
            {
                child.Visibility = Visibility.Visible;
            }
        }

        private void ShowResidentialStackPanelItems()
        {
            foreach (UIElement child in residentialStackPanel.Children)
            {
                child.Visibility = Visibility.Visible;
            }
        }


        private void HideDefaultControls()
        {
            addNrOfParkingTextBlock.Visibility = Visibility.Collapsed;
            addNrOfParkingTextBox.Visibility = Visibility.Collapsed;

            addTypeOfInventoryTextBlock.Visibility = Visibility.Collapsed;
            addHasInventoryComboBox.Visibility = Visibility.Collapsed;

            addNrOfParkingInstitTextBlock.Visibility = Visibility.Collapsed;
            addNrOfParkingInstitTextBox.Visibility = Visibility.Collapsed;
        }

        private void addHasParkingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addNrOfParkingTextBlock.Visibility = Visibility.Visible;
            addNrOfParkingTextBox.Visibility = Visibility.Visible;
        }

        private void addHasParkingCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addNrOfParkingTextBlock.Visibility = Visibility.Collapsed;
            addNrOfParkingTextBox.Visibility = Visibility.Collapsed;
        }

        private void addHasInventoryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addTypeOfInventoryTextBlock.Visibility = Visibility.Visible;
            addHasInventoryComboBox.Visibility = Visibility.Visible;
        }

        private void addHasInventoryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addTypeOfInventoryTextBlock.Visibility = Visibility.Collapsed;
            addHasInventoryComboBox.Visibility = Visibility.Collapsed;
        }

        private void addHasParkingInstitCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            addNrOfParkingInstitTextBlock.Visibility = Visibility.Visible;
            addNrOfParkingInstitTextBox.Visibility = Visibility.Visible;
        }

        private void addHasParkingInstitCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            addNrOfParkingInstitTextBlock.Visibility = Visibility.Collapsed;
            addNrOfParkingInstitTextBox.Visibility = Visibility.Collapsed;
        }
    }
}
