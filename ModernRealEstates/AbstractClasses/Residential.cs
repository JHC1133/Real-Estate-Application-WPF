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
        protected bool hasGarage;
        protected List<string> amenities; // Create an checklist for amenities like pool, backyard etc

        public int NumberOfBedrooms { get => numberOfBedrooms; set => numberOfBedrooms = value; }
        public int NumberOfBathrooms { get => numberOfBathrooms; set => numberOfBathrooms = value; }

        public Residential(int price, int squareFeet, int monthlyFee, string street, string city, string zipcode, string country, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(price, street, city, zipcode, country)
        {
            this.id = staticID++;
            Address = new Address(street, city, zipcode);
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.MonthlyFee = monthlyFee;
            this.Country = country;
            this.NumberOfBedrooms = numberOfBedrooms;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.NumberOfRooms = numberOfRooms;
            this.hasGarage = hasGarage;
        }

        public Residential(int price, int squareFeet, int monthlyFee, Address address, int numberOfRooms, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(price, address)
        {
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.MonthlyFee = monthlyFee;
            this.Country = country;
            this.NumberOfBedrooms = numberOfBedrooms;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.NumberOfRooms = numberOfRooms;
            this.hasGarage = hasGarage;
        }

    }
}
