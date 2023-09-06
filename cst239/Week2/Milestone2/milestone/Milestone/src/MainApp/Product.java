package MainApp;

public class Product
{
	private String name;
	private String description;
	private float price;
	private int quantity;
	private String type;
	
	/**
	 * Product Constructor
	 * @param name Product Name
	 * @param description Product Description
	 * @param price Product Price
	 * @param quantity Product Quantity
	 */
	public Product(String name, String description, float price, int quantity, String type)
	{
		this.name = name;
		this.description = description;
		this.price = price;
		this.quantity = quantity;
		this.type = type;
	}
	
	/**
	 * Get Name 
	 * @return name
	 */
	public String GetName() {return name;}
	/**
	 * Get Description
	 * @return description
	 */
	public String GetDescription() {return description;}
	/**
	 * Get Price
	 * @return price
	 */
	public float GetPrice() {return price;}
	/**
	 * Get Quantity
	 * @return quantity
	 */
	public int GetQuantity() {return quantity;}
	/**
	 * Get Type
	 * @return type
	 */
	public String GetType() {return type;}
	
	/**
	 * Set Name
	 * @param name
	 */
	public void SetName(String name) { this.name = name;}
	/**
	 * Set Description
	 * @param description
	 */
	public void SetDescription(String description) {this.description = description;}
	/**
	 * Set Price
	 * @param price
	 */
	public void SetPrice(float price) {this.price = price;}
	/**
	 * Set Quantity
	 * @param quantity
	 */
	public void SetQuantity(int quantity) {this.quantity = quantity;}
	/**
	 * Set Type
	 * @param type
	 */
	public void SetQuantity(String type) {this.type = type;}
	
	/**
	 * Increase Quantity
	 * @param amount
	 */
	public void IncreaseQuantity(int amount) { SetQuantity(this.GetQuantity() + amount);}
	/**
	 * Decrease Quantity
	 * @param amount
	 */
	public void DecreaseQuantity(int amount) { SetQuantity(this.GetQuantity() - amount);}

	/**
	 * Converts input Product to a String split by "-"
	 * @param product
	 * @return String 
	 */
	public String ProductToString(Product product) 
	{
		return product.GetName() + "-" + product.GetDescription() + "-" 
			   + product.GetPrice() + "-" + product.GetQuantity() + "-" + product.GetType();
	}
	
}
