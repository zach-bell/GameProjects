using UnityEngine;

public class GoalKeeping : MonoBehaviour {

    private GameObject[] goals;
    [SerializeField]
    private NextLevel nextLevel;
    [SerializeField]
    private bool proceedNextLevel = true;
	[HideInInspector]
    public bool runOneTime = true;
	public GameObject MazeLoader;

    public void repopulate() {
        goals = GameObject.FindGameObjectsWithTag("goal");
    }

	private void regenerateLevel() {
		waiting = true;
		MazeLoader.GetComponent<MazeManager>().destroyMaze();
		MazeLoader.GetComponent<MazeManager>().createMaze();
	}

	private bool waiting = false;
	private float timeToWait = 1;

    void LateUpdate () {
        if (runOneTime) {
            repopulate();
            runOneTime = false;
        }
		bool count = false;
		if (!waiting) {
			foreach (GameObject o in goals) {
				if (o != null)
					if (o.activeSelf)
						count = true;
					else
						Destroy(o);
			}
		} else {
			timeToWait += Time.deltaTime;
			if (timeToWait >= 1) {
				repopulate();
				waiting = false;
				timeToWait = 0;
				count = true;
			}
		}
        if (!count & proceedNextLevel) {
            nextLevel.LoadNextLevel();
        }
		if (!count & !proceedNextLevel & !waiting) {
			regenerateLevel();
		}
		
	}
}
