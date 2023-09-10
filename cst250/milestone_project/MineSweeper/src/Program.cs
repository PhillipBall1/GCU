using System;
class Program
{
	static Board board;
	
	public static void Main(string[] args)
	{
		int size = 5;
		board = SetupNewBoard(size, 90);

		int game = 0;
		
		while (game == 0)
		{
			PrintBoardForLiveGame(board);
			
			//mark bombs
			Console.WriteLine("");
			Console.WriteLine("Do you want to mark a bomb? \n1: Yes \n2: No\nYou can " + 
			"un-mark a cell by choosing the same cell twice");
			if(int.Parse(Console.ReadLine()) == 1)
			{
				board.MarkTile(GetRowInput(), GetColumnInput());
				
				//continue just incase user wants to mark multiple bombs
				continue;
			}

			//Get the correct tile to reveal
			int getCorrectTile = GetRowInput() + GetColumnInput();
			
			//reveal that tile with recursion to reveal every valid pos
			int reveal = board.RevealCells(board.GetCells()[getCorrectTile]);
			
			//Game lost
			if(reveal == -1)
			{
				Console.WriteLine("You hit a bomb :(");
				Console.WriteLine("REVEALED BOARD");
				PrintBoard(board);
				Console.WriteLine("");
				Console.WriteLine("Play Again? \n1: Yes \n2: No");
				if(int.Parse(Console.ReadLine()) != 1)
				{
					game = -1;
				}
				else
				{
					board = SetupNewBoard(size, 90);
				}
			}
			
			//Game won
			if(reveal == 1)
			{
				Console.WriteLine("You beat the game!");
				Console.WriteLine("REVEALED BOARD");
				PrintBoard(board);
				Console.WriteLine("");
				Console.WriteLine("Play Again? \n1: Yes \n2: No");
				if(int.Parse(Console.ReadLine()) != 1)
				{
					game = -1;
				}
				else
				{
					board = SetupNewBoard(size, 90);
				}
			}
		}
	}
	
	
	//simplifies the row input into method for reusability
	static int GetRowInput()
	{
		Console.WriteLine("");
		Console.WriteLine("Enter Row: ");
		int inputRow = int.Parse(Console.ReadLine());
		while(inputRow > board.GetSize()[0])
		{
			Console.WriteLine("Please enter a valid row");
			inputRow = int.Parse(Console.ReadLine());
		}
		return inputRow * board.GetSize()[0];
	}
	
	//simplifies the column input into method for reusability
	static int GetColumnInput()
	{
		Console.WriteLine("");
		Console.WriteLine("Enter Column: ");
		int inputColumn = int.Parse(Console.ReadLine());
		while(inputColumn > board.GetSize()[1])
		{
			Console.WriteLine("Please enter a valid column");
			inputColumn = int.Parse(Console.ReadLine());
		}
		return inputColumn;
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
			Console.Write("--{0}--", i);
		}
		
		//used to hold the numbers for the rows
		int l = 0;
		
		for(int i = 0; i < board.GetCells().Length; i++)
		{
			// displays the boards row numbers
			if(i % board.GetSize()[0] == 0)
			{
				Console.WriteLine("");
				if(l > 9)Console.Write("--{0}--", l);
				else Console.Write("--{0} --", l);
				l++;
			}

			// if the cell is not visited or marked place '?'
			if(!board.GetCells()[i].GetVisited() && !board.GetCells()[i].GetMarked())
			{
				Console.Write("[ " + "?" + " ]");
				
				//continues so nothing gets overwritten in the later statements (saves another nested if)
				continue;
			}

			//used for switch statement so I don't have to nest a bunch of if loops to display text
			int num = -1;
			
			//used to make the switch statement look cleaner
			string y = board.GetCells()[i].GetLiveNeighbors().ToString();
			
			//if cells live place X, else if cell is not numbered place nothing, else cell is numbered
			// place the number
			if (board.GetCells()[i].GetLive() || board.GetCells()[i].GetMarked()) num = 0;
			else if (board.GetCells()[i].GetLiveNeighbors() == 0) num = 1;
			else num = 2;
			
			switch(num)
			{
				case 0: Console.Write("[ " + "X" + " ]"); break;
				case 1: Console.Write("[ " + " " + " ]"); break;
				case 2: Console.Write("[ " +  y  + " ]"); break;
			}
			
			
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

			int num = -1;
			
			string y = board.GetCells()[i].GetLiveNeighbors().ToString();
			
			if (board.GetCells()[i].GetLive()) num = 0;
			else if (board.GetCells()[i].GetLiveNeighbors() == 0) num = 1;
			else num = 2;
			
			switch(num)
			{
				case 0: Console.Write("[ " + "X" + " ]"); break;
				case 1: Console.Write("[ " + " " + " ]"); break;
				case 2: Console.Write("[ " +  y  + " ]"); break;
			}
		}
	}
}
