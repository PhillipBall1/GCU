package app;

public class ServerThread extends Thread
{
	public void run() 
	{
		Server server = new Server();
		try
		{
			server.Start(46);
			server.Cleanup();
			
		} 
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
}