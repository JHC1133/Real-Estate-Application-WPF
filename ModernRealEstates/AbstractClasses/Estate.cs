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
        protected int monthlyFee;

        protected static int staticID;

        protected Address address;

        public int ID { get => id; set => id = value; }
        public Address Address { get => address; set => address = value; }
        public int NumberOfRooms { get => numberOfRooms; set => numberOfRooms = value; }
        public int SquareFeet { get => squareFeet; set => squareFeet = value; }
        public int Price { get => price; set => price = value; }
        public int PricePerSqFeet { get => pricePerSqFeet; set => pricePerSqFeet = value; }
        public int MonthlyFee { get => monthlyFee; set => monthlyFee = value; }

        public abstract void CalculatePricePerSqFeet();

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

        public virtual string EstateToText()
        {
            return $"Address: {Address.Street}, {Address.City}, {Address.Zipcode}";
        }

        // Used for binding 
        public string DisplayText => EstateToText();
    }
}
