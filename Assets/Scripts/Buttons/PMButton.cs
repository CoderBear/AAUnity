using UnityEngine;
using System.Collections;

public class PMButton : MonoBehaviour {
	public bool killMusic = false;
	public UISprite sprite;
	
	void OnClick() {
		killMusic = true;
		Debug.Log("Perfectionist Pressed");
		sprite.gameObject.SetActive(true);
		LoadGame();
	}
	
	public void LoadGame() {
		Application.LoadLevel("Perfectionist");
	}
}