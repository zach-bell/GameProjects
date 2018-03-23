using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(LineRenderer), typeof(SphereCollider))]
public class PatterenedEnemy : MonoBehaviour {

	[Header("Patrol vars")]
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightDelay = 2f;
	public Vector3 sightLineOffset = new Vector3(0, 1.7f, 0);
	[Range(0, 290)]
	public float viewAngle = 70f;
	public Transform[] waypoints;

	[Header("Other vars")]
	public Vector3 offset = new Vector3(0, 0.5f, 0);
	public MeshRenderer meshRendererFlag;

	[HideInInspector]
	public SphereCollider col;
	[HideInInspector]
	public Transform chaseTarget;
	[HideInInspector]
	public LineRenderer lineRenderer;
	[HideInInspector]
	public Transform lastKnownTarget;
	[HideInInspector]
	public AIInterface currentState;
	[HideInInspector]
	public ChaseState chaseState;
	[HideInInspector]
	public AlertState alertState;
	[HideInInspector]
	public PatrolState patrolState;
	[HideInInspector]
	public StunnedState stunnedState;
	[HideInInspector]
	public NavMeshAgent navMeshAgent;
	[HideInInspector]
	public GameObject player;

	private void Awake() {
		chaseState = new ChaseState(this);
		alertState = new AlertState(this);
		patrolState = new PatrolState(this);
		stunnedState = new StunnedState(this);

		navMeshAgent = GetComponent<NavMeshAgent>();
		lineRenderer = GetComponent<LineRenderer>();
		col = GetComponent<SphereCollider>();
		lastKnownTarget = GetComponent<Transform>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start () {
		currentState = patrolState;
	}

	void Update () {
		currentState.UpdateState();
	}

	private void OnTriggerStay(Collider other) {
		currentState.OnTriggerStay(other);
	}

	private void OnTriggerEnter(Collider other) {
		currentState.OnTriggerEnter(other);
	}
}
