using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Ghost : MonoBehaviour {

    public GameObject target;
    public NavMeshAgent agent;
    public PlayerCollision pCollision;
	
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        if (agent.isActiveAndEnabled)
            agent.destination = target.transform.position;
	}

    public void OnCollisionEnter(Collision collision) {
        
        //SceneManager.LoadScene("Menu");
    }
}
