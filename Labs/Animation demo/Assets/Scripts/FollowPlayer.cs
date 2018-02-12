using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform PlayerT;

	public bool isCamera = false;

	public bool needParent = true;

	public Transform parent;

	public Transform lookAtPoint;

	public Vector3 Offset;

	void Start () {
		if (PlayerT == null)
			PlayerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {
		if (Input.GetKey("e"))
			if (needParent)
				parent.Rotate(Vector3.up * Time.deltaTime * 100.0f);
		if (Input.GetKey("q"))
			if (needParent)
				parent.Rotate(Vector3.down * Time.deltaTime * 100.0f);
		transform.position = (PlayerT.position + Offset);

		if (isCamera) {
			transform.LookAt(lookAtPoint);
		}
	}
}
