using UnityEngine;
using System.Collections;
using PlayHaven;

public class RestartFastApples : MonoBehaviour
{
    public PlayHavenContentRequester requester;

    void OnClick()
    {
        switch (Application.loadedLevel)
        {
            case 3: // Fast Apples
                requester.Request();
                GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
                GoogleAnalyticsHelper.trackGamePlayed(Application.loadedLevelName);
                Application.LoadLevel("Fast Apples");
                break;
            case 4: // Perfectionist
                requester.Request();
                GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
                GoogleAnalyticsHelper.trackGamePlayed(Application.loadedLevelName);
                Application.LoadLevel("Perfectionist");
                break;
            default:
                break;
        }
    }
}