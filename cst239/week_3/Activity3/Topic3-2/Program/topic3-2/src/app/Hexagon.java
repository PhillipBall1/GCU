package app;

public class Hexagon extends ShapeBase
{
	/**
	 * Hexagon constructor
	 * @param side Hexagon side
	 * @param name "Hexagon"
	 */
	public Hexagon(int side, String name) 
	{
		super(side, name);
	}
	
	/**
	 * Calculates area by (int)Math.round(((3 * Math.sqrt(3) / 2) * (width * width)))
	 */
	@Override
	public int CalculateArea() 
	{
		return (int)Math.round(((3 * Math.sqrt(3) / 2) * (width * width)));
	}
}
