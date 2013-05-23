using UnityEngine;
using System.Collections;

public class FAButton : MonoBehaviour {
	public bool killMusic = false;
	public UISprite sprite;
	
	void OnClick() {
		killMusic = true;
		Debug.Log("Fast Apples Pressed");
		sprite.gameObject.SetActive(true);
		LoadGame();
	}
	
	public void LoadGame() {
		Application.LoadLevel("Fast Apples");
	}
}