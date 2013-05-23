using UnityEngine;
using System.Collections;

public class MainMenuAudio : MonoBehaviour {

	private static MainMenuAudio instance;
	
	void Awake() {
		if(MainMenuAudio.instance == null) {
			MainMenuAudio.instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy (this);
		}
	}
	
	void OnApplicationQuit() {
		MainMenuAudio.instance = null;
	}
}