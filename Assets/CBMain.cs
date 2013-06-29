using UnityEngine;
using System.Collections;

public class CBMain : MonoBehaviour {

    private static bool firstRun = true;

	// Use this for initialization
	void Start () {
        if (firstRun)
        {
            firstRun = !firstRun;
            ChartBoostAndroid.onStart();
            ChartBoostAndroid.showInterstitial(null);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}