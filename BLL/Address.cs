using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Address
    {
        private string street, city, zipcode, country;

        public Address()
        {

        }

        public Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
        }

        public Address(string street, string city, string zipcode, string country)
        {
            Street = street;
            City = city;
            Zipcode = zipcode;
            Country = country;

        }


        public string City { get => city; set => city = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string Street { get => street; set => street = value; }
        public string Country { get => country; set => country = value; }
    }
}
