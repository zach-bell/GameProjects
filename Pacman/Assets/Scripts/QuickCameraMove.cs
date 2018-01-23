using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class QuickCameraMove : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float lookSensativity = 3f;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private bool lockCursor = true;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;
    
	void Start () {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None; ;

    }
	
	void Update () {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVerticle = transform.forward * zMove;

        velocity = (moveHorizontal + moveVerticle).normalized * speed;

        float yRotate = Input.GetAxisRaw("Mouse X");
        float xRotate = Input.GetAxisRaw("Mouse Y");

        rotation = new Vector3(0f, yRotate, 0f) * lookSensativity;
        cameraRotation = new Vector3(-xRotate, 0f, 0f) * lookSensativity;
    }

    void FixedUpdate() {
        if (velocity != Vector3.zero)
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (cam != null)
            transform.Rotate(cameraRotation);
    }
}
