package app;

public class Game
{

	public static void main(String[] args)
	{
		Bomb weapon1 = new Bomb();
		Gun weapon2 = new Gun();
		weapon1.Activate(true);
		weapon2.Activate(true);
		weapon1.FireWeapon(10);
		weapon2.FireWeapon(5);
		weapon1.FireWeapon();
		weapon2.FireWeapon();
	}

}
