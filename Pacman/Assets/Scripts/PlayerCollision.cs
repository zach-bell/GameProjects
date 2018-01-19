using UnityEngine;
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
            foreach(GameObject o in ghosts) {
                o.GetComponent<NavMeshAgent>().enabled = false;
            }
            loseUI.SetActive(true);
        }
    }
}
