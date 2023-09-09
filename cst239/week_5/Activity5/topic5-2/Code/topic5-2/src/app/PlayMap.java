package app;

import java.util.HashMap;
import java.util.Map;

public class PlayMap
{
	public static void main(String[] args)
	{
		Map<Integer, Integer> intMap = new HashMap<Integer, Integer>();
		intMap.put(1, 1);
		intMap.put(2, 2);
		
		Map<Integer, String> stringMap = new HashMap<Integer, String>();
		stringMap.put(1, "One");
		stringMap.put(2, "Two");
		
		Map<String, String> namegMap = new HashMap<String, String>();
		namegMap.put("FirstName", "Phillip");
		namegMap.put("LastName", "Ball");
		
		System.out.printf("Name Map Tests: size is %d and is empty %b\n", namegMap.size(), namegMap.isEmpty());
		
		for (Map.Entry<String, String> m : namegMap.entrySet())
		{
			System.out.printf("Key: %s Value: %s\n", m.getKey(), m.getValue());
		}
		
		intMap.clear();
		stringMap.remove(1);
		stringMap.clear();
		namegMap.clear();
	}
}
