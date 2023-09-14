using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;

namespace Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings
{
    internal class Townhouse : Residential
    {
        public Townhouse(string street, string city, string zipcode, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(street, city, zipcode, numberOfBedrooms, numberOfBathrooms, hasGarage)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }
    }
}
