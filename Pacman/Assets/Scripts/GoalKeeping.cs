using UnityEngine;

public class GoalKeeping : MonoBehaviour {

    private GameObject[] goals;
    public NextLevel nextLevel;

    void Start() {
        goals = GameObject.FindGameObjectsWithTag("goal");
    }
    void Update () {
        bool count = false;
        foreach (GameObject o in goals) {
            if (o.activeSelf)
                count = true;
        }
        if (!count) {
            nextLevel.LoadNextLevel();
        }
    }
}
