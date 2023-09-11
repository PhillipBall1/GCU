public class Cell
{
	int row = -1;
	int column = -1;
	bool visited;
	bool live = false;
	int liveNeighbors;
	bool marked = false;
	
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
	
	public bool GetMarked() { return marked; }
	
	public void SetMarked(bool marked) { this.marked = marked; }
}
