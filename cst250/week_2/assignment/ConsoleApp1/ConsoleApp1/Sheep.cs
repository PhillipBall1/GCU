using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Sheep : Animal
    {
        public Sheep()
        {
            Console.WriteLine("Sheep constructor");
        }

        public new void Talk()
        {
            Console.WriteLine("Bah");
        }

        public override void Sing()
        {
            Console.WriteLine("Bahahaaaaaa");
        }
    }
}
