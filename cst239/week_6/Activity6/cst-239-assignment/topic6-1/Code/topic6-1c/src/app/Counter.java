package app;

public class Counter
{
	static int count = 0;
	
	static synchronized void Increment() 
	{
		count = count + 1;
	}
	
	static int GetCount()
	{
		return count;
	}
}
