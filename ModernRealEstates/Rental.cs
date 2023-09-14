﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.Buildings.ResidentialBuildings;

namespace Modern_Real_Estates_by_Joar_H_C
{
    internal class Rental : Apartment
    {
        public Rental(string street, string city, string zipcode, int numberOfBedrooms, int numberOfBathrooms, bool hasGarage) : base(street, city, zipcode, numberOfBedrooms, numberOfBathrooms, hasGarage)
        {
        }
    }
}
