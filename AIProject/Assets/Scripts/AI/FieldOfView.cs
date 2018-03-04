using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

	public float viewRadius = 15;
	[Range(0,360)]
	public float viewAngle = 0;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public bool seePlayer = false;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	public GameObject AIManager;

	[Header("Set my friends to help!")]
	public bool multipleChasers = true;

	private void Start() {
		StartCoroutine("FindTargetsWithDelay", 0.1f);
		if (AIManager == null) AIManager = GameObject.FindGameObjectWithTag("AIManager");
	}

	IEnumerator FindTargetsWithDelay(float delay) {
		while (true) {
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
		}
	}

	private bool seePlayerOneTime = true;

	void FindVisibleTargets() {
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
		for (int i=0; i < targetsInViewRadius.Length; i++) {
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.position - transform.position).normalized;
			if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
				float dstToTarget = Vector3.Distance(transform.position, target.position);
				if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) {
					visibleTargets.Add(target);
					if (seePlayerOneTime) {
						seePlayer = true;
						// Alert other AI
						seePlayerOneTime = false;
					}
				}
			} else {
				seePlayer = false;
				seePlayerOneTime = true;
			}
		}
	}

	public Vector3 directionFromAngle (float angleInDegrees, bool angleIsGlobal) {
		if (!angleIsGlobal)
			angleInDegrees += transform.eulerAngles.y;
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
	}

	private float count = 0;
	[HideInInspector]
	public bool care = false;
	private float timeToCareFor = 4;

	private void FixedUpdate() {
		if (seePlayer) {
			count = 0;
			if (!care) {
				// still alert other AI
			}
			care = true;
		}
		if (care) {
			count += Time.deltaTime;
			if (count >= timeToCareFor) {
				care = false;
				count = 0;
				Debug.Log(this.name + " stopped Caring");
				// Stop alert
				timeToCareFor = Random.Range(3.5f , 8.5f);
			}
		}
	}
}
