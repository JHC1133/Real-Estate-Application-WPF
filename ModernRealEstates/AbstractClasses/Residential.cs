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

        public Residential(string street, string city, string zipcode, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage)
        {
            this.id = staticID++;
            Address = new Address(street, city, zipcode);
            this.NumberOfBedrooms = numberOfBedrooms;
            this.NumberOfBathrooms = numberOfBathrooms;
            this.hasGarage = hasGarage;
        }

    }
}
