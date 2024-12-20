package MainApp;

public class Cart
{
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
}
