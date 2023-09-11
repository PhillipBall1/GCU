using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Horse : Animal, IRidable
    {
        public Horse()
        {
            Console.WriteLine("Horse constructor");
        }

        public new void Talk()
        {
            Console.WriteLine("Howdy");
        }

        public new void Greet()
        {
            Console.WriteLine("Want to go for a ride?");
        }

        public void RideMe()
        {
            Console.WriteLine("Get on partner");
        }
    }
}
