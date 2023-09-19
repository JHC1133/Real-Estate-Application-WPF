using Modern_Real_Estates_by_Joar_H_C;
using ModernRealEstates.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernRealEstates.Persons
{
    internal class Buyer : Person
    {
        public Buyer(Address adress) : base(adress)
        {
            this.Address = address;
        }
    }
}
