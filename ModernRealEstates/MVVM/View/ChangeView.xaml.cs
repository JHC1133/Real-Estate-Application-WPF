﻿using Modern_Real_Estates_by_Joar_H_C;
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
    /// Interaction logic for ChangeView.xaml
    /// </summary>
    public partial class ChangeView : UserControl
    {
        BuildingTypes currentBT;
        Estate estate;
        Residential residential;
        Commercial commercial;
        Institutional institutional;

        public ChangeView()
        {
            InitializeComponent();
            HideDefaultControls();
            LoadCountriesComboBox();
            DataContext = SharedData.Instance;

            estateListBox.ItemsSource = SharedData.Instance.EstatesList;
        }

        private enum BuildingTypes
        {
            Residential,
            Institutional,
            Commercial
        }

        private void RefreshListBox()
        {
            DataContext = null;
            DataContext = SharedData.Instance;
        }

        private void LoadCountriesComboBox()
        {
            foreach (var item in Enum.GetValues(typeof(Countries)))
            {
                countryComboBox.Items.Add(item);
            }
        }

        private void estateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void changeSelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (estateListBox.SelectedItem != null)
            {
                estate = (Estate)estateListBox.SelectedItem;
                Debug.WriteLine(estate.EstateToText());

                changeComboBox.Text = estate.BuildingType.ToString();

                if (estate is Residential)
                {
                    residential = (Residential)estate;
                    changePriceTextBox.Text = residential.Price.ToString();
                    changeSquareFtTextBox.Text = residential.SquareFeet.ToString();
                    changeFeeTextBox.Text = residential.MonthlyFee.ToString();
                    changeNrOfRoomsTextBox.Text = residential.NumberOfRooms.ToString();
                    changeNrOfBedroomsTextBox.Text = residential.NumberOfBedrooms.ToString();
                    changeNrOfBathroomsTextBox.Text = residential.NumberOfBathrooms.ToString();
                    changeStreetTextBox.Text = residential.Address.Street;
                    changeCityTextBox.Text = residential.Address.City;
                    changeZipCodeTextBox.Text = residential.Address.Zipcode;
                    countryComboBox.Text = residential.Address.Country.ToString();
                    changeHasGarageCheckBox.IsChecked = residential.HasGarage;
                }
                
            }
        }
        private void changeSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            switch (currentBT)
            {
                case BuildingTypes.Residential:

                    if (changeResidentialFormIsCompleted())
                    {
                        if (int.TryParse(changeNrOfBathroomsTextBox.Text, out int numberOfBathrooms) &&
                            int.TryParse(changeNrOfBedroomsTextBox.Text, out int numberOfBedrooms) &&
                            int.TryParse(changeNrOfRoomsTextBox.Text, out int numberOfRooms) &&
                            int.TryParse(changePriceTextBox.Text, out int price) &&
                            int.TryParse(changeSquareFtTextBox.Text, out int squareFeet) &&
                            int.TryParse(changeFeeTextBox.Text, out int monthlyFee) &&
                            countryComboBox.SelectedItem != null &&
                            changeComboBox.SelectedItem != null)
                        {
                            residential.Price = price;
                            residential.PricePerSqFeet = squareFeet;
                            residential.MonthlyFee = monthlyFee;
                            residential.NumberOfRooms = numberOfRooms;
                            residential.NumberOfBedrooms = numberOfBedrooms;
                            residential.NumberOfBathrooms = numberOfBathrooms;
                            residential.Address.City = changeCityTextBox.Text;
                            residential.Address.Street = changeStreetTextBox.Text;
                            residential.Address.Zipcode = changeZipCodeTextBox.Text;
                            residential.Address.Country = countryComboBox.Text;
                            residential.BuildingType = changeComboBox.Text;
                            residential.HasGarage = changeHasGarageCheckBox.IsChecked;
                            RefreshListBox();
                            ClearResidentialForm();
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
        private void changeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HandleComboBoxSelection();
        }

        private void HandleComboBoxSelection()
        {
            switch (changeComboBox.SelectedIndex)
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
            HideResidentialStackPanelItems();
            HideCommercialStackPanelItems();
            HideInstitutionalStackPanelItems();
        }

        private void changeHasParkingInstitCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            changeNrOfParkingInstitTextBlock.Visibility = Visibility.Visible;
            changeNrOfParkingInstitTextBox.Visibility = Visibility.Visible;
        }

        private void changeHasParkingInstitCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            changeNrOfParkingInstitTextBlock.Visibility = Visibility.Collapsed;
            changeNrOfParkingInstitTextBox.Visibility = Visibility.Collapsed;
        }

        private void changeHasInventoryCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            changeTypeOfInventoryTextBlock.Visibility = Visibility.Collapsed;
            changeHasInventoryComboBox.Visibility = Visibility.Collapsed;
        }

        private void changeHasInventoryCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            changeTypeOfInventoryTextBlock.Visibility = Visibility.Visible;
            changeHasInventoryComboBox.Visibility = Visibility.Visible;
        }

        private void changeHasParkingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            changeNrOfParkingTextBlock.Visibility = Visibility.Visible;
            changeNrOfParkingTextBox.Visibility = Visibility.Visible;
        }

        private void changeHasParkingCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            changeNrOfParkingTextBlock.Visibility = Visibility.Collapsed;
            changeNrOfParkingTextBox.Visibility = Visibility.Collapsed;
        }

        

        private bool changeResidentialFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(changeStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeNrOfBathroomsTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeNrOfBedroomsTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeNrOfRoomsTextBox.Text))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
        }

        private bool changeCommercialFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(changeStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeNrOfFloorsTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeSaleOrRentComboBox.Text))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
        }

        private bool changeInstitutionalFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(changeStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(changeNrOfFloorsInstitTextBox.Text))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
        }

        private void ClearResidentialForm()
        {
            changePriceTextBox.Clear();
            changeSquareFtTextBox.Clear();
            changeFeeTextBox.Clear();
            changeCityTextBox.Clear();
            changeStreetTextBox.Clear();
            changeZipCodeTextBox.Clear();
            changeNrOfBathroomsTextBox.Clear();
            changeNrOfBedroomsTextBox.Clear();
            changeNrOfRoomsTextBox.Clear();

            countryComboBox.Text = null;
            changeHasGarageCheckBox.IsChecked = false;
        }

        private void ClearCommercialForm()
        {
            changePriceTextBox.Clear();
            changeSquareFtTextBox.Clear();
            changeFeeTextBox.Clear();
            changeCityTextBox.Clear();
            changeStreetTextBox.Clear();
            changeZipCodeTextBox.Clear();
            changeNrOfFloorsTextBox.Clear();
            changeNrOfParkingTextBox.Clear();

            changeSaleOrRentComboBox.Text = null;
            changeHasInventoryComboBox.Text = null;
            countryComboBox.Text = null;
            changeHasParkingCheckBox.IsChecked = false;
            changeHasInventoryCheckBox.IsChecked = false;
        }

        private void ClearInstitutionalForm()
        {
            changePriceTextBox.Clear();
            changeSquareFtTextBox.Clear();
            changeFeeTextBox.Clear();
            changeCityTextBox.Clear();
            changeStreetTextBox.Clear();
            changeZipCodeTextBox.Clear();
            changeNrOfParkingInstitTextBox.Clear();
            changeNrOfFloorsInstitTextBox.Clear();

            countryComboBox.Text = null;
            changeHasParkingInstitCheckBox.IsChecked = false;
            changeHasInventoryInstitCheckBox.IsChecked = false;
        }
    }
}
