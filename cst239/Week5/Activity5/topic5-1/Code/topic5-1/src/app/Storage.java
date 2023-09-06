package app;

public class Storage<T>
{
	private T s = null;
	
	public Storage(T s) 
	{
		this.s = s;
	}
	
	public T GetData() 
	{
		return this.s;
	}
	
	
	public static void main(String[] args)
	{
		Storage<String> storage1 = new Storage<String>("Phillip Ball");
		System.out.println("This is the data " + storage1.GetData());
		
		Storage<Integer> storage2 = new Storage<Integer>(0);
		System.out.println("This is the data " + storage2.GetData());

	}

}
