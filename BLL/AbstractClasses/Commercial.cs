using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.AbstractClasses
{
    public class Commercial : Estate
    {
        protected int leaseTerm;
        protected string businessType;
        protected string saleOrRent;
        protected string inventoryType;

        public string SaleOrRent { get => saleOrRent; set => saleOrRent = value; }
        public string InventoryType { get => inventoryType; set => inventoryType = value; }

        protected Commercial(int price, string saleOrRent, int squareFeet, Address address, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string inventoryType, string buildingType, string imageFilePath)
            : base(price, address, buildingType, imageFilePath)
        {
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.NumberOfFloors = numberOfFloors;
            this.HasParking = hasParking;
            this.NumberOfParkingSlots = numberOfParkingSlots;
            this.HasInventory = hasInventory;
            InventoryType = inventoryType;
            this.BuildingType = buildingType;
            SaleOrRent = saleOrRent;
            this.ImageFilePath = imageFilePath;

        }
    }
}
