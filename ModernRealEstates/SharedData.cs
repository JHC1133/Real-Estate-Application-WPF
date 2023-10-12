using Modern_Real_Estates_by_Joar_H_C;
using BLL.AbstractClasses;
using ModernRealEstates.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BLL
{
    internal class SharedData
    {
        private bool isSaved;
        private static SharedData instance;
        private ObservableCollection<Estate> estatesList;
        private List<UserControl> windowsList;
        private EstateManager estateManager;

        public ObservableCollection<Estate> EstatesList { get => estatesList; set => estatesList = value; }
        public EstateManager EstateManager { get => estateManager; set => estateManager = value; }
        public bool IsSaved { get => isSaved; set => isSaved = value; }
        public List<UserControl> WindowsList { get => windowsList; set => windowsList = value; }



        private SharedData()
        {
            WindowsList = new List<UserControl>();
            EstatesList = new ObservableCollection<Estate>();

            EstateManager = new EstateManager();

            Address address, address2;

            address = new Address("Kungs", "Växjö", "21133", "Deniak");
            address2 = new Address("Killian", "Malmö", "21133", "Deniak");

            //Estate testate = new Apartment(150, 30, 20, address, 14, 1, 2, true, "Apartment", "C:\\Users\\Joar\\Documents\\Skola\\C# for non-beginners\\A1\\villaEx.jpg");
            Estate testate1 = new Villa(200, 20, 30, address, 5, 1, 2, true, "Villa", "C:\\Users\\Joar\\Documents\\Skola\\C# for non-beginners\\A1\\villaEx.jpg");
            Estate estate1 = new Townhouse(300, 20, 20, address2, 2, 1, 2, false, "Townhouse", "C:\\Users\\Joar\\Documents\\Skola\\C# for non-beginners\\A1\\villaEx.jpg");


            //EstatesList.Add(testate1);
            //EstatesList.Add(estate1);
            //EstatesList.Add(testate);

            //EstateManager.Add(testate);
            EstateManager.Add(testate1);
            EstateManager.Add(estate1);

        }

        public bool HasUnSavedData()
        {
            if (isSaved)
            {
                return false;
            }
            return true;
        }

        public void InitializeUserControls()
        {
            foreach (UserControl item in WindowsList)
            {
                if (item != null)
                {
                    if (item is ChangeView changeView)
                    {
                        changeView.ClearCommercialForm();
                        changeView.ClearInstitutionalForm();
                        changeView.ClearResidentialForm();
                    }

                    else if (item is AddView addView)
                    {
                        addView.ClearCommercialForm();
                        addView.ClearInstitutionalForm();
                        addView.ClearResidentialForm();
                    }

                    else if (item is ShowView showView)
                    {
                        Instance.estateManager.List.Clear();
                    }
                }
            }
        }

        //Used for getting fields and methods without turning them static
        public static SharedData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharedData();
                }
                return instance;
            }
        }

    }
}
