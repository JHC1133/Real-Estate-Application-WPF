using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modern_Real_Estates_by_Joar_H_C.Interfaces
{
    internal interface IEstate
    {

        int ID { get; set; }

        Address Address { get; set; }


        string GetCity();
        string GetStreet();
        string GetZipcode();

    }
}
