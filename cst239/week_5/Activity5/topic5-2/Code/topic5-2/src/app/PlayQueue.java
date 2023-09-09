package app;

import java.util.Iterator;
import java.util.LinkedList;
import java.util.Queue;

public class PlayQueue
{
	public static void main(String[] args)
	{
		Queue<String> stringQueue = new LinkedList<String>();
		stringQueue.offer("Phillip Ball");
		stringQueue.add("Phillip Ball");
		stringQueue.offer("William Ball");
		stringQueue.add("Chelsea Ball");
		stringQueue.add("Troy Ball");
		
		Queue<Integer> integerQueue = new LinkedList<Integer>();
		integerQueue.offer(1);
		integerQueue.add(-1);
		integerQueue.offer(5);
		integerQueue.add(10);
		integerQueue.add(120);
		
		
		System.out.println(integerQueue);
		System.out.printf("Integer Queue Tests: size is %d and head element is %d\n",
				integerQueue.size(), integerQueue.peek());
		
		Iterator<String> stringIterator = stringQueue.iterator();
		
		while (stringIterator.hasNext())
		{
			System.out.println(stringIterator.next());
			
		}
	}
}
