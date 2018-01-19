using UnityEngine;

public class PaddleController : MonoBehaviour {
    public float speed = 0.09f;

    private bool touchingWall1 = false;
    private bool touchingWall2 = false;

    public GameObject ball;

    private void Start() {
        if (ball == null) {
            ball = GameObject.FindGameObjectWithTag("ball");
        }
    }

    void FixedUpdate () {
        if (gameObject.name == "Paddle1") {
            if (!touchingWall2)
                if (Input.GetKey("w"))
                    transform.Translate(0, speed, 0);
            if (!touchingWall1)
                if (Input.GetKey("s"))
                    transform.Translate(0, -speed, 0);
        }
        else if (!StaticOptions.P2AI) {
            if (!touchingWall2)
                if (Input.GetKey(KeyCode.UpArrow))
                    transform.Translate(0, speed, 0);
            if (!touchingWall1)
                if (Input.GetKey(KeyCode.DownArrow))
                    transform.Translate(0, -speed, 0);
        } else {
            if (!touchingWall2)
                if (ball.transform.position.z > transform.position.z + 0.5)
                    transform.Translate(0, speed, 0);
            if (!touchingWall1)
                if (ball.transform.position.z < transform.position.z - 0.5)
                    transform.Translate(0, -speed, 0);
        }
        touchingWall1 = false;
        touchingWall2 = false;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "wall") {
            touchingWall1 = true;
        }
        if (collision.collider.tag == "wall2") {
            touchingWall2 = true;
        }
    }
}
