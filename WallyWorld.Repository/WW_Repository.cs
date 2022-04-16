using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class WW_Repository
{
    //QUEUE: Represents a line F.I.F.O : First In First Out
    //Collection of apples and we can only grab the first in line
    private readonly Queue<Produce> _appleDB = new Queue<Produce>();
    private int _count; // this will allow us to autoincrment the count to assign it to the apple ID (unique identifier)

    //add an apple to the Queue
    public bool AddProduceItemToQueue(Produce produce)
    {
        if (produce is null)
        {
            return false;
        }
        //counting up by one (_count = _count + 1)
        _count++;
        //giving the apple a unique identifier
        produce.ID = _count;
        //adding the apple to the database
        _appleDB.Enqueue(produce);
        //letting the user know that the apple was added
        return true;
    }

    //lets see every apple in the inventory
    public Queue<Produce> ProduceItemsInInventory()
    {
        //gives us back all of the apples in the database(_appleDB)
        return _appleDB;
    }

    //lets see the only apple that we can get (b/c a Queue is F.I.F.O)
    public Produce GetCurrentProduceItem()
    {
        //if we have a count in the database greater than 0
        if (_appleDB.Count > 0)
        {
            //this give us who is next in line....
            var firstInLine = _appleDB.Peek();
            //now we will return whos next in line for future use...
            return firstInLine;
        }
        //if all else fails return null/nothing....
        return null;
    }

    //Remove the apple from the Queue
    //Dequeue happens here....
    public bool RemoveProduceItem()
    {
        if (_appleDB.Count > 0)
        {
            _appleDB.Dequeue();
            return true;
        }
        return false;
    }


}
