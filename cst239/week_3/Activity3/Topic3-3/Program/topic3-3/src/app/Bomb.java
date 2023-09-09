package app;

/**
 * Bomb class, implemented from WeaponInterface
 * @author Phillip
 *
 */
public class Bomb implements WeaponInterface
{
	@Override
	public void FireWeapon(int power) 
	{
		System.out.println("In Bomb.FireWeapon() with a power of " + power);
	}
	@Override
	public void FireWeapon() 
	{
		System.out.println("In overloaded Bomb.FireWeapon()");
	}
	@Override
	public void Activate(boolean enable) 
	{
		System.out.println("In the Bomb.Activate() with an enable of " + enable);
	}
}
