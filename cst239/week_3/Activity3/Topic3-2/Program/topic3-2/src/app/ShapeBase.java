package app;

public class ShapeBase implements ShapeInterface
{
	protected int width;
	protected int height;
	protected String name;
	
	/**
	 * Constructor for shapes with a width and height
	 * @param width Width of shape
	 * @param height Height of shape
	 * @param name Name of shape
	 */
	public ShapeBase(int width, int height, String name)
	{
		this.width = width;
		this.height = height;
		this.name = name;
	}
	/**
	 * Constructor for shapes that just need a width
	 * @param width Width of shape
	 * @param name Name of shape
	 */
	public ShapeBase(int width, String name)
	{
		this.width = width;
		this.name = name;
	}
	/**
	 * Get name of shape
	 * @return name
	 */
	public String GetName() 
	{
		return this.name;
	}
	
	@Override
	public int CalculateArea()
	{
		return -1;
	}
}
