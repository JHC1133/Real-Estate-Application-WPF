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

            Estate testate = new Apartment(150, 30, 20, "Zoller", "Malmö", "21213", "Suecia", 14, 1, 2, true);
            Estate testate1 = new Apartment(200, 20, 30, "Kungs", "Växjö", "21133", "Deniak", 5, 1, 2, true);
            Estate estate1 = new Apartment(300, 20, 20, "Halla", "Malmö", "21213", "Joder", 2, 1, 2, false);

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
