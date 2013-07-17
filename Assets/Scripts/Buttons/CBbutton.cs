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

    void OnClick()
    {
        PlayHavenManager.instance.ContentRequest(requester.placement);
    }
}