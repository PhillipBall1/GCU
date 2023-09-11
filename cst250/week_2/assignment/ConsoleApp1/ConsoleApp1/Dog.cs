using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Dog : Animal, IDomesticated
    {
        public Dog()
        {
            Console.WriteLine("Dog constructor. Good puppy");
        }

        public new void Talk()
        {
            Console.WriteLine("Bark Bark Bark");
        }

        public override void Sing()
        {
            Console.WriteLine("Hooooowwwwlllll!");
        }

        public void Fetch(string thing)
        {
            Console.WriteLine("Oh boy, here is your " + thing + ". Let's do it again!");
        }

        public void TouchMe()
        {
            Console.WriteLine("Please scrath behind my ears");
        }

        public void FeedMe()
        {
            Console.WriteLine("Its suppertime. The very best time of the day!!!");
        }
    }
}
