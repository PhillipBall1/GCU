package RaceCarGame;

public class Car
{
	//Car variables
	private int speed;
	private int tires;
	private int engine;
	private int psi;

	//Car Constructor
	public Car(int speed, int tires, int engine, int psi)
	{
		this.speed = speed;
		this.tires = tires;
		this.engine = engine;
		this.psi = psi;
	}
	
	
	//Public Getters for the Car
	public int GetSpeed()
	{
		return speed;
	}
	public int GetTires()
	{
		return tires;
	}
	public int GetEngine()
	{
		return engine;
	}
	public int GetPsi()
	{
		return psi;
	}
	
	//Public Single Setters for the Car, allowing for more customization to a single car
	public void SetSpeed(int speed)
	{
		this.speed = speed;
	}
	public void SetTires(int tires)
	{
		this.tires = tires;
	}
	public void SetEngine(int engines)
	{
		this.engine = engines;
	}
	public void SetPsi(int psi)
	{
		this.psi = psi;
	}
}
