package app;

public class MyArray
{
	public <E> void PrintArray(E[] inputArray) 
	{
		for(E element : inputArray) 
		{
			System.out.printf("%s ", element);
		}
	}
	
	public static void main(String[] args)
	{
		Integer[] intArray = { 1 ,2 ,3 ,4 ,5 };
		Double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
		Character[] charArray = { 'H', 'E', 'L', 'L', 'O' };
		
		MyArray myArray = new MyArray();
		System.out.println("Array intArray contains:");
		myArray.PrintArray(intArray);
		System.out.println("\nArray doubleArray contains:");
		myArray.PrintArray(doubleArray);
		System.out.println("\nArray charArray contains:");
		myArray.PrintArray(charArray);
		
	}
}
