using UnityEngine;

public class FollowBall : MonoBehaviour {

    private Transform ball = null;
    private Vector3 startPos;

    private GameObject ballObj = null;

    void Start () {
        startPos = transform.position;
    }
	
	void Update () {
        if (ballObj == null) {
            ballObj = GameObject.FindGameObjectWithTag("ball");
            ball = ballObj.transform;
        }
        transform.position = ((ball.position / 5) + startPos);
    }
}
