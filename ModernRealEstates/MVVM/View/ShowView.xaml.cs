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

            estateListBox.ItemsSource = SharedData.Instance.EstatesList;

            

            //string stringEstate = testate.EstateToText();
            //estateListBox.Items.Add(stringEstate);

            //foreach (Estate estate in SharedData.Instance.EstatesList)
            //{
            //    string stringEstate = estate.EstateToText();
            //    estateListBox.Items.Add(stringEstate);
            //}

        }

        private void deleteSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (estateListBox.SelectedItem != null)
            {
                //estateListBox.Items.Remove(estateListBox.SelectedItem);
                SharedData.Instance.EstatesList.Remove((Estate)estateListBox.SelectedItem);

                foreach (Estate estate in SharedData.Instance.EstatesList)
                {
                    Debug.WriteLine($"Address: {estate.Address.Street}, {estate.Address.City}, {estate.Address.Zipcode}");
                }
            }
        }
    }
}
