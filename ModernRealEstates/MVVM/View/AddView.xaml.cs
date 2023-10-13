using Microsoft.Win32;
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
using BLL;
using BLL.AbstractClasses;
using UtilitiesLib;

namespace ModernRealEstates.MVVM.View
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        BuildingTypes currentBT;
        string selectedImageFilePath;
        Helper helper = new Helper();

        public AddView()
        {
            InitializeComponent();
            DataContext = SharedData.Instance;

            LoadCountriesComboBox();
            HideDefaultControls();

            currentBT = BuildingTypes.Residential;
            addComboBox.SelectedIndex = 0;
            SharedData.Instance.WindowsList.Add(this);

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

        public void ClearResidentialForm()
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

            addComboBox.SelectedIndex = 0;
            countryComboBox.Text = null;
            addHasGarageCheckBox.IsChecked = false;
            selectedImageFilePath = string.Empty;
        }

        public void ClearCommercialForm()
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
            selectedImageFilePath = string.Empty;
            addComboBox.SelectedIndex = 0;

        }

        public void ClearInstitutionalForm()
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
            selectedImageFilePath = string.Empty;
            addComboBox.SelectedIndex = 0;

        }

        private bool AddResidentialFormIsCompleted()
        {
            if (string.IsNullOrWhiteSpace(addStreetTextBox.Text) ||
                string.IsNullOrWhiteSpace(addCityTextBox.Text) ||
                string.IsNullOrWhiteSpace(addZipCodeTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfBathroomsTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfBedroomsTextBox.Text) ||
                string.IsNullOrWhiteSpace(addNrOfRoomsTextBox.Text) ||
                string.IsNullOrEmpty(selectedImageFilePath))
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
                string.IsNullOrWhiteSpace(addSaleOrRentComboBox.Text) ||
                string.IsNullOrEmpty(selectedImageFilePath))
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
                string.IsNullOrWhiteSpace(addNrOfFloorsInstitTextBox.Text) ||
                string.IsNullOrEmpty(selectedImageFilePath))
            {
                MessageBox.Show("Please fill out the form!");
                return false;
            }
            return true;
        }

        private bool TryParseGeneralFields(out int price, out int squareFeet, out int monthlyFee)
        {
            price = 0;
            squareFeet = 0;
            monthlyFee = 0;

            return helper.StringToInt(addPriceTextBox.Text, out price) &&
                   helper.StringToInt(addSquareFtTextBox.Text, out squareFeet) &&
                   helper.StringToInt(addFeeTextBox.Text, out monthlyFee);
        }

        private bool TryParseResidentialFields(out int numberOfBathrooms, out int numberOfBedrooms, out int numberOfRooms, out int price, out int squareFeet, out int monthlyFee)
        {
            numberOfBathrooms = 0;
            numberOfBedrooms = 0;
            numberOfRooms = 0;
            price = 0;
            squareFeet = 0;
            monthlyFee = 0;

            return int.TryParse(addNrOfBathroomsTextBox.Text, out numberOfBathrooms) &&
                helper.StringToInt(addNrOfBedroomsTextBox.Text, out numberOfBedrooms) &&
                helper.StringToInt(addNrOfRoomsTextBox.Text, out numberOfRooms) &&
                helper.StringToInt(addPriceTextBox.Text, out price) &&
                helper.StringToInt(addSquareFtTextBox.Text, out squareFeet) &&
                helper.StringToInt(addFeeTextBox.Text, out monthlyFee) &&
                countryComboBox.SelectedItem != null &&
                addComboBox.SelectedItem != null &&
                selectedImageFilePath != null;
        }

        private bool TryParseCommercialFields(out int numberOfFloors, out int numberOfParking, out int price, out int squareFeet)
        {
            numberOfFloors = 0;
            numberOfParking = 0;
            price = 0;
            squareFeet = 0;

            return int.TryParse(addNrOfFloorsTextBox.Text, out numberOfFloors) &&
                helper.StringToInt(addNrOfParkingTextBox.Text, out numberOfParking) &&
                helper.StringToInt(addPriceTextBox.Text, out price) &&
                helper.StringToInt(addSquareFtTextBox.Text, out squareFeet) &&
                countryComboBox.SelectedItem != null &&
                addComboBox.SelectedItem != null &&
                selectedImageFilePath != null;
        }

        private bool TryParseInstitutionalFields(out int numberOfFloors, out int numberOfParking, out int price, out int squareFeet, out int monthlyFee)
        {
            numberOfFloors = 0;
            numberOfParking = 0;
            price = 0;
            squareFeet = 0;
            monthlyFee = 0;

            return int.TryParse(addNrOfFloorsInstitTextBox.Text, out numberOfFloors) &&
                int.TryParse(addNrOfParkingInstitTextBox.Text, out numberOfParking) &&
                int.TryParse(addPriceTextBox.Text, out price) &&
                int.TryParse(addSquareFtTextBox.Text, out squareFeet) &&
                countryComboBox.SelectedItem != null &&
                addComboBox.SelectedItem != null &&
                selectedImageFilePath != null;
        }

        private Address CreateAddress()
        {
            return new Address(addStreetTextBox.Text, addCityTextBox.Text, addZipCodeTextBox.Text, countryComboBox.SelectedItem.ToString());
        }

        private void addSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Estate estate = null;
            Address address = null;

            switch (currentBT)
            {
                case BuildingTypes.Residential:

                    if (AddResidentialFormIsCompleted())
                    {                      
                        if (TryParseResidentialFields(out int numberOfBathrooms, out int numberOfBedrooms, out int numberOfRooms, out int price, out int squareFeet, out int monthlyFee))
                        {
                            string buildingType = addComboBox.Text;
                            address = CreateAddress();

                            if (buildingType == "Apartment")
                            {
                                estate = new Apartment(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value, addComboBox.Text.ToString(), selectedImageFilePath);
                                SharedData.Instance.EstateManager.Add(estate);
                                ClearResidentialForm();
                            }
                            else if (buildingType == "Townhouse")
                            {
                                estate = new Townhouse(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value, addComboBox.Text.ToString(), selectedImageFilePath);
                                SharedData.Instance.EstateManager.Add(estate);
                                ClearResidentialForm();
                            }
                            else if (buildingType == "Villa")
                            {
                                estate = new Villa(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBathrooms, numberOfBedrooms, addHasGarageCheckBox.IsChecked.Value, addComboBox.Text.ToString(), selectedImageFilePath);
                                SharedData.Instance.EstateManager.Add(estate);
                                ClearResidentialForm();
                            }                           
                        }
                        break;
                    }
                    break;

                case BuildingTypes.Institutional:

                    if (AddInstitutionalFormIsCompleted())
                    {
                        if (TryParseInstitutionalFields(out int numberOfFloors, out int numberOfParking, out int price, out int squareFeet, out int monthlyFee))
                        {
                            string buildingType = addComboBox.Text;
                            address = CreateAddress();

                            if (buildingType == "Hospital")
                            {
                                estate = new Hospital(price, monthlyFee, address, squareFeet, numberOfFloors, addHasParkingInstitCheckBox.IsChecked.Value, numberOfParking, addHasInventoryInstitCheckBox.IsChecked.Value, addComboBox.Text.ToString(), selectedImageFilePath);
                                SharedData.Instance.EstateManager.Add(estate);
                                ClearInstitutionalForm();
                            }
                            else if (buildingType == "School")
                            {
                                estate = new School(price, monthlyFee, address, squareFeet, numberOfFloors, addHasParkingInstitCheckBox.IsChecked.Value, numberOfParking, addHasInventoryInstitCheckBox.IsChecked.Value, addComboBox.Text.ToString(), selectedImageFilePath);
                                SharedData.Instance.EstateManager.Add(estate);
                                ClearInstitutionalForm();
                            }
                            else if (buildingType == "University")
                            {
                                estate = new University(price, monthlyFee, address, squareFeet, numberOfFloors, addHasParkingInstitCheckBox.IsChecked.Value, numberOfParking, addHasInventoryInstitCheckBox.IsChecked.Value, addComboBox.Text.ToString(), selectedImageFilePath);

                                SharedData.Instance.EstateManager.Add(estate);
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
                        if (TryParseCommercialFields(out int numberOfFloors, out int numberOfParking, out int price, out int squareFeet))
                        {
                            string buildingType = addComboBox.Text;
                            address = CreateAddress();

                            if (buildingType == "Shop")
                            {
                                estate = new Shop(price, addSaleOrRentComboBox.Text, squareFeet, address, numberOfFloors, addHasParkingCheckBox.IsChecked.Value, numberOfParking, addHasInventoryCheckBox.IsChecked.Value, addHasInventoryComboBox.Text, addComboBox.Text.ToString(), selectedImageFilePath);

                                SharedData.Instance.EstateManager.Add(estate);
                                ClearCommercialForm();
                            }
                            else if (buildingType == "Warehouse")
                            {                              
                                estate = new Warehouse(price, addSaleOrRentComboBox.Text, squareFeet, address, numberOfFloors, addHasParkingCheckBox.IsChecked.Value, numberOfParking, addHasInventoryCheckBox.IsChecked.Value, addHasInventoryComboBox.Text, addComboBox.Text.ToString(), selectedImageFilePath);
                                SharedData.Instance.EstateManager.Add(estate);
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

        private void addImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            openFileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImageFilePath = openFileDialog.FileName;
            }
        }
    }
}
