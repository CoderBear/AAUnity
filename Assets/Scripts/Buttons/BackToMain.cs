using UnityEngine;
using System.Collections;
using PlayHaven;

public class BackToMain : MonoBehaviour
{

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
            }

            if (this.gameObject.tag != "Game Pause")
            {
                if (Application.loadedLevel == 3 || Application.loadedLevel == 4)
                    requester.Request();
                Application.LoadLevel("AAMainMenu");

            }
        }
    }

    void OnClick()
    {
        if (this.gameObject.tag == "Store")
            script.CloseStore();

        if (this.gameObject.tag == "Game End")
        {
            requester.Request();
        }

        if (Application.loadedLevel == 3 || Application.loadedLevel == 4)
            requester.Request();

        Application.LoadLevel("AAMainMenu");
    }
}