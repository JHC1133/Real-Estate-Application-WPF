using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;

namespace Modern_Real_Estates_by_Joar_H_C
{
    internal class Rental : Apartment
    {
        public Rental(int price, int squareFeet, int monthlyFee, Address address, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage, string buildingType, string imageFilePath) 
            : base(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBedrooms, numberOfBathrooms, hasGarage, buildingType, imageFilePath)
        {
        }
    }
}
