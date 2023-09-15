using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Commercial : Estate
    {

        protected int numberOfFloors;
        protected int leaseTerm;
        protected string businessType;
        protected string saleOrRent;
        protected bool hasParking;
        protected int? numberOfParkingSlots;

        protected Commercial(int price, string saleOrRent,  int squareFeet, Address address, int numberOfFloors, bool hasParking, int? numberOfParkingSlots) : base(price, address)
        {
            this.id = staticID++;
            this.Address = address;
            this.Price = price;
            this.SquareFeet = squareFeet;
            this.hasParking = hasParking;
            this.numberOfParkingSlots = numberOfParkingSlots;

        }
    }
}
