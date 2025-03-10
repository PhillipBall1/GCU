package MainApp;

import java.util.List;
import java.util.Scanner;

public class Cart
{
	private List<String> cartList;
	private List<Product> cartProducts;
	
	private float paymentNeeded = 0;
	private int itemsInCart = 0;
	/**
	 * Get Items In Cart
	 * @return amount of items in User cart
	 */
	public int GetItemsInCart() { return itemsInCart; }
	/**
	 * Get Payment Needed
	 * @return overall payment needed for all cart items
	 */
	public float GetPaymentNeeded() { return paymentNeeded; }
	/**
	 * Set Items in Cart
	 * @param amount
	 */
	public void SetItemsInCart(int amount) { itemsInCart = amount; }
	/**
	 * Set Payment Needed
	 * @param amount
	 */
	public void SetPaymentNeeded(float amount) { paymentNeeded = amount; }
	/**
	 * Increase Payment Needed
	 * @param amount
	 */
	public void IncreasePaymentNeeded(float amount) {paymentNeeded = GetPaymentNeeded() + amount; }
	/**
	 * Increase Items in Cart
	 * @param amount
	 */
	public void IncreaseItemsInCart(int amount) {itemsInCart = GetItemsInCart() + amount; }
	/**
	 * Decrease Payment Needed
	 * @param amount
	 */
	public void DecreasePaymentNeeded(float amount) {paymentNeeded = GetPaymentNeeded() - amount; }
	/**
	 * Decrease Items in Cart
	 * @param amount
	 */
	public void DecreaseItemsInCart(int amount) {itemsInCart = GetItemsInCart() - amount; }
    
	
	
	
	/**
	 * Adds a string of a Product to the List<String> cartList
	 * @param item String input to add to the list
	 */
	public void AddItemToCart(String item) {cartList.add(item);}
	
	/**
	 * Loops through the cartList and finds where the input is to remove it
	 * @param input String input to remove from the list
	 */
	public void RemoveItemFromCart(String input, List<String> productList)
	{
		for(int i = 0; i < cartList.size(); i++)
		{
			String nameString = cartList.get(i).split("-")[0];
			if(nameString.equals(input.split("-")[0])) 
			{
				productList.add(cartList.get(i));
				cartList.remove(i);
				break;
			}
		}
	}
	
	/**
	 * @return Returns the cartList
	 */
	public List<String> GetCartList() {return cartList;}
	
	/**
	 * @param newCartList Sets the cartList
	 */
	public void SetCartList(List<String> newCartList) {cartList = newCartList;}
	
	
	/**
	 * Adds Product to the List<Product> cartProducts
	 * @param item Product input to add to the list
	 */
	public void AddItemToProducts(Product item) {cartProducts.add(item);}
	
	/**
	 * Loops through the cartProducts list and finds where the input is to remove it
	 * @param input Product input to remove from the list
	 */
	public void RemoveItemFromProducts(Product item)
	{
		for(int i = 0; i < cartProducts.size(); i++)
		{
			if(item.equals(cartProducts.get(i))) 
			{
				cartProducts.remove(i);
			}
		}
	}
	
	/**
	 * @return List<Product> cartProducts
	 */
	public List<Product> GetCartProducts() {return cartProducts;}
	
	/**
	 * @param newCartProducts Sets the cartProducts list
	 */
	public void SetCartProducts(List<Product> newCartProducts) {cartProducts = newCartProducts;}

}
