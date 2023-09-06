package app;

import java.util.Arrays;

public class Test
{

	public static void main(String[] args)
	{
		Person person1 = new Person("Will", "Ball", 22);
		Person person2 = new Person("Chelsea", "Ball", 18);
		Person person3 = new Person(person1);
		
		if(person1 == person2)
			System.out.println("These persons are identical using ==");
		else 
			System.out.println("These persons are not identical using ==");
		
		if(person1.equals(person2))
			System.out.println("These persons are identical using equals()");
		else 
			System.out.println("These persons are not identical using equals()");
		
		if(person1.equals(person3))
			System.out.println("This copied person is identical using equals()");
		else 
			System.out.println("This copied person is not identical using equals()");
		
		System.out.println(person1);
		System.out.println(person2.toString());
		System.out.println(person3);
			
		person1.Walk();
		person1.Run();
		System.out.println("Person 1 is running " + person1.isRunning());
		person1.Walk();
		System.out.println("Person 1 is running " + person1.isRunning());
		
		Person[] persons = new Person[4];
		persons[0] = new Person("Phillip", "Ball", 20);
		persons[1] = new Person("William", "Ball", 22);
		persons[2] = new Person("Chelsea", "Ball", 18);
		persons[3] = new Person("Troy", "Ball", 23);
		Arrays.sort(persons);
		for(int i = 0; i < persons.length; i++) 
		{
			System.out.println(persons[i]);
		}

	}

}
