using System;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

class Program 
{
    static int[] scores = new[] { 50, 66, 90, 34, 76, 12, 0, 100, 34, 88, 24, 6, 23, 29, 12, 70, 94, 82 };
    static void Main(string[] args)
    {

        //Console.WriteLine("Normal Scores");
        //foreach (var score in scores) { Console.WriteLine("Scores: {0}", score); }

        //Console.WriteLine("In-between 80-89");
        //foreach (var score in GetBetween(80, 89)) { Console.WriteLine("Scores: {0}", score); }

        Student[] students = GenerateRandomStudents(5);

        Console.WriteLine("BY NAME");

        var byName = students.OrderBy(student => student.name).ToList();

        foreach (var student in byName) { Console.WriteLine(student.ToString()); }
       

        Console.WriteLine("BY AGE");

        var byAge = students.OrderBy(student => student.age).ToList();

        foreach (var student in byAge) { Console.WriteLine(student.ToString()); }


        Console.WriteLine("BY GRADE");

        var byGrade = students.OrderBy(student => student.grade).ToList();

        foreach (var student in byGrade) { Console.WriteLine(student.ToString()); }

        Console.ReadLine();
    }

    static IOrderedEnumerable<int> GetBetween(int first, int last)
    {
        var list =
            from score in scores
            where score >= first && score <= last
            select score;

        var final =
            from score in list
            orderby score
            select score;

        return final;
    }

    static List<string> firstNames = new List<string>
    {
        "Phillip", "John", "Jason", "Michael", "Sophia", "Daniel", "Olivia", "William", "Ava", "Emily", "James", "Mia", "Ethan", "Peter"
        , "Earl"
    };

    static Student[] GenerateRandomStudents(int size)
    {
        var students = new Student[size];
        Random random = new Random();
        for (int i = 0; i < students.Length; i++)
        {
            Student student = new Student();

            student.name = firstNames[random.Next(firstNames.Count)];
            student.age = random.Next(18, 101);
            student.grade = random.Next(101);

            students[i] = student;
        }
        return students;
    }
}
