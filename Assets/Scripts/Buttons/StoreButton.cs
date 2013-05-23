using UnityEngine;
using System.Collections;

public class StoreButton : MonoBehaviour {
	
	public bool storeActive = false;
	
	void OnClick() {
		Debug.Log("Store Button Pressed");
		
		storeActive = !storeActive;
		
		Application.LoadLevel("AAStore");
	}
}