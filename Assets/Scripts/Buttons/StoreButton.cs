using UnityEngine;
using System.Collections;
using PlayHaven;

public class StoreButton : MonoBehaviour {
	
	public bool storeActive = false;
    public PlayHavenContentRequester requester;
	
	void OnClick() {
		Debug.Log("Store Button Pressed");
		
		storeActive = !storeActive;
        MainMenuAudio.isObjectActive = storeActive;

        switch (Application.loadedLevel)
        {
            case 3:
                requester.Request();
                Application.LoadLevel("AAStore");
                break;
            case 4:
                requester.Request();
                Application.LoadLevel("AAStore");
                break;
            default :
                Application.LoadLevel("AAStore");
                break;
        }
	}
}