using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;

namespace Modern_Real_Estates_by_Joar_H_C
{
    internal class Tenement : Apartment
    {
        public Tenement(int price, int squareFeet, int monthlyFee, string street, string city, string zipcode, string country, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(price, squareFeet, monthlyFee, street, city, zipcode, country, numberOfRooms, numberOfBedrooms, numberOfBathrooms, hasGarage)
        {
        }
    }
}
