using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    //I HAVE TO MAKE AN INSTANCE OF THE 'WW_Repository to access the repository methods
    private readonly WW_Repository _wwRepo = new WW_Repository();

    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome To Wally World!!!!");
            System.Console.WriteLine("Please Make a Selection\n" +
             "1. Add Produce Item to Queue\n" +
             "2. View all Produce Items\n" +
             "3. Buy a Produce Item\n" +
             "4. Close Application\n");


            var userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    AddProduceItemToQueue();
                    break;
                case 2:
                    ViewAllApplesInQueue();
                    break;
                case 3:
                    BuyProduceItem();
                    break;
                case 4:
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection.");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private void AddProduceItemToQueue()
    {
        Console.Clear();
        System.Console.WriteLine("What do you want to buy:\n" +
        "1. Apple\n" +
        "2. Orange");

        var userInput = int.Parse(Console.ReadLine());
        switch (userInput)
        {
            case 1:
                CreateApple();
                break;
            case 2:
                CreateOrange();
                break;
            default:
                System.Console.WriteLine("Invalid Selection.");
                break;
        }

        PressAnyKeyToContinue();
    }


    //helper methods
    private void CreateApple()
    {
        Console.Clear();
        System.Console.WriteLine("When was this apple purchased?");
        var userInput = DateTime.Parse(Console.ReadLine()); //  Month/day/year
        Apple apple = new Apple(userInput);
        //access the repo to add this item.
        if (_wwRepo.AddProduceItemToQueue(apple))
        {
            System.Console.WriteLine("Apple WAS ADDED to the Inventory!");
        }
        else
        {
            System.Console.WriteLine("Apple WAS NOT ADDED to the Inventory!");
        }
        PressAnyKeyToContinue();
    }

    private void CreateOrange()
    {
        Console.Clear();
        System.Console.WriteLine("When was this orange purchased?");
        var userInput = DateTime.Parse(Console.ReadLine()); //  Month/day/year
        Orange orange = new Orange(userInput);
        //access the repo to add this item.
        if (_wwRepo.AddProduceItemToQueue(orange))
        {
            System.Console.WriteLine("Apple WAS ADDED to the Inventory!");
        }
        else
        {
            System.Console.WriteLine("Apple WAS NOT ADDED to the Inventory!");
        }

        PressAnyKeyToContinue();
    }

    private void ViewAllApplesInQueue()
    {
        Console.Clear();
        //grab the collection of produce items w/n the repository instance (line: 10)
        var produceItems = _wwRepo.ProduceItemsInInventory();

        //now we will loop through all of the item in the produceItems virable
        foreach (var item in produceItems)
        {
            //use helper method
            DisplayProduceData(item);
        }

        PressAnyKeyToContinue();
    }

    private void BuyProduceItem()
    {
        Console.Clear();
        //we want to look in our repository and find the one thats next in line
        var produceItem = _wwRepo.GetCurrentProduceItem();
        if (produceItem != null)
        {
            Console.Clear();
            DisplayProduceData(produceItem);
            System.Console.WriteLine("Do you want to purchase this Item? y/n");
            var userInput = Console.ReadLine();
            if (userInput == "Y".ToLower() || userInput == "Y")
            {
                //acces the repository to remove the item from the queue
                if (_wwRepo.RemoveProduceItem())
                {
                    System.Console.WriteLine($"Thank you for your pruchase, you bought an {produceItem.Name}");
                }
                else
                {
                    System.Console.WriteLine("Sorry you did not buy the item.");
                }
            }
        }
        else
        {
            System.Console.WriteLine("Sorry there are no more produce items.");
        }

        PressAnyKeyToContinue();
    }

    //helper method
    private void DisplayProduceData(Produce produce)
    {
        System.Console.WriteLine($"ProduceID: {produce.ID}\n" +
        $"ProduceName: {produce.Name}\n" +
        $"DateOfArrival: {produce.DateOfArrival}\n");
    }
    private bool CloseApplication()
    {
        Console.Clear();
        PressAnyKeyToContinue();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    private void Seed()
    {
        Apple apple1 = new Apple(new DateTime(2022, 04, 16));
        Orange orange = new Orange(new DateTime(2022, 04, 16));
        Apple apple3 = new Apple(new DateTime(2022, 04, 16));
        Apple apple4 = new Apple(new DateTime(2022, 04, 16));

        _wwRepo.AddProduceItemToQueue(apple1);
        _wwRepo.AddProduceItemToQueue(orange);
        _wwRepo.AddProduceItemToQueue(apple3);
        _wwRepo.AddProduceItemToQueue(apple4);
    }
}
