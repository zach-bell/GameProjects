using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

	public Dropdown resolutionDropdown;

	[Header("Qaulity Settting Variables")]
	public PostProcessingBehaviour cameraBehaviour;
	public PostProcessingProfile HQProfile;
	public PostProcessingProfile LQProfile;

	private Resolution[] resolutions;

	private void Start() {
		resolutions = Screen.resolutions;

		if (resolutionDropdown != null) {
			resolutionDropdown.ClearOptions();

			List<string> options = new List<string>();

			int currentResolution = 0;

			for (int i=0; i < resolutions.Length; i++) {
				string option = resolutions[i].width + " x " + resolutions[i].height;
				options.Add(option);

				if (resolutions[i].width == Screen.currentResolution.width &&
					resolutions[i].height == Screen.currentResolution.height) {
					currentResolution = i;
				}
			}
			resolutionDropdown.AddOptions(options);
			resolutionDropdown.value = currentResolution;
			resolutionDropdown.RefreshShownValue();
		}
	}

	public void changeLevel(int levelNumber) {
		SceneManager.LoadScene(levelNumber);
	}

	public void SetResolution(int resolutionIndex) {
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
		if (cameraBehaviour != null) {
			switch (qualityIndex) {
			case 0:
				cameraBehaviour.profile = HQProfile;
				StaticScript.Profile = HQProfile;
				break;
			case 1:
				cameraBehaviour.profile = LQProfile;
				StaticScript.Profile = LQProfile;
				break;
			}
		}
	}

	public void SetFullscreen(bool isFullscreen) {
		Screen.fullScreen = isFullscreen;
	}
}
