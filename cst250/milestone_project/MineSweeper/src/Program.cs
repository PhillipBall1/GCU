using System;
class Program
{
	public static void Main(string[] args)
	{
		//create board
		int[] size = new int[] { 10, 10 };
		Board board = new Board(size, 90);

		//setup cells in board
		board.SetupLiveNeighbors();

		//display board
		PrintBoardForLiveGame(board);
		
		Console.WriteLine("BEFORE VISIT");
		
		board.RevealCells(board.GetCells()[5]);
		
		PrintBoardForLiveGame(board);
		
		Console.WriteLine("AFTER VISIT");
		
		PrintBoard(board);
	}
	
	static void PrintBoardForLiveGame(Board board)
	{
		for(int i = 0; i < board.GetSize()[0]; i++)
		{
			if(i == 0) Console.Write("     ");
			Console.Write("--{0}--", i);
		}
		int l = 0;
		for(int i = 0; i < board.GetCells().Length; i++)
		{
			//Display the board as an actual square
			if(i % board.GetSize()[0] == 0)
			{
				Console.WriteLine("");
				Console.Write("--{0}--", l);
				l++;
			}

			if(board.GetCells()[i].GetVisited())
			{
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
			else
			{
				Console.Write("[ " + "?" + " ]");
			}
			
			
		}
	}
	
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
			//Display the board as an actual square
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