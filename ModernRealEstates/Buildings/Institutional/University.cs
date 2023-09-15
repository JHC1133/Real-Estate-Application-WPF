using Modern_Real_Estates_by_Joar_H_C.abstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C.Buildings.InstitutionalBuildings
{
    internal class University : Institutional
    {
        public University(int price, Address address) : base(price, address)
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
