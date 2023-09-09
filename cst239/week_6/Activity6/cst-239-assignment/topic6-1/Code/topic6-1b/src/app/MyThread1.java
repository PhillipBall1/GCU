package app;

import java.lang.Thread;
import java.util.Iterator;

public class MyThread1 extends Thread
{
	public void run()
	{
		for(int i = 0; i < 100; i++)
		{
			System.out.println("MyThread1 is running iteration " + i);
		}
		try
		{
			Thread.sleep(1000);
		} 
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
}
