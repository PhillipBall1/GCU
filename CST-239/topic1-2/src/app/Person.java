package app;

import java.util.Random;

public class Person
{
	private int age;
	private String name;
	private float height;
	private float weight;
	/**
	 * The Person Class constructor that allows for getters if other classes were to get involved.
	 * @param age
	 * @param name
	 * @param height
	 * @param weight
	 */
	public Person(int age, String name, float height, float weight)
	{
		this.age = age;
		this.name = name;
		this.height = height;
		this.weight = weight;
	}
	
	public int GetAge()
	{
		return age;
	}
	public String GetName()
	{
		return name;
	}
	public float GetHeight()
	{
		return height;
	}
	public float GetWeight()
	{
		return weight;
	}
	/**
	 * Takes in a name from "GetRandomName()" and a random float (generated inside of the main class)
	 * then combines the two so it can output a sentence such as:
	 * System.out.println(name + " is going to bed for " + amountOfSleep + " minutes." + "\n\n...\n");
	 * @param name
	 * @param amountOfSleep
	 */
	public void Sleep(String name, float amountOfSleep)
	{
		System.out.println(name + " is going to bed for " + amountOfSleep + " minutes." + "\n\n...\n");
	}
	/**
	 * Takes in a name from "GetRandomName()" and a random float (generated inside of the main class)
	 * then combines the two so it can output a sentence such as:
	 * System.out.println(name + " woke up after " + amountOfSleep + " minutes of sleep!");
	 * @param name
	 * @param amountOfSleep
	 */
	public void Wakeup(String name, float amountOfSleep)
	{
		System.out.println(name + " woke up after " + amountOfSleep + " minutes of sleep!");
	}
	/**
	 * Grabbing a random name through a random number => switch case on the random number => displaying
	 * a separate name per number.
	 * @return
	 */
	public static String GetRandomName() 
	{
		Random random = new Random();
		int num = random.nextInt(6);
		switch (num)
		{
		case 0:  return "Phillip";
		case 1:  return "Ryan";
		case 2:  return "Joey";
		case 3:  return "Pete";
		case 4:  return "Bob";
		case 5:  return "John";
		case 6:  return "Smith";
		}
		return null;
	}
	/**
	 * Main generates a person, who has a random age and name, then also generates a height and weight.
	 * @param args
	 */
	public static void main(String args[]) 
	{
		Random random = new Random();
		float sleepTime = random.nextFloat();
		float sleepFinal = Math.round(sleepTime * 1000);
		Person person = new Person(random.nextInt(80), GetRandomName() , (float)6.3, 160);
		person.Sleep(person.name, sleepFinal);
		person.Wakeup(person.name, sleepFinal);
	}
}
