using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractClasses
{
    public class Residential : Estate
    {

        protected int numberOfBedrooms;
        protected int numberOfBathrooms;
        protected bool? hasGarage;
        protected List<string> amenities; // Create an checklist for amenities like pool, backyard etc

        public int NumberOfBedrooms { get => numberOfBedrooms; set => numberOfBedrooms = value; }
        public int NumberOfBathrooms { get => numberOfBathrooms; set => numberOfBathrooms = value; }
        public bool? HasGarage { get => hasGarage; set => hasGarage = value; }

        public Residential(int price, int squareFeet, int monthlyFee, Address address, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage, string buildingType, string imageFilePath)
            : base(price, address, buildingType, imageFilePath)
        {
            id = staticID++;
            Address = address;
            Price = price;
            SquareFeet = squareFeet;
            MonthlyFee = monthlyFee;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfRooms = numberOfRooms;
            this.hasGarage = hasGarage;
            BuildingType = buildingType;
            ImageFilePath = imageFilePath;
        }

    }
}
