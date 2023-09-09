package app;

public class Circle extends ShapeBase
{
	/**
	 * Circle constructor
	 * @param radius Circle radius
	 * @param name "Circle"
	 */
	public Circle(int radius, String name) 
	{
		super(radius, name);
	}
	
	/**
	 * Calculates area by (int) Math.round((width * width) * Math.PI)
	 */
	@Override
	public int CalculateArea() 
	{
		return (int) Math.round((width * width) * Math.PI);
	}
}
