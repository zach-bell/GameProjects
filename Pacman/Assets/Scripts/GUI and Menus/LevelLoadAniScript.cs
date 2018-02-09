using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Vehicles.Ball;

public class LevelLoadAniScript : MonoBehaviour {

    private GameObject[] ghosts;
    private GameObject canvas;
    public BallUserControl ballUserControl;

    public void startNavigation() {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        canvas = GameObject.FindGameObjectWithTag("level load canvas");

        ballUserControl.enabled = true;

        canvas.SetActive(false);

        foreach (GameObject o in ghosts) {
            o.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

	public void PlayStartSound() {
		FindObjectOfType<AudioManager>().Play("level-load");
	}
	public void PlayMusic(int level) {
		switch (level) {
		case 1:
			FindObjectOfType<AudioManager>().Play("music-lvl1");
			break;
		case 2:
			FindObjectOfType<AudioManager>().Play("music-lvl2");
			break;
		case 0:
			FindObjectOfType<AudioManager>().Play("music-club-ambient");
			break;
		}
	}
}
