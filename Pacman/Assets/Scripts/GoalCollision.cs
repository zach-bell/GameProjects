using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : MonoBehaviour {

    private GameObject[] goals;
    private bool endGame = false;
    public GameObject thisGoal;
    public NextLevel nextLevel;

	void Start () {
		goals = GameObject.FindGameObjectsWithTag("goal");
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            thisGoal.SetActive(false);
            foreach (GameObject o in goals) {
                endGame = !o.activeSelf;
            }
            if (endGame) {
                nextLevel.LoadNextLevel();
            }
        }
    }
}
