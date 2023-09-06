package app;

public class Bomb extends Weapon
{
	public void FireWeapon(int power) 
	{
		System.out.println("In Bomb.FireWeapon() with a power of " + power);
	}
	public void FireWeapon() 
	{
		System.out.println("In overloaded Bomb.FireWeapon()");
		super.FireWeapon(5);
	}
	public void Activate(boolean enable) 
	{
		System.out.println("In the Bomb.Activate() with an enable of " + enable);
	}
}
