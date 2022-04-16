using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Apple : Produce
{
    public Apple(DateTime dateOfArrival)
    {
        Name = "Apple";
        dateOfArrival = DateTime.Now;
    }
}
