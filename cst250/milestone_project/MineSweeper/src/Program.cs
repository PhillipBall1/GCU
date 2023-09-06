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
		PrintBoard(board);
	}
	
	static void PrintBoardForLiveGame(Board board)
	{
		
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

			//If square is a bomb display it as [X]
			//else display its live neighbors value
			if (board.GetCells()[i].GetLive())
			{
				Console.Write("[ " + "X" + " ]");
			}
			else
			{
				if(board.GetCells()[i].GetLiveNeighbors() == 0)
				{
					Console.Write("[ " + " " + " ]");
				}else
				{
					Console.Write("[ " + board.GetCells()[i].GetLiveNeighbors().ToString() + " ]");
				}
				
			}
		}
	}
}