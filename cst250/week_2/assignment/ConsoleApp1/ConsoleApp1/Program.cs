using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Animal beast = new Animal();

            beast.Talk();
            beast.Greet();
            beast.Sing();
            */

            

            Cow cow = new Cow();

            cow.Talk();
            cow.Sing();
            cow.MilkMe();

            Sheep sheep = new Sheep();

            sheep.Talk();
            sheep.Sing();

            Horse horse = new Horse();

            horse.Talk();
            horse.Greet();
            horse.RideMe();

            Console.ReadLine(); 
        }
    }
}
