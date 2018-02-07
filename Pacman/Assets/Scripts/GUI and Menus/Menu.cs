using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void resetScore() {
		StaticScript.GameScore = 0;
	}
	public void buttonClick() {
        SceneManager.LoadScene(1);
    }
}
