using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C.abstractClasses
{
    internal abstract class Institutional : Estate
    {
        protected string institutionType;

        protected Institutional(int price, Address address) : base(price, address)
        {
        }
    }
}
