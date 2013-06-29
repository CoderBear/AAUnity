using UnityEngine;
using System.Collections;

public class PMButton : MonoBehaviour {
	public bool killMusic = false;
	public UISprite sprite;
    public MainMenuAudio script;
	
	void OnClick() {
		killMusic = true;
		Debug.Log("Perfectionist Pressed");
		sprite.gameObject.SetActive(true);

        script.turnMusicOff();

		LoadGame();
	}
	
	public void LoadGame() {
        GoogleAnalyticsHelper.trackGamePlayed("Perfectionist");
		Application.LoadLevel("Perfectionist");
	}
}