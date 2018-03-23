using System.Collections;
using UnityEngine;

public class ChaseState : AIInterface {
	private PatterenedEnemy enemy;

	public ChaseState(PatterenedEnemy patterenedEnemey) {
		enemy = patterenedEnemey;
	}

	private void DrawLine() {
		enemy.lineRenderer.enabled = enemy.lineRenderer.enabled ? true : true;
		enemy.lineRenderer.SetPosition(0, enemy.transform.position + enemy.sightLineOffset);
		enemy.lineRenderer.SetPosition(1, enemy.chaseTarget.position);
		enemy.lineRenderer.endWidth = 0;
		enemy.lineRenderer.startWidth = 0.02f;
	}
	
	public void OnTriggerStay(Collider other) {
		if (other.gameObject == enemy.player) {
			Vector3 direction = other.transform.position - enemy.transform.position;
			float angle = Vector3.Angle(direction, enemy.transform.forward);
			if (angle < enemy.viewAngle * 0.5f) {
				RaycastHit hit;
				if (Physics.Raycast(enemy.transform.position + enemy.transform.up, direction.normalized, out hit, enemy.col.radius)) {
					enemy.chaseTarget = hit.transform;
				} else {
					enemy.lineRenderer.enabled = enemy.lineRenderer.enabled ? false : false;
					ToAlertState();
				}
			}
		}
	}
	public void OnTriggerEnter(Collider other) {
	}

	public void ToAlertState() {
		enemy.currentState = enemy.alertState;
	}

	private void Chase() {
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		enemy.navMeshAgent.isStopped = false;
		DrawLine();
	}

	public void ToChaseState() {
	}

	public void ToPatrolState() {
	}

	public void ToStunnedState() {
		Debug.Log("Who threw that piece of paper at me?");
	}

	public void UpdateState() {
		Chase();
	}

	
}
