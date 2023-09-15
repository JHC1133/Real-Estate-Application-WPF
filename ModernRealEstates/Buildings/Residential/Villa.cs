using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;

namespace Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings
{
    internal class Villa : Residential
    {
        public Villa(int price, int squareFeet, int monthlyFee, string street, string city, string zipcode, string country, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(price, squareFeet, monthlyFee, street, city, zipcode, country, numberOfRooms, numberOfBedrooms, numberOfBathrooms, hasGarage)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string EstateToText()
        {
            return $"{ID} | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Fee: {MonthlyFee} kr | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Country} | Rooms: {numberOfRooms} | Bedrooms: {NumberOfBedrooms} | Bathrooms: {NumberOfBathrooms} | Garage: {hasGarage} | Villa";
        }
    }
}
