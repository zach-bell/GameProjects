using UnityEngine;

public class ControllerScript : MonoBehaviour {

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
		animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));

		if (Input.GetButtonDown("Jump")) {
			animator.SetBool("Jumping", true);
			Invoke("StopJumping", 0.1f);
		}

		if (Input.GetKey("q")) {
			transform.Rotate(Vector3.down * Time.deltaTime * 100.0f);
			if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0f)) {
				animator.SetBool("TurnLeft", true);
			}
		} else {
			animator.SetBool("TurnLeft", false);
		}
		if (Input.GetKey("e")) {
			transform.Rotate(Vector3.up * Time.deltaTime * 100.0f);
			if ((Input.GetAxis("Vertical") == 0f) && (Input.GetAxis("Horizontal") == 0f)) {
				animator.SetBool("TurnRight", true);
			}
		}
		else {
			animator.SetBool("TurnRight", false);
		}
	}

	private void StopJumping() {
		animator.SetBool("Jumping", false);
	}
}
