using UnityEngine;
using System.Collections;

public class BackToMain : MonoBehaviour {
	
	public Store script;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.gameObject.tag == "Store")
                script.CloseStore();

            Application.LoadLevel("AAMainMenu");
        }
    }
	
	void OnClick() {
		if(this.gameObject.tag == "Store")
			script.CloseStore();
		
		Application.LoadLevel("AAMainMenu");
	}
}