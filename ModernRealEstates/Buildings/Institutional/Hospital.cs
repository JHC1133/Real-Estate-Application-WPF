using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C
{
    internal class Hospital : Institutional
    {
        public Hospital(int price, int monthlyFee, Address address, int squareFeet, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string buildingType) 
            : base(price, monthlyFee, address, squareFeet, numberOfFloors, hasParking, numberOfParkingSlots, hasInventory, buildingType)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string EstateToText()
        {
            return $"{ID} | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Fee: {MonthlyFee} kr | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {numberOfFloors} | Rooms: {numberOfRooms} | Parking: {hasParking} | Number of Parking Spaces: {numberOfParkingSlots} | Inventory: {hasInventory} | Hospital";

        }
    }
}
