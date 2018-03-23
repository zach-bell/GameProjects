using System.Collections;
using UnityEngine;

public class PatrolState : AIInterface {
	private PatterenedEnemy enemy;
	private int nextWayPoint;

	public PatrolState(PatterenedEnemy enemy) {
		this.enemy = enemy;
	}

	public void UpdateState() {
		Patrol();
	}

	private float count = 0;

	public void OnTriggerStay(Collider other) {
		if (other.gameObject == enemy.player) {
			Vector3 direction = other.transform.position - enemy.transform.position;
			float angle = Vector3.Angle(direction, enemy.transform.forward);
			if (angle < enemy.viewAngle * 0.5f) {
				RaycastHit hit;
				if (Physics.Raycast(enemy.transform.position + enemy.transform.up, direction.normalized, out hit, enemy.col.radius)) {
					count += Time.deltaTime;
					enemy.chaseTarget = hit.transform;
					if (count >= enemy.sightDelay) {
						count = 0;
						enemy.lineRenderer.enabled = enemy.lineRenderer.enabled ? false : false;
						ToChaseState();
					}
					DrawLine();
				}
			}
		}
	}

	

	private void DrawLine() {
		enemy.lineRenderer.enabled = enemy.lineRenderer.enabled ? true : true;
		enemy.lineRenderer.SetPosition(0, enemy.transform.position + enemy.sightLineOffset);
		enemy.lineRenderer.SetPosition(1, enemy.chaseTarget.position);
		enemy.lineRenderer.endWidth = 0;
		enemy.lineRenderer.startWidth = count / 80f;
	}

	private void Patrol() {
		enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.waypoints[nextWayPoint].position;
		enemy.navMeshAgent.isStopped = false;

		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) {
			nextWayPoint = (nextWayPoint + 1) % enemy.waypoints.Length;
		}
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
	}

	public void ToStunnedState() {
		enemy.currentState = enemy.stunnedState;
	}

	public void ToPatrolState() {
		Debug.Log("Can't transition to the same state");
	}

	public void OnTriggerEnter(Collider other) {
	}
}
