using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2BoundsScript : MonoBehaviour {

    public int player;
    private GameObject ballObj = null;
    public ScoreKeeperScript scoreKeeper;

    void Start() {
        if (ballObj == null) {
            ballObj = GameObject.FindGameObjectWithTag("ball");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        switch (player){
        case 1:
            scoreKeeper.addScore(1);
            scoreKeeper.haultBall();
            break;
        case 2:
            scoreKeeper.addScore(2);
            scoreKeeper.haultBall();
            break;
        default:
            scoreKeeper.resetBall();
            break;
        }
    }
}
