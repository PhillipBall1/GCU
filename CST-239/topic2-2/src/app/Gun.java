package app;

public class Gun extends Weapon
{
	public void FireWeapon(int power) 
	{
		System.out.println("In Gun.FireWeapon() with a power of " + power);
	}
	public void FireWeapon() 
	{
		System.out.println("In overloaded Gun.FireWeapon()");
		super.FireWeapon(10);
	}
	public void Activate(boolean enable) 
	{
		System.out.println("In the Gun.Activate() with an enable of " + enable);
	}
}
