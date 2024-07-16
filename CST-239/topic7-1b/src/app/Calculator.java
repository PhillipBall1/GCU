package app;

public class Calculator
{
	public int Add(int a, int b) 
	{
		return a + b;
	}
	public int Subtract(int a, int b) 
	{
		return a - b;
	}
	public int Multiply(int a, int b) 
	{
		return a * b;
	}
	public int Divide(int a, int b) 
	{
		return a / b;
	}
	
	public static void main(String[] args)
	{
		Calculator calculator = new Calculator();
		System.out.println("Adding 1 and 2: " + calculator.Add(1, 2));
	}
}
