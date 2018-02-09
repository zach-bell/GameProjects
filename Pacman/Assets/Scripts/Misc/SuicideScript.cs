using UnityEngine;

public class SuicideScript : MonoBehaviour {

	public void KillMySelf() {
		Debug.Log("Goodbye world!");
		Destroy(gameObject);
	}
}
