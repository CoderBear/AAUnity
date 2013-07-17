using UnityEngine;
using System.Collections;

public class FAButton : MonoBehaviour {
	public bool killMusic = false;
	public UISprite sprite;
    public MainMenuAudio script;
	
	void OnClick() {
		killMusic = true;
		Debug.Log("Fast Apples Pressed");
		sprite.gameObject.SetActive(true);
        script.turnMusicOff();

		LoadGame();
	}
	
	public void LoadGame() {
		Application.LoadLevel("Fast Apples");
	}
}