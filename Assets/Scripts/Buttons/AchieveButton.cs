using UnityEngine;
using System.Collections;

public class AchieveButton : MonoBehaviour {

    public bool pressed = false;

	void OnClick() {
        pressed = !pressed;
        MainMenuAudio.isObjectActive = pressed;

		Application.LoadLevel("Acheivements");
	}
}