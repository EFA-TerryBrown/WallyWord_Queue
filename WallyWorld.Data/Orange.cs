using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Orange : Produce
{
    public Orange(DateTime dateOfArrival)
    {
        Name = "Orange";
        DateOfArrival = dateOfArrival;
    }
}
