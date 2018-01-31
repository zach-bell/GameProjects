using UnityEngine;

public class GoalKeeping : MonoBehaviour {

    private GameObject[] goals;
    [SerializeField]
    private NextLevel nextLevel;
    [SerializeField]
    private bool proceedNextLevel = true;
    public bool runOneTime = true;

    public void repopulate() {
        goals = GameObject.FindGameObjectsWithTag("goal");
    }

    void LateUpdate () {
        if (runOneTime) {
            repopulate();
            runOneTime = false;
        }
        bool count = false;
        foreach (GameObject o in goals) {
            if (o != null)
                if (o.activeSelf)
                    count = true;
                else
                    Destroy(o);
        }
        if (!count) {
            nextLevel.LoadNextLevel();
        }
    }
}
