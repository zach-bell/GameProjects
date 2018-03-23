using UnityEngine;

public class Controller : MonoBehaviour {

	public float walkSpeed = 4;
	public float runSpeed = 6;
	public float gravity = -12;
	[Range(0,1)]
	public float airControlPercent;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	[HideInInspector]
	public float animationSpeedPercent;

	Animator animator;
	Transform cameraT;
	CharacterController controller;

	[SerializeField]
	private Light flashLight;

	void Start () {
		animator = GetComponent<Animator>();
		cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController>();
	}

	private bool lockIt = true;

	void Update () {
		if (Input.GetKeyDown(KeyCode.F)) {
			if (lockIt) {
				if (flashLight.enabled) {
					flashLight.enabled = false;
				} else {
					flashLight.enabled = true;
				}
				lockIt = false;
			}
		}
		else {
			lockIt = true;
		}

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = Input.GetKey(KeyCode.LeftShift);

		Move(inputDir, running);

		animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * 0.5f);
		//animationSpeedPercent = (currentSpeed / walkSpeed);
		animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
	}

	void Move(Vector2 inputDir, bool running) {
		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}
		// float targetSpeed = walkSpeed * inputDir.magnitude;
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		velocityY += Time.deltaTime * gravity;

		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

		if (controller.isGrounded)
			velocityY = 0;
	}

	private float GetModifiedSmoothTime(float smoothTime) {
		if (controller.isGrounded)
			return smoothTime;
		if (airControlPercent == 0)
			return float.MaxValue;
		return smoothTime / airControlPercent;
	}
}
