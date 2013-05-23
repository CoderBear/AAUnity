using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class GameStartup : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		StoreController.Initialize (new AndysApplesAssets ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}