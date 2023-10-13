using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class Student
{
    public string name { get; set; }
    public int age { get; set; }
    public double grade { get; set; }

    public string ToString(){ return "Name: " + name + " Age: " + age + " Grade: " + grade;  }
}

