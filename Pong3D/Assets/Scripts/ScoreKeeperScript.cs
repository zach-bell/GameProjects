using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperScript : MonoBehaviour {

    private int p1Score = 0, p2Score = 0;
    private bool isWaiting = false;
    private Rigidbody playerRigidbody;
    private Ball ballScript;
    private float timeToHault = 0;

    public float WaitTime = 2;
    public Text p1Text, p2Text;
    public GameObject ballObj;

    private void Start() {
        if (ballObj == null) {
            ballObj = GameObject.FindGameObjectWithTag("ball");
        }
        ballScript = ballObj.GetComponent<Ball>();
        timeToHault = WaitTime;
    }

    private void Update() {
        if (isWaiting) {
            if (timeToHault <= 0) {
                unHaultBall();
                timeToHault = WaitTime;
            }
            timeToHault -= Time.deltaTime;
        }
    }

    public void addScore(int playerNumber) {
        switch(playerNumber) {
        case 2:
            p1Score++;
            p1Text.text = ""+p1Score;
            break;
        case 1:
            p2Score++;
            p2Text.text = ""+p2Score;
            break;
        default:
            Debug.Log("How did you get here...");
            break;
        }
    }

    public void resetBall() {
        haultBall();
        ballScript.ResetMotion();
    }

    public void haultBall() {
        isWaiting = true;
        Debug.Log("Haulted ball");
        ballScript.StopMotion();
    }

    public void unHaultBall() {
        isWaiting = false;
        ballScript.ContinueMotion();
    }
}
