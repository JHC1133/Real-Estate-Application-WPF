using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Residential : Estate
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
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.MonthlyFee = monthlyFee;
            this.NumberOfBedrooms = numberOfBedrooms;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.NumberOfRooms = numberOfRooms;
            this.hasGarage = hasGarage;
            this.BuildingType = buildingType;
            this.ImageFilePath = imageFilePath;
        }

    }
}
