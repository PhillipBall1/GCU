package app;

import java.util.Random;

public class CounterThread extends Thread
{
	public void run()
	{
		try
		{
			Random random = new Random();
			int sleeper = random.ints(1, 100 + 1).findFirst().getAsInt();
			Thread.sleep(sleeper);
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
		Counter.Increment();
	}
}
