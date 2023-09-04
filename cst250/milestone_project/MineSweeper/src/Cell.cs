class Cell
{
	int row;
	int column;
	bool visited;
	bool live;
	int liveNeighbors;
	
	public Cell(int row, int column, bool live)
	{
		this.row = row;
		this.column = column;
		this.live = live;
	}
	
	private void SetVisited(bool visited)
	{
		this.visited = visited;
	}
	
	private bool GetVisited() { return visited; }
	
	private int GetLiveNeighbors() { return liveNeighbors; }
}