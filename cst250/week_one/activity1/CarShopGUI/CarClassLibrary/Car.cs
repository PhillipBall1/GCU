using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }

        public Car(string make, string model, decimal price, int year, int miles)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Miles = miles;
        }

        public Car()
        {
            Make = "nothing yet";
            Model = "nothing yet";
            Price = 0;
            Year = 0;
            Miles = 0;
        }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} ${2} {3} {4}", Make, Model, Price, Year, Miles);
            }
        }
    }
}
