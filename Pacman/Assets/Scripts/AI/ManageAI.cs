using UnityEngine;

public class ManageAI : MonoBehaviour {

	[TagSelector]
	public string ObjectsToManage = "";

	private GameObject[] myObjects;

	[HideInInspector]
	public bool alerted;

	private bool areAnyofThemAlerted = false;

	void Start () {
		myObjects = GameObject.FindGameObjectsWithTag(ObjectsToManage);
	}

	private bool oneTime = true;

	void Update () {
		areAnyofThemAlerted = false;
		foreach(GameObject thing in myObjects) {
			areAnyofThemAlerted = thing.GetComponent<FieldOfView>().care;
		}
		if (areAnyofThemAlerted) {
			alerted = true;
			if (oneTime) {
				FindObjectOfType<AudioManager>().Play("alert");
				Debug.Log("alert sound played");
				oneTime = false;
			}
		} else {
			alerted = false;
			oneTime = true;
		}
	}
}
