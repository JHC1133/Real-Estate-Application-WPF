using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractClasses
{
    public abstract class Person
    {
        protected Address address;

        public Address Address { get => address; set => address = value; }

        public Person(Address adress)
        {

        }
    }
}
