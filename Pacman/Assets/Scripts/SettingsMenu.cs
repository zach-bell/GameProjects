using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;

public class SettingsMenu : MonoBehaviour {

    public GameObject gameCamera;

	public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
        if (qualityIndex <= 1) {
            gameCamera.GetComponent<PostProcessingBehaviour>().enabled = false;
            StaticScript.CcOff = false;
        } else {
            gameCamera.GetComponent<PostProcessingBehaviour>().enabled = true;
            StaticScript.CcOff = true;
        }
    }
}
