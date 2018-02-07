using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GrabScore : MonoBehaviour {
	
	void Start () {
		GetComponent<Text>().text = "" + StaticScript.GameScore;
	}
	public bool ifMainMenu = false;

	void LateUpdate () {
		if(ifMainMenu) 
			GetComponent<Text>().text = "Last Score: " + StaticScript.GameScore;
		else
			GetComponent<Text>().text = "" + StaticScript.GameScore;
	}
}
