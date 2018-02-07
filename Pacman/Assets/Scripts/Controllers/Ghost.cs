using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour {

    public GameObject target;

    private NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
	}

	public void alert() {
		target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		if (agent.isActiveAndEnabled) {
			agent.destination = target.transform.position;
		}
	}
}
