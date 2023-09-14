using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;

namespace Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings
{
    internal class Apartment : Residential
    {

        public Apartment(string street, string city, string zipcode, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(street, city, zipcode, numberOfBedrooms, numberOfBathrooms, hasGarage)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string EstateToText()
        {
            return $"Address: {Address.Street}, {Address.City}, {Address.Zipcode} | Bedrooms: {NumberOfBedrooms} | Bathrooms: {NumberOfBathrooms} | Garage: {hasGarage}";
        }

        void Test()
        {
    //    Apartment a = new Apartment(1, "Kungs", "Malm", "03312");


    //    string b = a.GetStreet();
    //    string c = a.address.City;
        }
 
    }
}
