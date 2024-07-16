package app;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

import com.fasterxml.jackson.databind.ObjectMapper;

public class DemoJSONFiles
{

	public static void main(String[] args)
	{
		
		Car[] cars = new Car[5];
		cars[0] = new Car(2010, "Toyota", "Prius", 5000, 2d);
		cars[1] = new Car(2020, "Ford", "Explorer", 15000, 1d);
		cars[2] = new Car(2015, "Chevy", "Blazer", 1000, 1.5d);
		cars[3] = new Car(2017, "Toyota", "Avalon", 70000, 2.5d);
		cars[4] = new Car(2019, "Toyota", "Camery", 30000, 1.5d);
		
		for(int i = 0; i < cars.length; i++) 
		{
			SaveToFile("OutMain.json)", cars[i], true);
		}
		
		ArrayList<Car> carsList = ReadFromFile("out.json");
		
		for (Car car : carsList)
		{
			String text = Integer.toString(car.GetYear()) +
					"," + car.GetMake() +
					"," + car.GetModel() +
					"," + Integer.toString(car.GetOdometer()) +
					"," + Double.toString(car.GetEngineLitters());
			System.out.println(text);
		}

	}
	
	private static void SaveToFile(String fileName, Car car, boolean append) 
	{
		PrintWriter pWriter;
		try 
		{
			File file = new File(fileName);
			FileWriter fWriter = new FileWriter(file, append);
			pWriter = new PrintWriter(fWriter);
			
			
			ObjectMapper objectMapper = new ObjectMapper();
			String json = objectMapper.writeValueAsString(car);
			pWriter.println(json);
			
			pWriter.close();
		}
		catch (IOException e) 
		{
			e.printStackTrace();
		}
	}
	
	private static ArrayList<Car> ReadFromFile(String fileName)
	{
		ArrayList<Car> cars = new ArrayList<Car>();
		
		try
		{
			File file = new File(fileName);
			
			Scanner scanner = new Scanner(file);
			
			
			while(scanner.hasNext()) 
			{
				String json = scanner.nextLine();
				ObjectMapper objectMapper = new ObjectMapper();
				Car car = objectMapper.readValue(json, Car.class);
				cars.add(car);
			}
			scanner.close();
		} 
		catch (Exception e)
		{
			e.printStackTrace();
		}
		
		return cars;
	}

}
