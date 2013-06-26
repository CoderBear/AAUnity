using UnityEngine;
using System.Collections.Generic;
using Prime31;


public class ChartBoostUIManager : MonoBehaviourGUI
{
#if UNITY_ANDROID
	void OnGUI()
	{
		beginColumn();

		if( GUILayout.Button( "Init" ) )
		{
			ChartBoostAndroid.init( "YOUR_APP_ID", "YOUR_APP_SIGNATURE" );
			ChartBoostAndroid.onStart();
		}

		
		if( GUILayout.Button( "Cache Interstitial" ) )
		{
			ChartBoostAndroid.cacheInterstitial( null );
		}
		
		
		if( GUILayout.Button( "Check for Cached Interstitial" ) )
		{
			Debug.Log( "has cached interstitial: " + ChartBoostAndroid.hasCachedInterstitial( null ) );
		}
		
	
		if( GUILayout.Button( "Show Interstitial" ) )
		{
			ChartBoostAndroid.showInterstitial( null );
		}

		
		if( GUILayout.Button( "Cache More Apps" ) )
		{
			ChartBoostAndroid.cacheMoreApps();
		}
		
		
		if( GUILayout.Button( "Has Cached More Apps" ) )
		{
			Debug.Log( "has cached more apps: " + ChartBoostAndroid.hasCachedMoreApps() );
		}
		
	
		if( GUILayout.Button( "Show More Apps" ) )
		{
			ChartBoostAndroid.showMoreApps();
		}


		if( GUILayout.Button( "Track Event" ) )
		{
			ChartBoostAndroid.trackEvent( "event-did-something", 0, null );
		}

		endColumn();
	}
#endif
}
