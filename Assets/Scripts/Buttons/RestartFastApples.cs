using UnityEngine;
using System.Collections;

public class RestartFastApples : MonoBehaviour
{

    void OnClick()
    {
        switch (Application.loadedLevel)
        {
            case 3: // Fast Apples
                GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
                GoogleAnalyticsHelper.trackGamePlayed(Application.loadedLevelName);
                Application.LoadLevel("Fast Apples");
                break;
            case 4: // Perfectionist
                GoogleAnalyticsHelper.trackGameFinished(Application.loadedLevelName);
                GoogleAnalyticsHelper.trackGamePlayed(Application.loadedLevelName);
                Application.LoadLevel("Perfectionist");
                break;
            default:
                break;
        }
    }
}