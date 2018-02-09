using UnityEngine;
using UnityEngine.UI;


public class ManageAI : MonoBehaviour {

	[TagSelector]
	public string ObjectsToManage = "";

	private GameObject[] myObjects;

	[SerializeField]
	private Text AlertText;

	private bool alerted;

	void Start () {
		myObjects = GameObject.FindGameObjectsWithTag(ObjectsToManage);
	}

	private bool oneTime = true;

	void Update () {
		if (alerted) {
			if (oneTime) {
				FindObjectOfType<AudioManager>().Play("alert");
				Debug.Log("alert sound played");
				foreach (GameObject basicallyTheGhosts in myObjects) {
					basicallyTheGhosts.GetComponent<Ghost>().alert();
				}
				Debug.Log("Friends have been alerted");
				oneTime = false;
			}
		} else oneTime = true;
	}

	public void Alert() {
		alerted = true;
		FindObjectOfType<AudioManager>().changeSnapshot(true);
		AlertText.text = "Alerted!!";
	}

	public void ChillOut() {
		alerted = false;
		FindObjectOfType<AudioManager>().changeSnapshot(false);
		GetComponent<CreatPointsInterest>().setTargetsOfInterest();
		AlertText.text = "";
	}
}
