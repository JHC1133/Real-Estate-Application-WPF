using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modern_Real_Estates_by_Joar_H_C.abstractClasses;


namespace Modern_Real_Estates_by_Joar_H_C.Buildings.CommercialBuildings
{
    internal class Shop : Commercial
    {
        public Shop(int price, string street, string city, string zipcode, string country) : base(price, street, city, zipcode, country)
        {
        }

        public override void CalculatePricePerSqFeet()
        {
            PricePerSqFeet = Price / SquareFeet;
        }

        public override string EstateToText()
        {
            throw new NotImplementedException();
        }
    }
}
