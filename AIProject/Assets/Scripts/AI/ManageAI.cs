using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManageAI : MonoBehaviour {

	[TagSelector]
	public string ObjectsToManage = "";

	private GameObject[] myObjects;

	[SerializeField]
	private Text AlertText;
	[SerializeField]
	private Text EndgameText;

	private bool alerted;

	void Start () {
		myObjects = GameObject.FindGameObjectsWithTag(ObjectsToManage);
		FindObjectOfType<AudioManager>().calmPassMusic.TransitionTo(0.1f);
	}

	private bool oneTime = true;

	void Update () {
		if (alerted) {
			if (oneTime) {
				FindObjectOfType<AudioManager>().Play("alert");
				Debug.Log("alert sound played");
				foreach (GameObject enemy in myObjects) {
					enemy.GetComponent<AIController>().isAlerted = true;
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
		foreach (GameObject enemy in myObjects) {
			enemy.GetComponent<AIController>().isAlerted = false;
		}
		AlertText.text = "";
	}
	private float temp = 0f;
	public void StopEverything() {
		foreach (GameObject enemy in myObjects) {
			enemy.GetComponent<NavMeshAgent>().enabled = false;
		}
		EndgameText.text = "Game Over";
		temp += Time.deltaTime;
		if (temp >= 3f)
			SceneManager.LoadScene(2);
	}
}
