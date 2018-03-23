using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour {

	public Transform[] waypoints;
	public GameObject aimanager;
	public GameObject player;

	[HideInInspector]
	public bool isAlerted = false;
	Animator animator;

	private NavMeshAgent nav;
	private int nextWayPoint;
	[HideInInspector]
	public float animationSpeedPercent;

	private void Start() {
		nav = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		if (player == null)
			player = GameObject.FindGameObjectWithTag("Player");
		if (aimanager == null)
			aimanager = GameObject.FindGameObjectWithTag("AIManager");
	}

	void Update () {
		if (!ended)
			if (isAlerted) {
				nav.destination = player.transform.position;
				nav.isStopped = false;
			} else {
				nav.isStopped = false;
				if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending) {
					nextWayPoint = (nextWayPoint + 1) % waypoints.Length;
				}
				nav.destination = waypoints[nextWayPoint].position;
			}
		animationSpeedPercent = nav.isStopped ? 0 : 0.7f;
		animator.SetFloat("speedPercent", animationSpeedPercent, 0.12f, Time.deltaTime);
	}
	private bool ended = false;
	private void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player")) {
			ended = true;
			nav.enabled = false;
			aimanager.GetComponent<ManageAI>().StopEverything();
			player.GetComponent<Controller>().enabled = false;
		}
	}
}
