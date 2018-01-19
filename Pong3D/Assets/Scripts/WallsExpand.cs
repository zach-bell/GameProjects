using UnityEngine;

public class WallsExpand : MonoBehaviour {

    public GameObject wall1, wall2;
    public PaddleController p1, p2;
    public float wallSpeedIncrement = 0.2f;
    
    private float timeIncrement = 4;
    private readonly float maxTime = 4;
	
	void Update () {
        timeIncrement -= Time.deltaTime;
        if (timeIncrement <= 0) {
            timeIncrement = maxTime;
            if (wall1.transform.position.z > -50) {
                float temp = wall1.transform.position.z;
                temp -= wallSpeedIncrement;
                wall1.transform.position.Set(0,0,temp);
            }
            if (wall2.transform.position.z < 50) {
                float temp = wall2.transform.position.z;
                temp += wallSpeedIncrement;
                wall2.transform.position.Set(0, 0, temp);
            }
        }
	}
}
