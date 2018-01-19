using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BetterButton : MonoBehaviour {

    private bool aiON = false;
    public Text buttonText;

    public void toggleAI() {
        if (aiON) {
            StaticOptions.P2AI = false;
            aiON = false;
            buttonText.text = "2P ON";
        }else if (!aiON) {
            StaticOptions.P2AI = true;
            aiON = true;
            buttonText.text = "2P OFF";
        }
    }

    public void buttonClick() {
        SceneManager.LoadScene(1);
    }
}
