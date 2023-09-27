﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;


namespace Modern_Real_Estates_by_Joar_H_C.Buildings.CommercialBuildings
{
    internal class Shop : Commercial
    {
        public Shop(int price, string saleOrRent, int squareFeet, Address address, int numberOfFloors, bool hasParking, int numberOfParkingSlots, bool hasInventory, string inventoryType, string buildingType, string imageFilePath) 
            : base(price, saleOrRent, squareFeet, address, numberOfFloors, hasParking, numberOfParkingSlots, hasInventory, inventoryType, buildingType, imageFilePath)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string EstateToText()
        {
            if (SaleOrRent == "Rent" && (HasInventory.HasValue && HasInventory.Value))
            {
                return $"{ID} | For Rent | Price: {Price} kr / month | SquareFeet: {SquareFeet} m^2 | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {NumberOfFloors} | Parking: {HasParking} | Number of Parking spaces: {NumberOfParkingSlots} | Inventory: {InventoryType} | Shop";
            }
            else if (SaleOrRent == "Sale" && (HasInventory.HasValue && HasInventory.Value))
            {
                return $"{ID} | For Sale | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {NumberOfFloors} | Parking: {HasParking} | Number of Parking spaces: {NumberOfParkingSlots} | Inventory: {InventoryType} | Shop";
            }
            else if (SaleOrRent == "Rent" && !(HasInventory.HasValue && HasInventory.Value))
            {
                return $"{ID} | For Rent | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {NumberOfFloors} | Parking: {HasParking} | Number of Parking spaces: {NumberOfParkingSlots} | Shop";
            }
            else
            {
                return $"{ID} | For Sale | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {NumberOfFloors} | Parking: {HasParking} | Number of Parking spaces: {NumberOfParkingSlots} | Shop";
            }
        }
    }
}
