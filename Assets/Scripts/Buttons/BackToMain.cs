using UnityEngine;
using System.Collections;

public class BackToMain : MonoBehaviour {
	
	public Store script;
	
	void OnClick() {
		if(this.gameObject.tag == "Store")
			script.CloseStore();
		
		Application.LoadLevel("AAMainMenu");
	}
}