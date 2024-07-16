package aTest;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;

public class Test
{
	public static <E> List<E> TestArray(E[] inputArray) 
	{
		List<E> testList = new ArrayList<E>();
		
		for(int i = 0; i < inputArray.length; i++) 
		{
			testList.add(inputArray[i]);
		}

		return testList;
	}
	
	public static void main(String[] args)
	{
		LinkedList<Integer> g = new LinkedList<Integer>();
		
		Integer[] intArray = new Integer[4];
		intArray[0] = 23;
		intArray[1] = 64;
		intArray[2] = 13;
		intArray[3] = 1003;
		System.out.print("Int Array: ");
		for(int i = 0; i < intArray.length; i++)
		{
			System.out.print(intArray[i] + ", ");
		}
		System.out.println("\nInt Array to List: " + TestArray(intArray) + "\n\n");
		
		String[] stringArray = new String[3];
		stringArray[0] = "Dog";
		stringArray[1] = "Cat";
		stringArray[2] = "Lion";
		System.out.print("String Array: ");
		for(int i = 0; i < stringArray.length; i++)
		{
			System.out.print(stringArray[i] + ", ");
		}
		System.out.println("\nString Array to List: " + TestArray(stringArray));
		
	}
}