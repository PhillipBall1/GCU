package app;

public class Triangle extends ShapeBase
{
	/**
	 * Triangle constructor 
	 * @param width Triangle width
	 * @param height Triangle Height
	 * @param name "Triangle"
	 */
	public Triangle(int width, int height, String name) 
	{
		super(width, height, name);
	}
	
	/**
	 * Calculates area by width * height / 2
	 */
	@Override
	public int CalculateArea()
	{
		return width * height / 2;
	}

}
