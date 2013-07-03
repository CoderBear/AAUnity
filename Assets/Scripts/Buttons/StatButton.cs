using UnityEngine;
using System.Collections;

public class StatButton : MonoBehaviour {

    public bool pressed = false;

	void OnClick() {
        pressed = !pressed;
        MainMenuAudio.isObjectActive = pressed;

        GoogleAnalyticsHelper.lastLevelLoaded = Application.loadedLevelName;

		Application.LoadLevel("Statistics");
	}
	
}