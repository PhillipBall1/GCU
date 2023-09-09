package app;

public class MyThread2 implements Runnable
{
	public void run()
	{
		for(int i = 0; i < 100; i++)
		{
			System.out.println("MyThread2 is running iteration " + i);
			try
			{
				Thread.sleep(500);
			} 
			catch (Exception e)
			{
				e.printStackTrace();
			}
		}
	}
}
