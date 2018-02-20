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
		} else {
			animator.SetBool("TurnRight", false);
		}
		if (Input.GetKeyDown("1")) {
			if (animator.GetInteger("CurrentAction") == 0) {
				animator.SetInteger("CurrentAction", 1);
			} else if (animator.GetInteger("CurrentAction") == 1) {
				animator.SetInteger("CurrentAction", 0);
			}
		}
		if (Input.GetKeyDown("2")) {
			if (animator.GetInteger("CurrentAction") == 0) {
				animator.SetInteger("CurrentAction", 2);
			}
			else if (animator.GetInteger("CurrentAction") == 2) {
				animator.SetInteger("CurrentAction", 0);
			}
		}
		if (Input.GetKeyDown("3")) {
			animator.SetLayerWeight(1, 1f);
			animator.SetInteger("CurrentAction", 3);
		}
		if (Input.GetKeyUp("3")) {
			animator.SetInteger("CurrentAction", 0);
		}
	}

	private void StopJumping() {
		animator.SetBool("Jumping", false);
	}
}
