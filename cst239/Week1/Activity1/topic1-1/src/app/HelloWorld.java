package app;

public class HelloWorld {

	private void SayHello(String name) 
	{
		System.out.println("Hello, my name is " + name);
	}
	public static void main(String args[]) 
	{
		HelloWorld helloWorld = new HelloWorld();
		helloWorld.SayHello("Phillip");
	}
}
