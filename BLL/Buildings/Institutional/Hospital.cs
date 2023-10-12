using BLL.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Hospital : Institutional
    {
        public Hospital(int price, int monthlyFee, Address address, int squareFeet, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string buildingType, string imageFilePath)
            : base(price, monthlyFee, address, squareFeet, numberOfFloors, hasParking, numberOfParkingSlots, hasInventory, buildingType, imageFilePath)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string ToString()
        {
            return $"{ID} | Price: {Price} kr | SquareFeet: {SquareFeet} m^2 | Fee: {MonthlyFee} kr | Address: {Address.Street}, {Address.City}, {Address.Zipcode}, {Address.Country} | Floors: {numberOfFloors} | Parking: {hasParking} | Parking Spaces: {numberOfParkingSlots} | Inventory: {hasInventory} | {BuildingType}";

        }
    }
}
