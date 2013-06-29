using UnityEngine;
using PlayHaven;
using System.Collections;

public class PHGameEndAd : MonoBehaviour
{
    public PlayHavenContentRequester requester;

    void Start() {
        if (GoogleAnalyticsHelper.lastLevelLoaded == "Fast Apples" || GoogleAnalyticsHelper.lastLevelLoaded == "Perfectionist")
        {
            requester.Request();
        }

        GoogleAnalyticsHelper.lastLevelLoaded = Application.loadedLevelName;
    }
}