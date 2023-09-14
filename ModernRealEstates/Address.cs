using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C
{
    internal class Address
    {
        private string street, city, zipcode;

        

        public Address(string street, string city, string zipcode)
        {
            this.Street = street;
            this.City = city;
            this.Zipcode = zipcode;
        }


        public string City { get => city; set => city = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string Street { get => street; set => street = value; }
    }
}
