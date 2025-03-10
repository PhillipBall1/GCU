package app;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

public class Server
{
	private ServerSocket serverSocket;
	private Socket clientSocket;
	private PrintWriter outPrintWriter;
	private BufferedReader inBufferedReader;
	
	public void Start(int port) throws IOException
	{
		System.out.println("Waiting for client connection...... ");
		serverSocket= new ServerSocket(port);
		clientSocket = serverSocket.accept();
		
		System.out.println("Recieved a Client connection on port " + clientSocket.getLocalPort());
		outPrintWriter = new PrintWriter(clientSocket.getOutputStream(), true);
		inBufferedReader = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
		String inputLine;
		
		while ((inputLine = inBufferedReader.readLine()) != null)
		{
			if(".".equals(inputLine)) 
			{
				System.out.println("Got a message to shut the server down");
				outPrintWriter.println("QUIT");
				break;
			}
			else
			{
				System.out.println("Got a message of: " + inputLine);
				outPrintWriter.println("OK");
			}
			
		}
		
		System.out.println("Server is shut down");
	}
	
	
	public void Cleanup()throws IOException
	{
		inBufferedReader.close();
		outPrintWriter.close();
		clientSocket.close();
		serverSocket.close();
	}
	
	public static void main(String[] args) throws IOException
	{
		Server server = new Server();
		server.Start(46);
		server.Cleanup();
	}
}
