public abstract class MazeAlgorithmBase {
	public MazeAlgorithmBase(MazeCell[,] mazeCells) {
		this.mazeCells = mazeCells;
		mazeRows = mazeCells.GetLength(0);
		mazeColumns = mazeCells.GetLength(1);
	}

	protected MazeCell[,] mazeCells;
	protected int mazeRows, mazeColumns;

	public abstract void CreateMaze();
}