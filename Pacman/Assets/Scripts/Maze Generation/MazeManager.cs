using UnityEngine;

public class MazeManager : MonoBehaviour {
	public int mazeRows, mazeColumns;
	public GameObject wall;
	public GameObject floor;
	public float size = 2f;
	public Difficulty Difficulty;

	[HideInInspector]
	public MazeCell[,] mazeCells;


	[SerializeField]
	private Transform objectPos;

	// Use this for initialization
	void Awake() {
		objectPos = objectPos ?? transform;
		createMaze();
	}

	public void destroyMaze() {
		Debug.Log("destroying maze");
		foreach (MazeCell cell in mazeCells) {
			Destroy(cell.NorthWall);
			Destroy(cell.SouthWall);
			Destroy(cell.EastWall);
			Destroy(cell.WestWall);
			Destroy(cell.Floor);
		}
	}

	public void createMaze() {
		Debug.Log("creating maze");
		mazeCells = new MazeCell[mazeRows, mazeColumns];
		MazeCell[,] unbuiltMaze = BuildMazeGrid();
		MazeAlgorithmBase ma = new MazeAlgorithm(unbuiltMaze, this.Difficulty);
		ma.CreateMaze();
	}

	private MazeCell[,] BuildMazeGrid() {
		for (int currentRow = 0; currentRow < mazeRows; currentRow++) {
			for (int currentColumn = 0; currentColumn < mazeColumns; currentColumn++) {
				mazeCells[currentRow, currentColumn] = new MazeCell();

				mazeCells[currentRow, currentColumn].Floor =
					Instantiate(floor, new Vector3(currentRow * size, -(size / 5f), currentColumn * size) + objectPos.position,
						Quaternion.identity) as GameObject;
				mazeCells[currentRow, currentColumn].Floor.name = "Floor " + currentRow + "," + currentColumn;

				if (currentColumn == 0) {
					mazeCells[currentRow, currentColumn].WestWall =
						Instantiate(wall, new Vector3(currentRow * size, 0, (currentColumn * size) - (size / 2f)) + objectPos.position,
							Quaternion.identity) as GameObject;
					mazeCells[currentRow, currentColumn].WestWall.name = "West Wall " + currentRow + "," + currentColumn;
				}

				mazeCells[currentRow, currentColumn].EastWall =
					Instantiate(wall, new Vector3(currentRow * size, 0, (currentColumn * size) + (size / 2f)) + objectPos.position,
						Quaternion.identity) as GameObject;
				mazeCells[currentRow, currentColumn].EastWall.name = "East Wall " + currentRow + "," + currentColumn;

				if (currentRow == 0) {
					mazeCells[currentRow, currentColumn].NorthWall =
						Instantiate(wall, new Vector3((currentRow * size) - (size / 2f), 0, currentColumn * size) + objectPos.position,
							Quaternion.identity) as GameObject;
					mazeCells[currentRow, currentColumn].NorthWall.name = "North Wall " + currentRow + "," + currentColumn;
					mazeCells[currentRow, currentColumn].NorthWall.transform.Rotate(Vector3.up * 90f);
				}

				mazeCells[currentRow, currentColumn].SouthWall =
					Instantiate(wall, new Vector3((currentRow * size) + (size / 2f), 0, currentColumn * size) + objectPos.position,
						Quaternion.identity) as GameObject;
				mazeCells[currentRow, currentColumn].SouthWall.name = "South Wall " + currentRow + "," + currentColumn;
				mazeCells[currentRow, currentColumn].SouthWall.transform.Rotate(Vector3.up * 90f);
			}
		}

		return mazeCells;
	}
}
