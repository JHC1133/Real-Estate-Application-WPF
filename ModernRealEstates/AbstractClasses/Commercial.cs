using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Commercial : Estate
    {
        protected int leaseTerm;
        protected string businessType;
        protected string saleOrRent;
        protected string inventoryType;

        public string SaleOrRent { get => saleOrRent; set => saleOrRent = value; }
        public string InventoryType { get => inventoryType; set => inventoryType = value; }

        protected Commercial(int price, string saleOrRent,  int squareFeet, Address address, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string inventoryType, string buildingType) : base(price, address, buildingType)
        {
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.NumberOfFloors = numberOfFloors;
            this.HasParking = hasParking;
            this.NumberOfParkingSlots = numberOfParkingSlots;
            this.HasInventory = hasInventory;
            this.InventoryType = inventoryType;
            this.BuildingType = buildingType;
            this.SaleOrRent = saleOrRent;

        }
    }
}
