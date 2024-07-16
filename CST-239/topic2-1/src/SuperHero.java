import java.security.PublicKey;
import java.util.Random;

public class SuperHero
{
	private String name;
	private int health;
	private boolean isDead;
	
	/**
	 * Superhero constructor
	 * @param name name of superhero
	 * @param health health of superhero
	 */
	public SuperHero(String name, int health) 
	{
		this.name = name;
		this.health = health;
	}
	/**
	 * Takes in an int of damage and applies that to the opponent superhero
	 * @param opponent Superhero opponent
	 * @param damage Damage to apply to opponent superhero
	 */
	public void Attack(SuperHero opponent, int damage) 
	{
		opponent.DetermineHealth(damage);
		System.out.println(String.format("%s takes damage of %d and current health is now %d"
				, opponent.name, damage, opponent.health));
	}
	/**
	 * gets the isDead boolean
	 * @return isDead
	 */
	public boolean IsDead()
	{
		return isDead;
	}
	/**
	 * Check to see if superhero has died
	 * @param damage apply this damage to subtract from superhero health, if < 0 ; then superhero is dead
	 */
	private void DetermineHealth(int damage)
	{
		if(this.health - damage <= 0) 
		{
			this.health = 0;
			this.isDead = true;
		}
		else
		{
			this.health = this.health - damage;
		}
	}
	/**
	 * Increases the superhero's health
	 * @param amount Increases by this amount
	 */
	public void IncreaseHealth(int amount) 
	{
		this.health = this.health + amount;
	}
	
}
