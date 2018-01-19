using UnityEngine;

public class BallColider : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "wall" || collision.collider.tag == "wall2") {
            FindObjectOfType<AudioManager>().Play("wall-hit");
        }
        if (collision.collider.tag == "paddle") {
            FindObjectOfType<AudioManager>().Play("hit");
        }
    }
}
