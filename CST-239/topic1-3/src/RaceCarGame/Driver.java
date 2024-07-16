package RaceCarGame;

import java.util.Scanner;

public class Driver
{
	
	/*
	 * Some Notes: 
	 * 
	 * This was just suppose to be 1 of 4 activities but I got carried away, so I apologize
	 * if it was annoying to have to grade. I do understand that there is not as much object 
	 * oriented programming going on as well, but I managed to just fit everything into 
	 * while loops just fine, with the only object that was really in the game being the car.
	 * 
	 * Scaling is kind of weird and honestly not as effective as I would want it to be,
	 * I think I would just need to fiddle with it and do Math.Pow() functions to actually
	 * scale the game well. 
	 * 
	 */

	
	//Static scanner used throughout the entire game, used for every player input
	public static Scanner inputScanner = new Scanner(System.in);
	
	//Making sure that the round number is consistent and usable in different functions
	//    for more scalability options
	public static int roundNumber;
	
	//Main function to run the game
	public static void main(String[] args)
	{
		
		//Base amount of upgradePoints given
		int upgradePoints = 6;
		
		//Declaring the round number for scaling games
		roundNumber = 0;
		
		//string used to detect shop inputs, hence statIncreasing
		String statIncreaseString = null;
		
		//Buffer input before the RaceCar game starts 
		System.out.println("Input 1 to start the game!");
		String inputString = inputScanner.next();
		
		//Generate a baseline PlayerCar
		Car playerCar = new Car(50, 4, 1, 36);
		
		//While loop to keep the game running till the player decides to end it
		//     by inputing 2 for the inputString
		while(inputString != "2") 
		{
			//increase round per race
			roundNumber += 1;
			
			//The upgrade point have to be greater than the round number due to 
			//    price scaling, so if the player does not have enough the game
			//    continues
			if(upgradePoints > roundNumber)
			{
				//While the player still has some points, keep looping the shop
				while(upgradePoints != 0) 
				{
					//Scaling upgrade costs between rounds
					int speedCost = 2 + roundNumber - 1;
					int tireCost = 2 + roundNumber - 1;
					int engineCost = 3 + roundNumber - 1;
					int psiCost = 1 + roundNumber - 1;
					
					//Print Upgrade List
					System.out.println("You have " + upgradePoints + " upgrades to make!\n"
							+ "\n 1: Add 10 MPH to current MPH of " + playerCar.GetSpeed() 
							+ "::: Cost " + speedCost + " upgrade point\n"
							+ "\n 2: Add 2 Tires to current Tire count of " + playerCar.GetTires() 
							+ "::: Cost " + tireCost + " upgrade point\n"
							+ "\n 3: Add 1 Engine to current Engine(s) of " + playerCar.GetEngine() 
							+ "::: Cost " + engineCost + " upgrade point\n"
							+ "\n 4: Add 5 PSI to current PSI of " + playerCar.GetPsi() 
							+ "::: Cost " + psiCost + " upgrade point\n"
							+ "\n 5: Get rid of the rest of the point and start game: " + upgradePoints
							);
					
					//Check for player input for the upgrade
					statIncreaseString = inputScanner.next();
					
					//Switch case to check what the input was and apply changes to the players 
					//    car based on the input, then subtract upgrade points based on input
					switch (statIncreaseString)
					{
					case "1": 
						if(upgradePoints >= speedCost) 
						{
							playerCar.SetSpeed(playerCar.GetSpeed() + 10); 
							upgradePoints -= speedCost;
						}
					break;
					case "2": 
						if(upgradePoints >= tireCost) 
						{
							playerCar.SetTires(playerCar.GetTires() + 2); 
							upgradePoints -= tireCost;
						}
					break;
					case "3": 
						if(upgradePoints >= engineCost) 
						{
							playerCar.SetEngine(playerCar.GetEngine() + 1); 
							upgradePoints -= engineCost;
						}
						break;
					case "4": 
						if(upgradePoints >= psiCost)
						{
							playerCar.SetPsi(playerCar.GetPsi() + 5); 
							upgradePoints -= psiCost;
						}
						break;
					case "5": 
						upgradePoints = 0;
						break;
						
					}
				}
			}
			//Create a random race distance that scales with Rounds
			int distanceToRace = GetRandomNumber(100 * roundNumber, 500 * roundNumber);
			Car computerCar = GenerateComputerCar(roundNumber);
			System.out.println("RaceCars are ready! It is Round " + roundNumber + "\n"
					
			//Print Opponents Statistics
			+ "\nOpponents Stats:"
			+ "\n Speed: "+ computerCar.GetSpeed()
			+ "\n Tires: "+ computerCar.GetTires()
			+ "\n Engine(s): "+ computerCar.GetEngine()
			+ "\n PSI: "+ computerCar.GetPsi()
			
			
			//Print Player Statistics
			+"\n\nYour Stats:"
			+ "\n Speed: "+ playerCar.GetSpeed()
			+ "\n Tires: "+ playerCar.GetTires()
			+ "\n Engine(s): "+ playerCar.GetEngine()
			+ "\n PSI: "+ playerCar.GetPsi()
			
			//Print the upcoming distance to race
			+"\n\nDistance to race: " + distanceToRace);
	
			
			//Lap increments
			int lapCount = 0;
			//Used to break while loop when someone has passed the distance
			int gameOver = 1;
			//used to see who is ahead of who by doing playerDistance - opponentDistance
			int comparison = 0;
			//used to get players distance in the race
			int playerDistance = 0;
			//used to get opponents distance in the race
			int opponentDistance = 0;
			//Used to calculate distance left in the race
			int distanceLeft = distanceToRace;
			//Check whether player is ahead of opponent or not
			boolean playerAhead = false;
			//Used to buffer between laps
			String lapConfirm = null;
			
			//While loop to keep laps continuous
			while(gameOver != 0)
			{
				//lap increment
				lapCount++;
				//round buffer
				System.out.println("Type anything to start lap " + lapCount);
				lapConfirm = inputScanner.next();
				
				//deteriorate both players between rounds, not on the very first one though
				//This is mainly achieved by decreasing PSI levels inside of the vehicles
				//   with other car part calculations
				if(lapCount > 1) 
				{
					
					//Takes the Cars current PSI then subtracts the distance / 5 from the Car and then 
					//    lastly adds some PSI back from the Tire count.
					
					//Kind of works like this: currentPSI = 40 | distance = 50 | tiresOwned = 6
					// newPSI = 40 - (50 / 5) + 6
					// newPSI = 36
					
					//I thought that this was a good way to introduce a lower drop especially
					//   with upgrades in mind
					
					playerCar.SetPsi(playerCar.GetPsi() - ((playerDistance / 5) + playerCar.GetTires()));
					computerCar.SetPsi(computerCar.GetPsi() - ((opponentDistance / 5) + computerCar.GetTires()));
					
					
					//In the requirements it is asked that if the tires PSI goes below 32
					//    that the car should stop and restart, so I made this function
					//    that subtracts distance from the players if it goes below
					//    and then goes back up to a base value of 36, which acts as a 
					//    stop function that allows the other player with maybe a 
					//    higher PSI to get ahead
					if(playerCar.GetPsi() < 32)
					{
						playerDistance -= (playerCar.GetPsi()) * roundNumber;
						playerCar.SetPsi(32 + playerCar.GetTires());
					}
					if(computerCar.GetPsi() < 32)
					{
						opponentDistance -= (computerCar.GetPsi()) * roundNumber + 1;
						computerCar.SetPsi(32 + computerCar.GetTires());
					}
				}
				
				//Print the PSI levels 
				System.out.println("\nPlayer Psi is " + playerCar.GetPsi()
				+ "\n Opponent Psi is " + computerCar.GetPsi() + "\n");
				
				//Calculate distances by both players
				playerDistance += playerCar.GetSpeed() * (playerCar.GetEngine()) - (playerCar.GetTires() * 2);
				opponentDistance += computerCar.GetSpeed() * (computerCar.GetEngine()) - (computerCar.GetTires() * 2);
				
				//comparison to see who is ahead
				comparison = playerDistance - opponentDistance;
				
				//Print the distances that both players have achieved so far
				System.out.println("\nPlayer's Distance is currently " + playerDistance + " miles!\n"
						+ "\nOpponent's Distance is currently " + opponentDistance + " miles!\n");
				
				//Make a boolean out of comparison to make some things easier to write out and read
				if(comparison > 0)
				{
					playerAhead = true;
				}
				else 
				{
					playerAhead = false;
				}
				
				//Use the boolean to figure out which person should subtract from the distance left
				distanceLeft = playerAhead? distanceLeft - playerDistance : distanceLeft - opponentDistance;
				
				//Check to see if the game should still continue by making sure there is still 
				//    distance to cover
				if(distanceLeft > 0)
				{
					//Use comparison to check and print who is ahead of the race, plus add
					//    the distance left for the race
					String playerAheadString = playerAhead? 
							"\nPlayer is ahead! With only " + distanceLeft + " miles left!\n"
							: "\nOpponent is ahead! With only " + distanceLeft + " miles left!\n";
					
					System.out.println(playerAheadString);
				}
				else
				{
					//No more distance to cover meaning the while loop should close
					//    and the race should end
					gameOver = 0;
				}
			}
			
			//Figure out the reward of the race, which the reward is upgrade points for the car
			int reward = playerAhead? 
					GetRandomNumber(roundNumber, Math.round(distanceToRace / 50)) : 
						GetRandomNumber(0, Math.round(distanceToRace / 100));
			
			//Create the winner string whether thats the player or opponent 
			String winner = playerAhead? 
					"\nPlayer Won the Race by " + comparison + " miles!!!\nReward for this race is " + reward + " upgrade points!\n\n" 
					:"\nPlayer Lost the Race by " + comparison * -1 + " miles...\nReward for this race is " + reward + " upgrade points...\n\n";
						
			//Apply reward
			upgradePoints += reward;
			
			//print winner
			System.out.println(winner);
			
			//Buffer input so it is not too chaotic
			System.out.println("\nEnter '2' to quit, anything else to keep playing!");
			inputString = inputScanner.next();
		}
	}
	
	
	//Generates a random car for the Player to go against, scales with the rounds that go on
	public static Car GenerateComputerCar(int round)
	{
		int speed = GetRandomNumber(50, 65 + (round * 5));
		int tires = GetRandomNumber(4, 6 + (round * 2));
		int engines = GetRandomNumber(1, 2 + (round * 2));
		int psi = GetRandomNumber(35, 50 + (round * 2));
		Car computerCar = new Car(speed, tires, engines, psi);
		
		return computerCar;
	}
	
	//Java.utils.random.RandomGeneratorandom was not working for me so I just made my own function
	public static int GetRandomNumber(int min, int max) {
	    return (int) ((Math.random() * (max - min)) + min);
	}
}
