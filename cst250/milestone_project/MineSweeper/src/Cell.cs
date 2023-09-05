public class Cell
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

    public void SetVisited(bool visited) { this.visited = visited; }

    public void SetLiveNeighbors(int liveCount) { this.liveNeighbors = liveCount; }

    public bool GetVisited() { return visited; }

    public int GetLiveNeighbors() { return liveNeighbors; }

	public int GetRow() { return row; }

    public int GetColumn() { return column; }

	public bool GetLive() { return live; }
}