using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Institutional : Estate
    {
        protected bool hasParking;
        protected bool hasInventory;
        protected int? numberOfParkingSlots;
        protected int numberOfFloors;

        protected Institutional(int price, int monthlyFee, Address address, int squareFeet, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string buildingType) 
            : base(price, address, buildingType)
        {
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.hasParking = hasParking;
            this.numberOfParkingSlots = numberOfParkingSlots;
            this.hasInventory = hasInventory;
            this.numberOfFloors = numberOfFloors;
            this.MonthlyFee = monthlyFee;
            this.BuildingType = buildingType;
        }
    }
}
