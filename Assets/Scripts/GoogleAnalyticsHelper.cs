using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class GoogleAnalyticsHelper : MonoBehaviour
{
    public static GoogleAnalyticsHelper instance;

    public static string lastLevelLoaded { get; set; }

    static AndroidJavaClass analyticsPlugin;
    //static AndroidJavaClass unityPlayer;
    //static AndroidJavaObject currentActivity;

    public void Awake()
    {
        GoogleAnalyticsHelper.instance = this;
    }

    public static GoogleAnalyticsHelper Instance
    {
        get
        {
            return instance;
        }
    }



    /// Init class with given site id and domain name
    public static void Init()
    {
        analyticsPlugin = new AndroidJavaClass("com.unityrealm.uranalytics.AnalyticsActivity");
        //unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        //currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    }

    public static void trackGamePlayed(string mode_name)
    {
        analyticsPlugin.Call("gamesStarted", mode_name);
    }

    public static void trackGameFinished(string mode_name)
    {
        analyticsPlugin.Call("gamesFinished", mode_name);
    }

    public static void trackGameLength(string mode_name, long time)
    {
        analyticsPlugin.Call("timePlayed", mode_name, time);
    }
}