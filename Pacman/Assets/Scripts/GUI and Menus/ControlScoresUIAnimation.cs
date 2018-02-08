using UnityEngine;
using UnityEngine.UI;

public class ControlScoresUIAnimation : MonoBehaviour {

	void Update () {
		if (GameObject.FindGameObjectWithTag("Ghost").GetComponent<FieldOfView>().care) {
			GetComponent<Image>().enabled = true;
		} else {
			GetComponent<Image>().enabled = false;
		}
	}
}
