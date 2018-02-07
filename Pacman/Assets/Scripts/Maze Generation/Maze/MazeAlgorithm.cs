using UnityEngine;


public class MazeAlgorithm : MazeAlgorithmBase {
	private int currentRow = 0;
	private int currentColumn = 0;
	private ProceduralNumberGenerator generator;
	private bool courseComplete = false;

	public MazeAlgorithm(MazeCell[,] mazeCells, Difficulty difficulty) : base(mazeCells) {
		generator = new ProceduralNumberGenerator(ResolveSeedProvider.Resolve(difficulty));

		CreateMaze();
	}

	public override void CreateMaze() {
		mazeCells[currentRow, currentColumn].Visited = true;


		while (!courseComplete) {
			Kill(); // Will run until it hits a dead end.
			Hunt(); // Finds the next unvisited cell with an adjacent visited cell. If it can't find any, it sets courseComplete to true.
		}
	}

	private void Kill() {
		while (RouteStillAvailable(currentRow, currentColumn)) {
			WallDirection direction = generator.GetNextNumber();

			if (direction == WallDirection.North && CellIsAvailable(currentRow - 1, currentColumn)) {
				// North
				DestroyWallIfExists(mazeCells[currentRow, currentColumn].NorthWall);
				DestroyWallIfExists(mazeCells[currentRow - 1, currentColumn].SouthWall);
				currentRow--;
			}
			else if (direction == WallDirection.South && CellIsAvailable(currentRow + 1, currentColumn)) {
				// South
				DestroyWallIfExists(mazeCells[currentRow, currentColumn].SouthWall);
				DestroyWallIfExists(mazeCells[currentRow + 1, currentColumn].NorthWall);
				currentRow++;
			}
			else if (direction == WallDirection.East && CellIsAvailable(currentRow, currentColumn + 1)) {
				// east
				DestroyWallIfExists(mazeCells[currentRow, currentColumn].EastWall);
				DestroyWallIfExists(mazeCells[currentRow, currentColumn + 1].WestWall);
				currentColumn++;
			}
			else if (direction == WallDirection.West && CellIsAvailable(currentRow, currentColumn - 1)) {
				// west
				DestroyWallIfExists(mazeCells[currentRow, currentColumn].WestWall);
				DestroyWallIfExists(mazeCells[currentRow, currentColumn - 1].EastWall);
				currentColumn--;
			}

			mazeCells[currentRow, currentColumn].Visited = true;
		}
	}

	private void Hunt() {
		courseComplete = true; // Set it to this, and see if we can prove otherwise below!

		for (int currentRow = 0; currentRow < mazeRows; currentRow++) {
			for (int currentColumn = 0; currentColumn < mazeColumns; currentColumn++) {
				if (!mazeCells[currentRow, currentColumn].Visited &&
					CellHasAnAdjacentVisitedCell(currentRow, currentColumn)) {
					courseComplete = false; // Yep, we found something so definitely do another Kill cycle.
					DestroyAdjacentWall(currentRow, currentColumn);
					mazeCells[currentRow, currentColumn].Visited = true;
					return; // Exit the function
				}
			}
		}
	}

	private bool RouteStillAvailable(int row, int column) {
		int availableRoutes = 0;

		if (row > 0 && !mazeCells[row - 1, column].Visited) {
			availableRoutes++;
		}

		if (row < mazeRows - 1 && !mazeCells[row + 1, column].Visited) {
			availableRoutes++;
		}

		if (column > 0 && !mazeCells[row, column - 1].Visited) {
			availableRoutes++;
		}

		if (column < mazeColumns - 1 && !mazeCells[row, column + 1].Visited) {
			availableRoutes++;
		}

		return availableRoutes > 0;
	}

	private bool CellIsAvailable(int row, int column) {
		return row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns && !mazeCells[row, column].Visited;
	}

	private void DestroyWallIfExists(GameObject wall) {
		if (wall != null) {
			GameObject.Destroy(wall);
		}
	}

	private bool CellHasAnAdjacentVisitedCell(int row, int column) {
		int visitedCells = 0;

		// Look 1 row up (north) if we're on row 1 or greater
		if (row > 0 && mazeCells[row - 1, column].Visited) {
			visitedCells++;
		}

		// Look one row down (south) if we're the second-to-last row (or less)
		if (row < (mazeRows - 2) && mazeCells[row + 1, column].Visited) {
			visitedCells++;
		}

		// Look one row left (west) if we're column 1 or greater
		if (column > 0 && mazeCells[row, column - 1].Visited) {
			visitedCells++;
		}

		// Look one row right (east) if we're the second-to-last column (or less)
		if (column < (mazeColumns - 2) && mazeCells[row, column + 1].Visited) {
			visitedCells++;
		}

		// return true if there are any adjacent visited cells to this one
		return visitedCells > 0;
	}

	private void DestroyAdjacentWall(int row, int column) {
		bool wallDestroyed = false;

		while (!wallDestroyed) {
			// int direction = Random.Range (1, 5);
			WallDirection direction = generator.GetNextNumber();

			if (direction == WallDirection.North && row > 0 && mazeCells[row - 1, column].Visited) {
				DestroyWallIfExists(mazeCells[row, column].NorthWall);
				DestroyWallIfExists(mazeCells[row - 1, column].SouthWall);
				wallDestroyed = true;
			}
			else if (direction == WallDirection.South && row < (mazeRows - 2) && mazeCells[row + 1, column].Visited) {
				DestroyWallIfExists(mazeCells[row, column].SouthWall);
				DestroyWallIfExists(mazeCells[row + 1, column].NorthWall);
				wallDestroyed = true;
			}
			else if (direction == WallDirection.East && column > 0 && mazeCells[row, column - 1].Visited) {
				DestroyWallIfExists(mazeCells[row, column].WestWall);
				DestroyWallIfExists(mazeCells[row, column - 1].EastWall);
				wallDestroyed = true;
			}
			else if (direction == WallDirection.West && column < (mazeColumns - 2) &&
					 mazeCells[row, column + 1].Visited) {
				DestroyWallIfExists(mazeCells[row, column].EastWall);
				DestroyWallIfExists(mazeCells[row, column + 1].WestWall);
				wallDestroyed = true;
			}
		}
	}
}