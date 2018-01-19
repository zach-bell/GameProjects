using UnityEngine;
using UnityStandardAssets.Vehicles.Ball;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 startPos;

    public GameObject playerObject;
    private BallUserControl userControl;
    private GameObject canvas;

    private void Start() {
        startPos = transform.position;
        if (playerObject == null)
            playerObject = GameObject.FindGameObjectWithTag("Player");
        userControl = playerObject.GetComponent<BallUserControl>();
        canvas = GameObject.FindGameObjectWithTag("level load canvas");
    }

    void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 2) transform.position = ((player.position / 1.8f) + startPos);
        else transform.position = ((player.position / 5) + startPos);

    }
}
