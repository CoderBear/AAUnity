using UnityEngine;
using System.Collections;
using PlayHaven;

public class CBbutton : MonoBehaviour {

    public PlayHavenContentRequester requester;

    void Awake()
    {
        PlayHavenManager.instance.ContentPreloadRequest(requester.placement);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    requester.
        //}
	}

    void OnClick()
    {
        PlayHavenManager.instance.ContentRequest(requester.placement);
    }
}