using System;
class Program
{
	public static void Main(string[] args)
	{
		//create board
		int[] size = new int[] { 20, 20 };
		Board board = new Board(size, 99);

		//setup board
		board.SetupLiveNeighbors();

		//display board
		PrintBoard(board);
	}
	
	static void PrintBoard(Board board)
	{
		for(int i = 0; i < board.GetCells().Length; i++)
		{
			//Display the board as an actual square
			if(i % board.GetSize()[0] == 0)
			{
				Console.WriteLine("");
            }

			//If square is a bomb display it as [X]
			//else display its live neighbors value
			if (board.GetCells()[i].GetLive())
			{
                Console.Write("[" + "X" + "]");
            }
            else
			{
                Console.Write("[" + board.GetCells()[i].GetLiveNeighbors().ToString() + "]");
			}
        }
	}
}