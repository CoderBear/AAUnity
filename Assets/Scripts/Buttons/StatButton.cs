using UnityEngine;
using System.Collections;

public class StatButton : MonoBehaviour {

    public bool pressed = false;

	void OnClick() {
        pressed = !pressed;
        MainMenuAudio.isObjectActive = pressed;

        AdvertisementHandler.DisableAds();
		Application.LoadLevel("Statistics");
	}
	
}