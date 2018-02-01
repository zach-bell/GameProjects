using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour {

	[SerializeField]
	private Transform player;
	[SerializeField]
	private GameObject playerObject;

	private Vector3 startPos;

    private void Start() {
        startPos = transform.position;
		if (playerObject == null) {
			playerObject = GameObject.FindGameObjectWithTag("Player");
			player = playerObject.GetComponent<Transform>();
		}
    }

    void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 2) transform.position = ((player.position / 1.8f) + startPos);
        else transform.position = ((player.position / 5) + startPos);

    }
}
