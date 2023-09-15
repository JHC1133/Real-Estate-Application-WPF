﻿using System;
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

        protected Commercial(int price, string street, string city, string zipcode, string country) : base(price, street, city, zipcode, country)
        {
        }
    }
}
