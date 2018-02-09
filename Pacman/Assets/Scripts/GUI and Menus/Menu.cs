using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	private void Start() {
		QualitySettings.SetQualityLevel(0);
	}

	public void resetScore() {
		StaticScript.GameScore = 0;
	}
	public void buttonClick(int levelNumber) {
        SceneManager.LoadScene(levelNumber);
    }
}
