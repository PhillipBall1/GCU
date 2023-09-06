import java.util.Random;

public class Main
{
	/**
	 * Main function runs the game
	 * @param args
	 */
	public static void main(String[] args)
	{
		Random random = new Random();
		int health1 = random.ints(1, 1000 + 1).findFirst().getAsInt();
		int health2 = random.ints(1, 1000 + 1).findFirst().getAsInt();
		
		System.out.println("Creating the Super Heroes.......");
		Superman superman = new Superman(health1);
		Batman batman = new Batman(health2);
		System.out.println("Super Heroes creates");
		
		System.out.println("Running the game.......");
		
		while(!superman.IsDead() && !batman.IsDead()) 
		{
			int rand1 = random.ints(1, 100 + 1).findFirst().getAsInt();
			int rand2 = random.ints(1, 100 + 1).findFirst().getAsInt();
			
			//Superman attacks
			if(InbetweenTwoNumbers(1, 60, rand1)) 
			{
				superman.NormalAttack(batman);
			}
			if(InbetweenTwoNumbers(61, 80, rand1)) 
			{
				superman.Special(batman);
			}
			if(InbetweenTwoNumbers(81, 100, rand1)) 
			{
				superman.Regeneration();
			}
			
			//Batman attacks
			if(InbetweenTwoNumbers(1, 60, rand2)) 
			{
				batman.NormalAttack(superman);
			}
			if(InbetweenTwoNumbers(61, 80, rand2)) 
			{
				batman.Special(superman);
			}
			if(InbetweenTwoNumbers(81, 100, rand2)) 
			{
				batman.Regeneration();
			}
			
			
			if(superman.IsDead()) 
			{
				System.out.println("Batman defeated Superman");
			}
			if(batman.IsDead()) 
			{
				System.out.println("Superman defeated Batman");
			}
		}
	}

	/**
	 * Checks if a random number is in between to set numbers
	 * @param first first number
	 * @param second second number
	 * @param random number to see if it is in between the other two
	 * @return True or false based on if the number is in between or not
	 */
	private static boolean InbetweenTwoNumbers(int first, int second, int random) 
	{
		if(random >= first && random <= second) 
		{
			return true;
		}
		return false;
	}
}
