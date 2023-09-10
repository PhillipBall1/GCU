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

	private void CreateCell(int i, int j, bool chance)
	{
		cells[start] = new Cell(i, j, chance);
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
		//cell was a bomb so game over
		if(startCell.GetLive()) return -1;
		
		//make sure cell is not visited and it is an empty cell
		if(!startCell.GetVisited() && startCell.GetLiveNeighbors() == 0)
		{
			//set cell to visited
			startCell.SetVisited(true);
			
			//recursively reveal the cells in each direction around startCell
			RevealCells(FindCellInPos(startCell, -1, -1));
			RevealCells(FindCellInPos(startCell, -1,  0));
			RevealCells(FindCellInPos(startCell, -1,  1));
			
			RevealCells(FindCellInPos(startCell,  1, -1));
			RevealCells(FindCellInPos(startCell,  1,  0));
			RevealCells(FindCellInPos(startCell,  1,  1));
				
			RevealCells(FindCellInPos(startCell,  0, -1));
			RevealCells(FindCellInPos(startCell,  0,  1));
			
		}
		else
		{
			//set cell as visited as we want the neighbor numbers to begin to show up
			startCell.SetVisited(true);
		}
		
		//function to check and see if the board is revealed with no bombs revealed
		if(CheckWon()) return 1;
		
		//if the cell is marked and it is a visited / seen cell, we want to remove the mark on it
		if(startCell.GetVisited()) startCell.SetMarked(false);
		
		//nothing came from the recursion so just return 0
		return 0;
	}
	
	//returns a cell from a certain pos, used to find a cell in a set pos from a start cell 
	private Cell FindCellInPos(Cell startCell, int posX, int posY)
	{
		for (int i = 0; i < cells.Length; i++)
		{
			//check to make sure the cell column and row match to the altered pos from the start cell
			if(cells[i].GetColumn() == startCell.GetColumn() - posY && cells[i].GetRow() == startCell.GetRow() - posX)
			{
				// found a cell in set pos
				return cells[i];
			}
		}
		//did not find a cell in set pos
		return startCell;
	}
	
	private bool CheckWon()
	{
		//int holder
		int fullCount = 0;
		for(int i = 0; i < cells.Length; i++)
		{
			//add an int for each cell that is visited and each cell that contains a bomb and is not visited 
			if(cells[i].GetVisited() == true) fullCount += 1;
			else if(!cells[i].GetVisited() == true && cells[i].GetLive()) fullCount += 1;
			else fullCount += 0;
		}
		
		if(fullCount == cells.Length) return true;
		else return false;
	}
	
	//used to mark tiles with an X as if it were a bomb
	public void MarkTile(int row, int col)
	{
		//gets a single tile from the array at the set row and column from user
		// then checks if it is already marked, if not mark it, if it is then 
		// un-mark the cell 
		int tile = row + col;
		if(cells[tile].GetMarked() == false) cells[tile].SetMarked(true);
		else cells[tile].SetMarked(false);
	}
	
	
}
