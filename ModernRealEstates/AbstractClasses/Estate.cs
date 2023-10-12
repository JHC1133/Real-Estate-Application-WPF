using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.Interfaces;

namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Estate : IEstate
    {
        protected int id; //Given randomly
        protected int numberOfRooms;
        protected int squareFeet;
        protected int price;
        protected int pricePerSqFeet;
        protected int? numberOfParkingSlots;
        protected int monthlyFee;
        protected int numberOfFloors;

        protected string country;
        protected string buildingType;
        protected string imageFilePath;

        protected bool? hasParking;
        protected bool? hasInventory;

        protected static int staticID;

        protected Address address;

        public int ID { get => id; set => id = value; }
        public Address Address { get => address; set => address = value; }
        public int NumberOfRooms { get => numberOfRooms; set => numberOfRooms = value; }
        public int SquareFeet { get => squareFeet; set => squareFeet = value; }
        public int Price { get => price; set => price = value; }
        public int PricePerSqFeet { get => pricePerSqFeet; set => pricePerSqFeet = value; }
        public int MonthlyFee { get => monthlyFee; set => monthlyFee = value; }
        public string Country { get => country; set => country = value; }
        public string BuildingType { get => buildingType; set => buildingType = value; }
        public bool? HasParking { get => hasParking; set => hasParking = value; }
        public bool? HasInventory { get => hasInventory; set => hasInventory = value; }
        public int? NumberOfParkingSlots { get => numberOfParkingSlots; set => numberOfParkingSlots = value; }
        public int NumberOfFloors { get => numberOfFloors; set => numberOfFloors = value; }
        public string ImageFilePath { get => imageFilePath; set => imageFilePath = value; }


        public Estate(int price, Address address, string buildingType, string imageFilePath)
        {

        }

        public virtual void CalculatePricePerSqFeet()
        {

        }

        public virtual string GetStreet()
        {
            return Address.Street;
        }

        public virtual string GetZipcode()
        {
            return Address.Zipcode;
        }
        
        public virtual string GetCity()
        {
            return Address.City;
        }

        public override string ToString()
        {
            return "Default Text";
        }

        // Used for binding in XAML
        //public string DisplayText => EstateToText();

        
    }
}
