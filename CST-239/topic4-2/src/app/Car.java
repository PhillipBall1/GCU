package app;

public class Car
{
	private int year;
	private String make;
	private String model;
	private int odometer;
	private double engineLitters;
	
	public Car() {
		year = 0;
		make = "";
		model = "";
		odometer = 0;
		engineLitters = 0;
	}
	
	public Car(int year, String make, String model, int odometer, double engineLitters)
	{
		super();
		this.year = year;
		this.make = make;
		this.model = model;
		this.odometer = odometer;
		this.engineLitters = engineLitters;
	}
	
	public int GetYear() {return this.year;}	
	public void SetYear(int year) {this.year = year;}
	
	public String GetMake() {return this.make;}	
	public void SetMake(String make) {this.make = make;}
	
	public String GetModel() {return this.model;}
	public void SetModel(String model) {this.model = model;}
	
	public int GetOdometer() {return this.odometer;}
	public void SetOdometer(int odometer) {this.odometer = odometer;}
	
	public Double GetEngineLitters() {return this.engineLitters;}
	public void SetEngineLitters(int engineLitters) {this.engineLitters = engineLitters;}
	
	
	public static void main(String[] args)
	{
		// TODO Auto-generated method stub

	}

}
