import java.util.Random;

public class Superman extends SuperHero
{
	/**
	 * Generate Superman
	 * @param health Set Superman's health
	 */
	public Superman(int health) 
	{
		super("Superman", health);
	}
	
	/**
	 * Superman's normal attack
	 * @param opponent opponent to attack
	 */
	public void NormalAttack(SuperHero opponent) 
	{
		Random rand = new Random();
		int damage = rand.ints(1, 10).findFirst().getAsInt();
		Attack(opponent, damage);
	}
	/**
	 * Superman's special attack
	 * @param opponent opponent to attack
	 */
	public void Special(SuperHero opponent) 
	{
		System.out.println("Superman uses eye lasers!");
		Random rand = new Random();
		int damage = rand.ints(5, 60).findFirst().getAsInt();
		Attack(opponent, damage);
	}
	/**
	 * Allows Superman to regenerate health
	 */
	public void Regeneration() 
	{
		Random rand = new Random();
		int health = rand.ints(10, 40).findFirst().getAsInt();
		IncreaseHealth(health);
		System.out.println("Superman uses regeneration and gains " + health +  " health");
	}
}
