import java.util.Random;

public class Batman extends SuperHero
{
	/**
	 * Generate Batman
	 * @param health Set Superman's health
	 */
	public Batman(int health)
	{
		super("Batman", health);
	}
	/**
	 * Batman's normal attack
	 * @param opponent opponent to attack
	 */
	public void NormalAttack(SuperHero opponent) 
	{
		Random rand = new Random();
		int damage = rand.ints(1, 10).findFirst().getAsInt();
		Attack(opponent, damage);
	}
	/**
	 * Batman's special attack
	 * @param opponent opponent to attack
	 */
	public void Special(SuperHero opponent) 
	{
		System.out.println("Batman uses the Bat Mobile!");
		Random rand = new Random();
		int damage = rand.ints(10, 50).findFirst().getAsInt();
		Attack(opponent, damage);
	}
	/**
	 * Allows Batman to regenerate health
	 */
	public void Regeneration() 
	{
		Random rand = new Random();
		int health = rand.ints(1, 50).findFirst().getAsInt();
		System.out.println("Batman uses regeneration and gains " + health +  " health");
	}
}
