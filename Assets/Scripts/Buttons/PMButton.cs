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

        AdvertisementHandler.DisableAds();
		LoadGame();
	}
	
	public void LoadGame() {
		Application.LoadLevel("Perfectionist");
	}
}