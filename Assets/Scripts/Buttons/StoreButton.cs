using UnityEngine;
using System.Collections;

public class StoreButton : MonoBehaviour {
	
	public bool storeActive = false;
	
	void OnClick() {
		Debug.Log("Store Button Pressed");
		
		storeActive = !storeActive;
        MainMenuAudio.isObjectActive = storeActive;
		
		Application.LoadLevel("AAStore");
	}
}