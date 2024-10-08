﻿using System;
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

        public Apartment(int price, int squareFeet, int monthlyFee, Address address, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage, string buildingType) 
            : base(price, squareFeet, monthlyFee, address, numberOfRooms, numberOfBedrooms, numberOfBathrooms, hasGarage, buildingType)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string EstateToText()
        {
            return $"{ID} | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Fee: {MonthlyFee} kr | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Rooms: {numberOfRooms} | Bedrooms: {NumberOfBedrooms} | Bathrooms: {NumberOfBathrooms} | Garage: {hasGarage} | {BuildingType}";
        }

        void Test()
        {
    //    Apartment a = new Apartment(1, "Kungs", "Malm", "03312");


    //    string b = a.GetStreet();
    //    string c = a.address.City;
        }
 
    }
}
