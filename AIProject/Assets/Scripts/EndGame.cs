using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player")) {
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene(3);
		}
	}
}
