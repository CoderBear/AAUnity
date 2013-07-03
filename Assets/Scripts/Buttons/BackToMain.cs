using UnityEngine;
using System.Collections;
using PlayHaven;

public class BackToMain : MonoBehaviour {
	
	public Store script;
    public PlayHavenContentRequester requester;

    void Awake()
    {
        PlayHavenManager.instance.ContentPreloadRequest(requester.placement);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.gameObject.tag == "Store")
                script.CloseStore();


            if (this.gameObject.tag == "Game End")
            {
                requester.Request();
                GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
            }

            Application.LoadLevel("AAMainMenu");
        }
    }
	
	void OnClick() {
		if(this.gameObject.tag == "Store")
			script.CloseStore();

        if (this.gameObject.tag == "Game End")
        {
            requester.Request();
            GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
        }

		Application.LoadLevel("AAMainMenu");
	}
}