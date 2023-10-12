using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
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
