using UnityEngine;

public class FollowPlayerBetter : MonoBehaviour {

    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Vector3 offset;

    private void Start() {
        if (playerPos == null)
            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        transform.position = playerPos.position + offset;
    }
}
