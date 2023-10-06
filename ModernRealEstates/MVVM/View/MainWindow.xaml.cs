using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
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

namespace ModernRealEstates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveFileDialog saveFileDialog;
        bool hasFilePath;

        public MainWindow()
        {
            InitializeComponent();
            saveFileDialog = new SaveFileDialog();
        }

        private void menuFileNew_Click(object sender, RoutedEventArgs e)
        {
            if (SharedData.Instance.HasUnSavedData())
            {
                MessageBoxResult result = MessageBox.Show("You have unsaved data. Do you want to proceed without saving ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    SharedData.Instance.InitializeUserControls();
                    InitializeMainWindow();
                }
            }
            //else
            //{
            //    SharedData.Instance.InitializeUserControls();
            //}
            
        }

        private void InitializeMainWindow()
        {
            hasFilePath = false;
            saveFileDialog = null;
        }

        private void menuFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAsFile();
        }

        private void menuFileSave_Click(object sender, RoutedEventArgs e)
        {
            if (hasFilePath)
            {
                string selectedFilePath = saveFileDialog.FileName;

                if (SharedData.Instance.EstateManager.JsonSerialize(selectedFilePath))
                {
                    MessageBox.Show("Dava saved to JSON file successfully");
                }
                
            }
            else
            {
                SaveAsFile();
            }

        }

        private void SaveAsFile()
        {
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = saveFileDialog.FileName;

                if (SharedData.Instance.EstateManager.JsonSerialize(selectedFilePath))
                {
                    MessageBox.Show("Data saved to JSON file successfully");
                    hasFilePath = true;
                }
                else
                {
                    MessageBox.Show("Failed to save data to JSON file");
                }
            }
        }

        private void menuFileOpen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
