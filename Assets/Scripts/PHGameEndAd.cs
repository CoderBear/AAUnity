using UnityEngine;
using PlayHaven;
using System.Collections;

public class PHGameEndAd : MonoBehaviour
{
    public PlayHavenContentRequester requester;

    void Awake()
    {
        PlayHavenManager.instance.ContentPreloadRequest(requester.placement);
    }

    void Start() {

        //Debug.Log("Last Level Loaded is " + GoogleAnalyticsHelper.lastLevelLoaded);
        //Debug.Log("(GoogleAnalyticsHelper.lastLevelLoaded == Fast Apples || GoogleAnalyticsHelper.lastLevelLoaded == Perfectionist && (Application.loadedLevelName == AAMainMenu) is " + (GoogleAnalyticsHelper.lastLevelLoaded == "Fast Apples" || GoogleAnalyticsHelper.lastLevelLoaded == "Perfectionist" && (Application.loadedLevelName == "AAMainMenu")));
        //if (GoogleAnalyticsHelper.lastLevelLoaded == "Fast Apples" || GoogleAnalyticsHelper.lastLevelLoaded == "Perfectionist" && (Application.loadedLevelName == "AAMainMenu"))
        //{
        //    Debug.Log("Now requesting Ad from PlayHaven");
        //    requester.Request();
        //}

        //GoogleAnalyticsHelper.lastLevelLoaded = Application.loadedLevelName;
        //Debug.Log("Last Level Loaded is now " + GoogleAnalyticsHelper.lastLevelLoaded);
    }

    public void DisplayAd()
    {
        requester.Request();
    }

}