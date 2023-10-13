using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Person
{
    string firstName;
    string lastName;
    string url;

    public Person(string firstName, string lastName, string website)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.url = website;
    }

    public string GetFirstName() { return firstName; }
    public string GetLastName() { return lastName; }
    public string GetWebsite() { return url; }

    public string Print()
    {
        return "First Name: " + firstName + " Last Name: " + lastName + " URL: " + url;
    }
}
