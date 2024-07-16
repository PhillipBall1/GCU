package app;
/**
 * Gun class, implemented from WeaponInterface
 * @author Phillip
 *
 */
public class Gun implements WeaponInterface
{
	@Override
	public void FireWeapon(int power) 
	{
		System.out.println("In Gun.FireWeapon() with a power of " + power);
	}
	@Override
	public void FireWeapon() 
	{
		System.out.println("In overloaded Gun.FireWeapon()");
	}
	@Override
	public void Activate(boolean enable) 
	{
		System.out.println("In the Gun.Activate() with an enable of " + enable);
	}
}
