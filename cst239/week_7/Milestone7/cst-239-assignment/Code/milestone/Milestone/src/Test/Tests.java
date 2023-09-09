package Test;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import MainApp.*;

public class Tests
{
	@Test
	public void TestProduct() 
	{
		Product product = new Product("Candy", "Sweet", 1.23f, 1, "Snack");
		assertEquals("Candy-Sweet-1.23-1-Snack", product.ProductToString(product));
	}

	@Test
	public void TestStoreFront() 
	{
		assertEquals(100, StoreFront.balance);
	}
	
	@Test
	public void TestInventoryManager() 
	{
		ProductListManager listManager = new ProductListManager();
		List<String> list = new ArrayList<String>();
		list.add("Test");
		listManager.SetList(list);
		assertEquals(list, listManager.GetList());
	}
	
	@Test
	public void TestCart() 
	{
		Cart cart = new Cart();
		List<String> list = new ArrayList<String>();
		list.add("Test");
		cart.SetCartList(list);
		assertEquals(list, cart.GetCartList());
	}	
}
