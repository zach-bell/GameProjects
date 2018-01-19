using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 0;

    public GameObject completeLevelUI;

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
    }

	public void EndGame() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
