using System;
using System.Collections.Generic;

public class Board
{
	int[] size;
	float difficulty;
	
	Cell[] cells;

	int start = 0;
	
	public Board(int[] size, int difficulty)
	{
		this.size = size;
		this.difficulty = difficulty;
	}

	public Cell[] GetCells() { return cells; }

	public int[] GetSize() { return size; }


	public void SetupLiveNeighbors()
	{

		int cellCount = size[0] * size[1];
		//set the cell array equal to the width * height of the board
		cells = new Cell[cellCount];

		//x for loop
		for(int i = 0; i < size[0]; i++)
		{
			//y for loop
			for(int j = 0; j < size[1]; j++)
			{
				//random for whether the cell is a bomb or not
				Random random = new Random();
				int r = random.Next(0, 101);
				bool chance = r > difficulty;

				//create a cell on specified pos with the chance of live
				CreateCell(i, j, chance);
			}
		}
		//calculates the amount of live neighbors
		CalculateLiveNeighbors();
	}

	private void CreateCell(int k, int j, bool chance)
	{
		cells[start] = new Cell(k, j, chance);
		start++;
	}

	//start for loop for each square to be tested
	private void CalculateLiveNeighbors()
	{
		for(int i = 0; i < cells.Length; i++)
		{
			CheckSquares(cells[i]);
		}
	}

	//checks the possibility from each square surrounding the initial square
	private void CheckSquares(Cell cell)
	{
		int liveCount = 0;

		//each possible pos for row -1
		liveCount += FindLiveCells(cell, -1, -1);
		liveCount += FindLiveCells(cell, -1, 0);
		liveCount += FindLiveCells(cell, -1, 1);

		//each possible pos for row 0
		liveCount += FindLiveCells(cell, 0, -1);
		liveCount += FindLiveCells(cell, 0, 1);

		//each possible pos for row 1
		liveCount += FindLiveCells(cell, 1, -1);
		liveCount += FindLiveCells(cell, 1, 0);
		liveCount += FindLiveCells(cell, 1, 1);

		//check the starting cell
		if(cell.GetLive()) liveCount += 1;

		//set the live neighbors on the cell (min: 0, max: 9)
		cell.SetLiveNeighbors(liveCount);
	}

	//finds the cell in the designated pos returns int if it is live
	private int FindLiveCells(Cell startCell, int posX, int posY)
	{
		for (int i = 0; i < cells.Length; i++)
		{

			if(cells[i].GetColumn() == startCell.GetColumn() - posY && cells[i].GetRow() == startCell.GetRow() - posX)
			{
				// found a cell in set pos and check live
				if (cells[i].GetLive())
				{
					return 1;
				}
			}
		}
		//did not find a cell in set pos
		return 0;
	}
	
	
	public int RevealCells(Cell startCell)
	{
		if(startCell.GetLive()) return -1;
		
		
		if(!startCell.GetVisited() && startCell.GetLiveNeighbors() == 0)
		{
			startCell.SetVisited(true);
			RevealCells(FindCellInPos(startCell, -1, -1));
			RevealCells(FindCellInPos(startCell, -1,  0));
			RevealCells(FindCellInPos(startCell, -1,  1));
			
			RevealCells(FindCellInPos(startCell,  1, -1));
			RevealCells(FindCellInPos(startCell,  1,  0));
			RevealCells(FindCellInPos(startCell,  1,  1));
				
			RevealCells(FindCellInPos(startCell,  0, -1));
			RevealCells(FindCellInPos(startCell,  0,  1));
			
		}
		
		return 0;
	}
	
	private Cell FindCellInPos(Cell startCell, int posX, int posY)
	{
		for (int i = 0; i < cells.Length; i++)
		{
			if(cells[i].GetColumn() == startCell.GetColumn() - posY && cells[i].GetRow() == startCell.GetRow() - posX)
			{
				// found a cell in set pos
				return cells[i];
			}
		}
		//did not find a cell in set pos
		return startCell;
	}
	
	
}