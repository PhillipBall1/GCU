using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cow : Animal, IMilkable
    {
        public Cow()
        {
            Console.WriteLine("Cow constructor");
        }

        public new void Talk()
        {
            Console.WriteLine("Moo");
        }

        public override void Sing()
        {
            Console.WriteLine("Moooooooo!");
        }

        public void MilkMe()
        {
            Console.WriteLine("Millllkkkkkkk");
        }
    }
}
