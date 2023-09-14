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

            Estate testate = new Apartment("Zoller", "Malmö", "21213", 1, 2, true);
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
