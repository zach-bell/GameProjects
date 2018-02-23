using UnityEngine;
using UnityEngine.UI;

public class ChangeMyText : MonoBehaviour {
	
	void LateUpdate () {
		GetComponent<Text>().text = staticSchock.FirstPerson ? "Press F : third person" : "Press F : first person";
	}
}
