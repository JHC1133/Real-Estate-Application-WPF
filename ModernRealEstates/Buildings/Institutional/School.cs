﻿using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C.Buildings.InstitutionalBuildings
{
    internal class School : Institutional
    {
        public School(int price, int monthlyFee, Address address, int squareFeet, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string buildingType, string imageFilePath) 
            : base(price, monthlyFee, address, squareFeet, numberOfFloors, hasParking, numberOfParkingSlots, hasInventory, buildingType, imageFilePath)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string ToString()
        {
            return $"{ID} | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Fee: {MonthlyFee} kr | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {numberOfFloors} | Parking: {hasParking} | Number of Parking Spaces: {numberOfParkingSlots} | Inventory: {hasInventory} | School";
        }
    }
}
