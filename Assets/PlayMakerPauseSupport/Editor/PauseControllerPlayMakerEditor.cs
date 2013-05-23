using UnityEngine;
using EleckTek ; 
using UnityEditor ; 
using System.Collections;

public class PauseControllerPlayMakerEditor : MonoBehaviour {

	[MenuItem ("GameObject/Pause Controller/Create PlayMaker Pause Controller")]
	static void CreatePlayMakerPauseControllerGameObject() {
		GameObject gobj = new GameObject("Pause Controller", typeof(PauseController), typeof( PlayMakerFsmPause ) ) ; 
		
	}
	
	[MenuItem ("Component/Pause Controller/PlayMakerFSM Pause")]
	static void AddFSMExceptionComponent() {
		foreach( UnityEngine.Object obj in Selection.objects )
		{
			GameObject gobj = ( GameObject )obj ; 
			if( gobj )
			{
				gobj.AddComponent< PlayMakerFsmPause >() ; 
			}
		}
	}

}
