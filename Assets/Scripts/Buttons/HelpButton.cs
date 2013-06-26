using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {

    public bool pressed = false;

	void OnClick() {
        pressed = !pressed;
        MainMenuAudio.isObjectActive = pressed;

        AdvertisementHandler.DisableAds();
		Debug.Log("Help Button Pressed");
		Application.LoadLevel("HelpMenu");
	}
}