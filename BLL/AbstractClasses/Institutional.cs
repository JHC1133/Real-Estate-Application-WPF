using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractClasses
{
    public abstract class Institutional : Estate
    {
        protected Institutional(int price, int monthlyFee, Address address, int squareFeet, int numberOfFloors, bool hasParking, int? numberOfParkingSlots, bool hasInventory, string buildingType, string imageFilePath)
            : base(price, address, buildingType, imageFilePath)
        {
            id = staticID++;
            Address = address;
            Price = price;
            SquareFeet = squareFeet;
            HasParking = hasParking;
            this.numberOfParkingSlots = numberOfParkingSlots;
            HasInventory = hasInventory;
            NumberOfFloors = numberOfFloors;
            MonthlyFee = monthlyFee;
            BuildingType = buildingType;
            ImageFilePath = imageFilePath;
        }
    }
}
