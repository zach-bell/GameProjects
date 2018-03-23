using System.Collections;
using UnityEngine;

public class StunnedState : AIInterface {
	private PatterenedEnemy patterenedEnemey;

	public StunnedState(PatterenedEnemy patterenedEnemey) {
		this.patterenedEnemey = patterenedEnemey;
	}

	public void OnTriggerEnter(Collider other) {
	}

	public void OnTriggerStay(Collider other) {
	}

	public void ToAlertState() {
	}

	public void ToChaseState() {
	}

	public void ToPatrolState() {
	}

	public void ToStunnedState() {
	}

	public void UpdateState() {
	}
}
