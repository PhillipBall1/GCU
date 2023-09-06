package app;

public class Person implements PersonInterface, Comparable<Person>
{
	private String firstName = "Phillip";
	private String lastName = "Ball";
	private int age;
	private boolean running;
	
	public Person(String firstName, String lastName, int age) 
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.age = age;
	}
	
	public Person(Person person) 
	{
		this.firstName = person.GetFirstName();
		this.lastName = person.GetLastName();
		this.age = person.GetAge();
	}
	
	public void Walk() 
	{
		System.out.println("I am walking");
		running = false;
	}
	public void Run()
	{
		System.out.println("I am running");
		running = true;
	}
	public boolean isRunning() 
	{
		return running;
	}
	
	public String GetFirstName()
	{
		return firstName;
	}
	public String GetLastName()
	{
		return lastName;
	}
	public int GetAge()
	{
		return age;
	}
	
	@Override
	public boolean equals(Object other) 
	{
		if(other == this) 
		{
			System.out.println("I am here in other == this");
			return true;
		}
		if(other == null) 
		{
			System.out.println("I am here in other == null");
			return false;
		}
		if(getClass() != other.getClass())
		{
			System.out.println("I am here in getClass() != other.getClass()");
			return false;
		}
		Person person = (Person)other;
		return (this.firstName == person.firstName && this.lastName == person.lastName);
	}
	
	@Override
	public String toString() 
	{
		return "My class is " + getClass() + " " + this.firstName + " " + this.lastName + " " + this.age;
 	}
	
	@Override
	public int compareTo(Person p) 
	{
		int value = this.lastName.compareTo(p.lastName);
		if(value == 0) 
		{
			return p.GetAge() - this.age;
		}
		else 
		{
			return value;
		}
	}
}
