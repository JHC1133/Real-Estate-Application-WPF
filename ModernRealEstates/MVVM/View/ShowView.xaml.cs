using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            estateListBox.ItemsSource = SharedData.Instance.EstateManager.ToStringList();
            SharedData.Instance.WindowsList.Add(this);
        }

        private void deleteSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (estateListBox.SelectedItem != null)
            {
                SharedData.Instance.EstateManager.DeleteAt(estateListBox.SelectedIndex);
                estateListBox.Items.Refresh();

                
                estateImage.Source = null;
                estateListBox.ItemsSource = SharedData.Instance.EstateManager.ToStringList();
            }
        }

        private void estateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (estateListBox.SelectedItem is Estate selectedEstate)
            //{
            //    //estateImage.Source = new BitmapImage(new Uri(selectedEstate.ImageFilePath));

            //    try
            //    {
            //        Uri imageUri = new Uri(selectedEstate.ImageFilePath);

            //        // Check if the URI scheme is "file" (local file path)
            //        if (imageUri.Scheme == Uri.UriSchemeFile)
            //        {
            //            // Check if the file exists before setting the image source
            //            if (File.Exists(imageUri.LocalPath))
            //            {
            //                estateImage.Source = new BitmapImage(imageUri);
            //            }
            //            else
            //            {
            //                // Handle the case where the file doesn't exist
            //                // Display an error message or use a default image.
            //            }
            //        }
            //        else
            //        {
            //            // Handle other URI schemes (e.g., "http://", "https://")
            //            estateImage.Source = new BitmapImage(imageUri);
            //        }
            //    }
            //    catch (UriFormatException ex)
            //    {
            //        // Handle the invalid URI format exception (e.g., log the error or show an error message).
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}
