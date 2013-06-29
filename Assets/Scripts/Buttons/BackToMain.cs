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

        if (this.gameObject.tag == "Game End")
        {
            GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
        }

        if (Application.loadedLevel == 3 || Application.loadedLevel == 4)
        {
            GoogleAnalyticsHelper.lastLevelLoaded = Application.loadedLevelName;
        }

		Application.LoadLevel("AAMainMenu");
	}
}