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

        public ObservableCollection<Estate> EstatesList { get => estatesList; set => estatesList = value; }

        private SharedData()
        {
            EstatesList = new ObservableCollection<Estate>();

            Address address;

            address = new Address("Kungs", "Växjö", "21133", "Deniak");

            Estate testate = new Apartment(150, 30, 20, address, 14, 1, 2, true, "Apartment");
            Estate testate1 = new Villa(200, 20, 30, address, 5, 1, 2, true, "Villa");
            Estate estate1 = new Townhouse(300, 20, 20, address, 2, 1, 2, false, "Townhouse");

            EstatesList.Add(testate1);
            EstatesList.Add(estate1);
            EstatesList.Add(testate);
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
