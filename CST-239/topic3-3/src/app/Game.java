package app;

public class Game
{
	/**
	 * Main function that creates an array of weapons and displays it in console
	 * @param args
	 */
	public static void main(String[] args)
	{
		WeaponInterface[] weapons = new WeaponInterface[2];
		weapons[0] = new Bomb();
		weapons[1] = new Gun();
		
		for (int i = 0; i < weapons.length; i++)
		{
			FireWeapon(weapons[i]);
		}
	}

	/**
	 * Fires a weapon, intakes a weapon generated from the classes that implement the WeaponInterface
	 * @param weapon Weapon from WeaponInterface
	 */
	private static void FireWeapon(WeaponInterface weapon)
	{
		if(weapon instanceof Bomb) 
		{
			System.out.println("----------> I am a Bomb");
		}
		weapon.Activate(true);
		weapon.FireWeapon(5);
	}
}

