﻿using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;
using System.Collections.Generic;
using UnityEngine.AI;

public class PlayerCollision : MonoBehaviour {

    public BallUserControl ballUserControl;
    private GameObject[] ghosts;
    public GameObject loseUI;

    private void Start() {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
    }

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Ghost") {
			ballUserControl.enabled = false;
			foreach (GameObject o in ghosts) {
				o.GetComponent<NavMeshAgent>().enabled = false;
			}
			FindObjectOfType<AudioManager>().Stop("music-club-ambient");
			FindObjectOfType<AudioManager>().Play("lose");
			loseUI.SetActive(true);
		}
		if (collision.collider.tag == "goal") {
			FindObjectOfType<AudioManager>().Play("collect",Random.Range(0.65f,1.30f));
			StaticScript.GameScore ++;
		}
	}
}
