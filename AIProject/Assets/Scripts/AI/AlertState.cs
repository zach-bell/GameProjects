using System.Collections;
using UnityEngine;

public class AlertState : AIInterface {
	private PatterenedEnemy enemy;

	private float searchTimer = 0;

	public AlertState(PatterenedEnemy enemy) {
		this.enemy = enemy;
	}

	public void UpdateState() {
		Search();
	}

	

	private void DrawLine() {
		enemy.lineRenderer.enabled = enemy.lineRenderer.enabled ? true : true;
		enemy.lineRenderer.SetPosition(0, enemy.transform.position + enemy.sightLineOffset);
		enemy.lineRenderer.SetPosition(1, enemy.chaseTarget.position);
		enemy.lineRenderer.endWidth = 0;
		enemy.lineRenderer.startWidth = count / 80f;
	}

	private void Search() {
		enemy.meshRendererFlag.material.color = Color.yellow;
		enemy.navMeshAgent.destination = enemy.lastKnownTarget.position;
		if (enemy.navMeshAgent.isStopped) {
			enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
			searchTimer += Time.deltaTime;
			if (searchTimer >= enemy.searchingDuration)
				ToPatrolState();
		}
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

	public void ToAlertState() {
		Debug.Log("Can't transition to the same state");
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}

	public void ToPatrolState() {
		enemy.currentState = enemy.patrolState;
		searchTimer = 0f;
	}

	public void ToStunnedState() {
		enemy.currentState = enemy.stunnedState;
		searchTimer = 0f;
	}

	public void OnTriggerEnter(Collider other) {
	}
}