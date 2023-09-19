using Modern_Real_Estates_by_Joar_H_C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernRealEstates.AbstractClasses
{
    internal abstract class Person
    {
        protected Address address;

        public Address Address { get => address; set => address = value; }

        public Person(Address adress)
        {
            
        }
    }
}
