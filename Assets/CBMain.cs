using UnityEngine;
using System.Collections;

public class CBMain : MonoBehaviour {

    private static bool firstRun = true;

    void Awake()
    {
        if (firstRun)
        {
            firstRun = !firstRun;
            ChartBoostAndroid.showInterstitial(null);
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onApplicationQuit()
    {
        ChartBoostAndroid.onStop();
    }
}