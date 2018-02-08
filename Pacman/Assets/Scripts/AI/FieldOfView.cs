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

	[Header("Set my friends to help!")]
	public bool multipleChasers = true;
	[TagSelector]
	public string Friends = "";
	private GameObject[] friends;

	public GameObject playerObject;

	private void Start() {
		StartCoroutine("FindTargetsWithDelay", 0.1f);
		if (playerObject == null)
			playerObject = GameObject.FindGameObjectWithTag("Player");
		if (multipleChasers) friends = GameObject.FindGameObjectsWithTag(Friends);
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
						GetComponent<Ghost>().alert();
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

	public void setTargetPlayer() {
		GetComponent<Ghost>().target = playerObject;
	}

	private float count = 0;
	[HideInInspector]
	public bool care = false;
	private float timeToCareFor = 4;

	private void FixedUpdate() {
		if (seePlayer) {
			count = 0;
			if (!care) {
				foreach (GameObject friend in friends) {
					friend.GetComponent<Ghost>().alert();
				}
				FindObjectOfType<AudioManager>().Play("alert");
				Debug.Log("Friends have been alerted");
			}
			care = true;
		}
		if (care) {
			count += Time.deltaTime;
			if (count >= timeToCareFor) {
				care = false;
				count = 0;
				Debug.Log("I stopped Caring");
				GameObject.FindGameObjectWithTag("AIManager").GetComponent<CreatPointsInterest>().setTargetsOfInterest();
				timeToCareFor = Random.Range(3.5f , 8.5f);
			}
		}
	}
}
