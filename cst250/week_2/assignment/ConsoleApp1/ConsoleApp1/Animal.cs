using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal Constructor");
        }

        public void Greet()
        {
            Console.WriteLine("Animal says Hello");
        }

        public void Talk()
        {
            Console.WriteLine("Animal talking");
        }

        public virtual void Sing()
        {
            Console.WriteLine("Animal song");
        }
    };
}
