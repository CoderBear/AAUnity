using UnityEngine;
using System.Collections;

public class CBbutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChartBoostAndroid.onBackPressed();
        }
	}

    void OnClick()
    {
        ChartBoostAndroid.showMoreApps();
    }
}