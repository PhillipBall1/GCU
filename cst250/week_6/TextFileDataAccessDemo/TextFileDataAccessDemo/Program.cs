using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\demos\text.txt";
        string outPath = @"C:\demos\peopleOut.txt";

        List<string> lines = File.ReadAllLines(filePath).ToList();
        List<string> output = new List<string>();

        foreach(string line in lines)
        {
            string[] split = line.Split(',');

            if (split.Length < 3)
            {
                Console.WriteLine("This line \'" + line + "\' does not meet the requirements." );
                continue;
            }

            Person person = new Person(split[0], split[1], split[2]);
            Console.WriteLine(person.Print());
            output.Add(person.Print());
        }
        File.WriteAllLines(outPath, output);
        Console.ReadLine();
    }
}