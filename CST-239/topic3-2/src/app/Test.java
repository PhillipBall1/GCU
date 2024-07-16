package app;

public class Test
{

	/**
	 * Main function creates shapes and loops the display function
	 * @param args
	 */
	public static void main(String[] args)
	{
		ShapeBase[] shapes = new ShapeBase[4];
		shapes[0] = new Rectangle(10, 200, "Rectangle");
		shapes[1] = new Triangle(10, 50, "Triangle");
		shapes[2] = new Circle(12, "Circle");
		shapes[3] = new Hexagon(34, "Hexagon");
		
		for(int i = 0; i < shapes.length; i++) 
		{
			DisplayArea(shapes[i]);
		}
	}
	/**
	 * Displays given shape's name and area
	 * @param shape Given shape
	 */
	private static void DisplayArea(ShapeBase shape) 
	{
		System.out.println("This is a shape named " 
							+ shape.GetName() 
							+ " with an area of " 
							+ shape.CalculateArea());
	}

}
