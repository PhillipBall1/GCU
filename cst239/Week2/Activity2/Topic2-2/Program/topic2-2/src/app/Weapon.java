package app;

public abstract class Weapon
{
	public void FireWeapon(int power)
	{
		System.out.println("In Weapon.FireWeapon() with a power of " + power);
	}
	public abstract void Activate(boolean enable);
}
