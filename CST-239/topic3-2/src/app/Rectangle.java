package app;

public class Rectangle extends ShapeBase
{
	/**
	 * Rectangle constructor
	 * @param width Rectangle width
	 * @param height Rectangle height
	 * @param name "Rectangle"
	 */
	public Rectangle(int width, int height, String name) 
	{
		super(width, height, name);
	}
	
	/**
	 * Calculates area by width * height
	 */
	@Override
	public int CalculateArea() 
	{
		return width * height;
	}

}
