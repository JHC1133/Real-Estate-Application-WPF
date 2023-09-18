using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Commercial : Estate
    {

        protected int numberOfFloors;
        protected int leaseTerm;
        protected string businessType;
        protected string saleOrRent;
        protected string inventoryType;
        protected bool hasParking;
        protected bool hasInventory;
        protected int? numberOfParkingSlots;

        protected Commercial(int price, string saleOrRent,  int squareFeet, Address address, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string inventoryType, string buildingType) : base(price, address, buildingType)
        {
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.numberOfFloors = numberOfFloors;
            this.hasParking = hasParking;
            this.numberOfParkingSlots = numberOfParkingSlots;
            this.hasInventory = hasInventory;
            this.inventoryType = inventoryType;
            this.BuildingType = buildingType;

        }
    }
}
