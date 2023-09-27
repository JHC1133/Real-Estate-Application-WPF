using Joar_HC_ModernRealEstates;
using Modern_Real_Estates_by_Joar_H_C;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernRealEstates
{
    internal class SharedData
    {
        private static SharedData instance;
        private ObservableCollection<Estate> estatesList;
        private EstateManager estateManager;

        public ObservableCollection<Estate> EstatesList { get => estatesList; set => estatesList = value; }
        public EstateManager EstateManager { get => estateManager; set => estateManager = value; }


        private SharedData()
        {
            EstatesList = new ObservableCollection<Estate>();

            EstateManager = new EstateManager();

            Address address;

            address = new Address("Kungs", "Växjö", "21133", "Deniak");

            Estate testate = new Apartment(150, 30, 20, address, 14, 1, 2, true, "Apartment", "C:\\Users\\Joar\\Documents\\Skola\\C# for non-beginners\\A1\\villaEx.jpg");
            Estate testate1 = new Villa(200, 20, 30, address, 5, 1, 2, true, "Villa", "C:\\Users\\Joar\\Documents\\Skola\\C# for non-beginners\\A1\\villaEx.jpg");
            Estate estate1 = new Townhouse(300, 20, 20, address, 2, 1, 2, false, "Townhouse", "C:\\Users\\Joar\\Documents\\Skola\\C# for non-beginners\\A1\\villaEx.jpg");


            //EstatesList.Add(testate1);
            //EstatesList.Add(estate1);
            //EstatesList.Add(testate);

            EstateManager.Add(testate);
            EstateManager.Add(testate1);
            
        }

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
