using System.Collections;
using UnityEngine;

public interface AIInterface {
	void UpdateState();

	void OnTriggerEnter(Collider other);

	void ToPatrolState();

	void ToAlertState();

	void ToChaseState();

	void ToStunnedState();
	void OnTriggerStay(Collider other);
}
