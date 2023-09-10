using System;
class Program
{
	static Board board;
	static int size = 5;
	static int difficulty = 90;
	
	public static void Main(string[] args)
	{
		
		board = SetupNewBoard(size, 90);

		int game = 0;
		
		while (game == 0)
		{
			PrintBoardForLiveGame(board);
			
			//mark bombs
			int mark = GetUserInput("\nDo you want to mark a bomb?\nYou can " + 
			"un-mark a cell by choosing the same cell twice! \n1: Yes \n2: No");
			
			if(mark == 1)
			{
				board.MarkTile((GetUserInput("\nEnter Row: ", size) * size), GetUserInput("\nEnter Column: ", size));
				
				//continue just incase user wants to mark multiple bombs
				continue;
			}

			//Get the correct tile to reveal
			int getCorrectTile = (GetUserInput("\nEnter Row: ", size) * size) + GetUserInput("\nEnter Column: ", size);
			
			//reveal that tile with recursion to reveal every valid pos
			int reveal = board.RevealCells(board.GetCells()[getCorrectTile]);
			
			//goes into the game over user input section
			game = RevealInputs(reveal);
		}
	}
	
	
	//simplifies the 2 reveal outputs after the game is over
	static int RevealInputs(int wl)
	{
		//no win or loss
		if(wl == 0) return 0;
		
		//there was a win or loss, write appropriate line
		if(wl == 1) Console.WriteLine("\nYou beat the game!");
		else
		{
			Console.WriteLine("\nYou hit a mine :(");
			//reveal board
			Console.WriteLine("\nREVEALED BOARD");
			PrintBoard(board);
		} 
		
		
		
		//asks user to play again, no then quit
		if(GetUserInput("\n\nPlay Again? \n1: Yes \n2: No") == 2) return -1;
		
		//asks user to change size or difficulty, no then new board
		if(GetUserInput("\nChange Board Size/Difficulty? \n1: Yes \n2: No") == 2)
		{
			board = SetupNewBoard(size, difficulty);
			return 0;
		}
		
		//sets new size from user input
		size = GetUserInput("\nChange Size:");
		
		//sets new difficulty from user input
		difficulty = GetUserInput("\nChange Difficulty (1-99, Higher = Easier):");

		//creates board from new size and difficulty
		board = SetupNewBoard(size, difficulty);
		
		return 0;
	}
	
	//gets the users answer using while loops and try parse to make sure its correct
	//using this to make it reusable and cleaner
	static int GetUserInput(string statement)
	{
		int value = 0;
		
		//while loop to allow the user to make the right input
		while (value == 0)
		{
			//write statement
			Console.WriteLine(statement);
			
			//get answer
			string answer = Console.ReadLine();
			
			//try parse the answer to set an actual value, if it works, return that value
			//	if not, write invalid input
			if(int.TryParse(answer, out value))return value; 
			else Console.WriteLine("Invalid input");
		}
		return 0;
	}
	
	//gets the users answer using while loops and try parse to make sure its correct
	//using this version for row and column inputs 
	static int GetUserInput(string statement, int rcSize)
	{
		int value = rcSize + 2;

		//while loop to allow the user to make the right input
		while (value + 1 > rcSize)
		{
			//write statement
			Console.WriteLine(statement);
			
			//get answer
			string answer = Console.ReadLine();
			
			//try parse the answer to set an actual value, if it works, return that value
			//	if not, write invalid input
			if(!int.TryParse(answer, out value)) Console.WriteLine("Invalid input");
			if(value + 1 > rcSize) Console.WriteLine("Input too large");
		}
		return value;
	}
	
	//allows for the ability to replay without having to spam all of this code in main
	static Board SetupNewBoard(int sizeXY, int difficulty)
	{
		//create board
		int[] size = new int[] { sizeXY, sizeXY };
		board = new Board(size, difficulty);

		//setup cells in board
		board.SetupLiveNeighbors();
		
		return board;
	}
	
	
	//prints board for live game
	static void PrintBoardForLiveGame(Board board)
	{
		//displays the boards column numbers
		for(int i = 0; i < board.GetSize()[0]; i++)
		{
			if(i == 0) Console.Write("     ");
			Console.Write(" -{0}- ", i);
		}
		
		//used to hold the numbers for the rows
		int l = 0;
		
		for(int i = 0; i < board.GetCells().Length; i++)
		{
			// displays the boards row numbers
			if(i % board.GetSize()[0] == 0)
			{
				Console.WriteLine("");
				if(l > 9)Console.Write("- {0}  -", l);
				else Console.Write("- {0} -", l);
				l++;
			}

			// if the cell is not visited or marked place '?'
			if(!board.GetCells()[i].GetVisited() && !board.GetCells()[i].GetMarked())
			{
				Console.Write("[ " + "?" + " ]");
				
				//continues so nothing gets overwritten in the later statements (saves another nested if)
				continue;
			}

			//if cells live place X, else if cell is not numbered place nothing, else cell is numbered
			// place the number
			if (board.GetCells()[i].GetLive() || board.GetCells()[i].GetMarked()) Console.Write("[ " + "X" + " ]");
			else if (board.GetCells()[i].GetLiveNeighbors() == 0) Console.Write("[ " + " " + " ]");
			else Console.Write("[ " +  board.GetCells()[i].GetLiveNeighbors().ToString()  + " ]");
		}
	}
	
	
	//Same as other print just without the question marks, nice for revealing bombs to the player 
	// after losing or winning
	static void PrintBoard(Board board)
	{
		for(int i = 0; i < board.GetSize()[0]; i++)
		{
			if(i == 0) Console.Write("     ");
			Console.Write("--{0}--", i);
		}
		
		int l = 0;
		
		for(int i = 0; i < board.GetCells().Length; i++)
		{
			if(i % board.GetSize()[0] == 0)
			{
				Console.WriteLine("");
				Console.Write("--{0}--", l);
				l++;
			}

			if (board.GetCells()[i].GetLive() || board.GetCells()[i].GetMarked()) Console.Write("[ " + "X" + " ]");
			else if (board.GetCells()[i].GetLiveNeighbors() == 0) Console.Write("[ " + " " + " ]");
			else Console.Write("[ " +  board.GetCells()[i].GetLiveNeighbors().ToString()  + " ]");
		}
	}
}
