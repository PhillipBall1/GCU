using Minesweeper;
using System;
using System.Collections.Generic;

public class Board
{
	public int size { get; set; }
	float difficulty;
	Cell[,] cells;

	public Board(int size, int difficulty)
	{
		this.size = size;
		this.difficulty = difficulty;
		
		cells = new Cell[size, size];

		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{ 
                Random random = new Random();
				int r = random.Next(0, 101);
				bool chance = r > difficulty;
				cells[i, j] = new Cell(i, j, chance);
			}
		}
		SetupLiveNeighbors();
	}

	public Cell GetCell(int r, int c) 
	{ 
		if(r >= size || r < 0 || c >= size || c < 0) return null;
		return cells[r, c];
	}

	public Cell GetCell(Cell startCell, int r, int c) 
	{ 
		if(r >= size || r < 0 || c >= size || c < 0) return startCell;
		return cells[r, c];
	}

	public int GetSize() { return size; }


	public void SetupLiveNeighbors()
	{
		for(int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				int liveCount = 0;
				liveCount += CheckBoundsLiveNeighbors(i - 1, j - 1);
				liveCount += CheckBoundsLiveNeighbors(i - 1, j);
				liveCount += CheckBoundsLiveNeighbors(i - 1, j + 1);
				
				liveCount += CheckBoundsLiveNeighbors(i , j - 1);
				liveCount += CheckBoundsLiveNeighbors(i , j + 1);
				
				liveCount += CheckBoundsLiveNeighbors(i + 1, j + 1);
				liveCount += CheckBoundsLiveNeighbors(i + 1, j);
				liveCount += CheckBoundsLiveNeighbors(i + 1, j - 1);
				cells[i,j].SetLiveNeighbors(liveCount);
			}
		}
	}
	
	public int CheckBoundsLiveNeighbors(int r, int c)
	{
		if(r >= size || r < 0 || c >= size || c < 0) return 0;
		
		if(cells[ r, c].GetLive()) return 1;
		
		return 0;
	}
	
	public int RevealCells(Cell startCell)
	{
		int r = startCell.GetRow();
		int c = startCell.GetColumn();
		
		//cell was a bomb so game over
		if(startCell.GetLive()) return -1;
		
		//make sure cell is not visited and it is an empty cell
		if(!startCell.GetVisited() && startCell.GetLiveNeighbors() == 0)
		{
			//set cell to visited
			startCell.SetVisited(true);
			
			//recursively reveal the cells in each direction around startCell
			RevealCells(GetCell(startCell, r - 1, c - 1));
			RevealCells(GetCell(startCell, r - 1, c));
			RevealCells(GetCell(startCell, r - 1, c + 1));
			
			RevealCells(GetCell(startCell, r + 1, c - 1));
			RevealCells(GetCell(startCell, r + 1, c));
			RevealCells(GetCell(startCell, r + 1, c + 1));
			
			RevealCells(GetCell(startCell, r, c - 1));
			RevealCells(GetCell(startCell, r, c + 1));	
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
	
	private bool CheckWon()
	{
		//int holder
		int fullCount = 0;
		for(int i = 0; i < size; i++)
		{
			for(int j = 0; j < size; j++)
			{
				//add an int for each cell that is visited and each cell that contains a bomb and is not visited 
				if(cells[i, j].GetVisited() == true) fullCount += 1;
				else if(!cells[i, j].GetVisited() == true && cells[i, j].GetLive()) fullCount += 1;
				else fullCount += 0;
			}
		}
		
		if(fullCount == size * size) return true;
		else return false;
	}
	
	//used to mark tiles with an X as if it were a bomb
	public void MarkTile(int row, int col)
	{
		//gets a single tile from the array at the set row and column from user
		// then checks if it is already marked, if not mark it, if it is then 
		// un-mark the cell 
		if(cells[row, col].GetMarked() == false) cells[row, col].SetMarked(true);
		else cells[row, col].SetMarked(false);
	}
}
