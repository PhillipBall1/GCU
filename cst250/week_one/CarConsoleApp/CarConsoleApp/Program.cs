
using CarClassLibrary;
using System;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.ConstrainedExecution;

namespace CarShopConsoleApp
{
    public class Program
    {
        static Store CarStore = new Store();

        static void Main(string[] args)
        {
            Console.Out.WriteLine("Welcome to the car store. First create  some cars and include them into the store inventory. " +
                "Then you may add cars to the cart. Finally you may checkout, which will calculate your total bill.");

            int action = chooseAction();

            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.Out.WriteLine("You chose to add a new car to the store:");

                        Car newCar = new Car();

                        Console.Out.Write("What is the car make?");
                        newCar.Make = Console.ReadLine();

                        Console.Out.Write("What is the car model?");
                        newCar.Model = Console.ReadLine();

                        Console.Out.Write("What is the car price?");

                        try
                        {
                            newCar.Price = int.Parse(Console.ReadLine());
                        }
                        catch 
                        {
                            Console.Out.WriteLine("Input needs to be a number");
                            action = 0;
                        }


                        Console.Out.Write("What is the year of the car?");

                        try
                        {
                            newCar.Year = int.Parse(Console.ReadLine());
                        }
                        catch 
                        {
                            Console.Out.WriteLine("Input needs to be a number");
                            action = 0;
                        }

                        Console.Out.Write("What is the car's mileage?");

                        try
                        {
                            newCar.Miles = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Out.WriteLine("Input needs to be a number");
                            action = 0;
                        }

                        CarStore.CarList.Add(newCar);
                        printStoreInventory(CarStore);
                        break;
                    case 2:
                        printStoreInventory(CarStore);

                        int choice = 0;

                        Console.Out.Write("Which car would you like to add to your cart?");

                        try
                        {
                            choice = int.Parse(Console.ReadLine());
                        }
                        catch 
                        {
                            Console.Out.WriteLine("Input needs to be a number");
                            action = 0;
                        }
                        CarStore.ShoppingList.Add(CarStore.CarList[choice]);

                        printShoppingCart(CarStore);
                        break;
                    case 3:
                        printShoppingCart(CarStore);
                        Console.Out.WriteLine("Your total cost is ${0}", CarStore.checkout());
                        break;
                }
                action = chooseAction();
            }
        }

        static public int chooseAction()
        {
            int choice = 0;

            Console.Out.WriteLine("Choose an action:\n|0|quit \n|1|add a car \n|2|add item to cart \n|3|checkout");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }

        static public void printStoreInventory(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in the store inventory:");

            int i = 0;
            foreach (var c in carStore.CarList)
            {
                Console.Out.WriteLine("Car # = {0} {1}", i, c.Display);
                i++;
            }

        }

        static public void printShoppingCart(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in the shopping cart:");

            int i = 0;
            foreach (var c in carStore.ShoppingList)
            {
                Console.Out.WriteLine("Car # = {0} {1}", i, c.Display);
                i++;
            }
        }
    }
}
