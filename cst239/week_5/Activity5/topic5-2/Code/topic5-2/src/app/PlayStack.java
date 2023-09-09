package app;

import java.util.Iterator;
import java.util.Stack;

public class PlayStack
{
	public static void main(String[] args)
	{
		Stack<String> stringStack = new Stack<String>();
		stringStack.push("Phillip Ball");
		stringStack.push("Phillip Ball");
		stringStack.push("William Ball");
		stringStack.push("Chelsea Ball");
		stringStack.push("Troy Ball");
		
		Stack<Integer> intStack = new Stack<Integer>();
		intStack.push(1);
		intStack.push(-1);
		intStack.push(5);
		intStack.push(10);
		intStack.push(120);
		
		
		System.out.println(intStack);
		System.out.printf("Integer Stack Tests: size is %d and second element is %d\n",
				intStack.size(), intStack.elementAt(1));
		
		Iterator<String> stringIterator = stringStack.iterator();
		
		while (stringIterator.hasNext())
		{
			System.out.println(stringIterator.next());
			
		}
	}
}
