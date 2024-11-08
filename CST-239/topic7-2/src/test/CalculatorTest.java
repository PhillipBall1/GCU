package test;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import app.Calculator;

public class CalculatorTest
{
	@Test
	public void TestAdd() 
	{
		Calculator calculator = new Calculator();
		assertEquals(3, calculator.Add(2, 1));
		assertEquals(7, calculator.Add(5, 2));
	}
	@Test
	public void TestSubtract() 
	{
		Calculator calculator = new Calculator();
		assertEquals(1, calculator.Subtract(2, 1));
		assertEquals(3, calculator.Subtract(5, 2));
	}
	@Test
	public void TestMultiply() 
	{
		Calculator calculator = new Calculator();
		assertEquals(2, calculator.Multiply(2, 1));
		assertEquals(10, calculator.Multiply(5, 2));
	}
	@Test
	public void TestDivide() 
	{
		Calculator calculator = new Calculator();
		assertEquals(2, calculator.Divide(2, 1));
		assertEquals(2, calculator.Divide(5, 2));
	}
}
