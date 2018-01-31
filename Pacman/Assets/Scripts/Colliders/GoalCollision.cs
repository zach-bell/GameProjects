using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : MonoBehaviour {

    public GameObject thisGoal;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player") {
            thisGoal.SetActive(false);
        }
    }
}
