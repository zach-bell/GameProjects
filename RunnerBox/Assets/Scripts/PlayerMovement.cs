using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 0;
    public float upwardForce = 0;
    public float movementMod = 1;
    public bool canMove = true;
	
	void FixedUpdate () {

        rb.AddForce(0, upwardForce * Time.deltaTime, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") & canMove) {
            rb.AddForce((500 * movementMod) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") & canMove) {
            rb.AddForce((-500 * movementMod) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
