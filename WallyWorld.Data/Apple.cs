using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//? 1. Data layer
//? 2. Repository Layer
//? 3. UI layer

public class Apple : Produce
{
    public Apple(DateTime dateOfArrival)
    {
        Name = "Apple";
        dateOfArrival = DateTime.Now;
    }
}
