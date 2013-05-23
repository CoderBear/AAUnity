using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker ; 
using System.Collections.Generic ; 
using RegEx = System.Text.RegularExpressions  ; 
using EleckTek ; 
using EleckTek.PauseTypes ; 



public class PlayMakerFsmPause : MonoBehaviour {
	
	public bool affectsThisGameObjectOnly ; 
	
	// Use this for initialization
	void Start () {
		// ProcessPauseExceptions() ; 
		MakePlayMakerReady() ; 
	}
	
	public void MakePlayMakerReady()
	{
				
		PauseController[] pause_controllers ; 
		
		if( affectsThisGameObjectOnly )
		{
			pause_controllers = gameObject.GetComponents< PauseController >() ; 
		}
		else
		{
			pause_controllers = (PauseController[])GameObject.FindObjectsOfType( typeof( PauseController ) ) ; 
		}
		
		foreach( PauseController pause_controller in pause_controllers )
		{
			pause_controller.InsertPauseInterpreterSuccessful( typeof( PlayMakerFSM ), CreatePlayMakerFsm ) ; 
		}
	}
	
	public class PlayMakerInterpreter : IPauseProtocolInterpreter 
	{
		PlayMakerFSM myPlayMakerFsm ; 
		bool playMakerDoesReset ; 
		string myName ; 
		
		public PlayMakerInterpreter( PlayMakerFSM playMaker )
		{
			if( playMaker )
			{
				myPlayMakerFsm = playMaker ; 
				myName = playMaker.gameObject.name + " " + typeof( ParticleEmitter ).ToString() ; 
			}
			else
			{
				myPlayMakerFsm = null ; 
				myName = null ; 
				Debug.LogWarning( "PlayMakerInterpreter, PlayMakerFSM not found " ) ; 
			}
		}
		
		public void SendMessage (string message, PauseMessageParameter parameter, SendMessageOptions options)
		{
			
		}
		
		public bool IsValid ()
		{
			if( !myPlayMakerFsm )
			{
				Debug.LogWarning( GetName() + " PlayMakerComponent Missing" ) ; 
				return false ;
			}
			
			return true ; 
		}
		
		public string GetName ()
		{
			return myName ;
		}
		
		public void Unpause ()
		{
			myPlayMakerFsm.enabled = true ; 
			myPlayMakerFsm.Fsm.RestartOnEnable = playMakerDoesReset ; 
		}
		
		public void Pause ()
		{
			playMakerDoesReset = myPlayMakerFsm.Fsm.RestartOnEnable ; 
			myPlayMakerFsm.Fsm.RestartOnEnable = false ; 
			myPlayMakerFsm.enabled = false ; 
		}
		
		public bool ShouldPause ()
		{
			return myPlayMakerFsm.enabled ; 
		}
		

	}
	
	static IPauseProtocolInterpreter CreatePlayMakerFsm( Component component )
	{
		return new PlayMakerInterpreter( (PlayMakerFSM) component ) ; 
	}
//	
//	/// <summary>
//	/// Changes every PlayMakerFSM to be "pause" ready in the current scene.  
//	/// </summary>
//	void ProcessPauseExceptions()
//	{
//		List< PlayMakerFSM > fsms = new List<PlayMakerFSM>( ( PlayMakerFSM[] )GameObject.FindObjectsOfType( typeof( PlayMakerFSM ) ) ) ; 
//		foreach( PlayMakerFSM fsm in fsms )
//		{
//			bool cont = false ; 	
//
//			if( fsm.Fsm.RestartOnEnable == false )
//			{
//				continue ;
//			}
//			
//			foreach( string sample_name in gameObjectNameExpressions )
//			{
//				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( sample_name , System.Text.RegularExpressions.RegexOptions.IgnoreCase) ; 
//	
//				RegEx.Match match = regex.Match( fsm.gameObject.name ) ; 
//				if( match.Success )
//				{
//					cont = true ; 
//					break ; 
//				}
//			}
//			if( cont == true )
//			{
//				continue ; 	
//			}
//			
//			foreach( string sample_name in fsmNameExpressions )
//			{
//				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( sample_name , System.Text.RegularExpressions.RegexOptions.IgnoreCase) ; 
//	
//				RegEx.Match match = regex.Match( fsm.FsmName ) ; 
//				if( match.Success )
//				{
//					cont = true ; 
//					break ; 
//				}
//			}
//			if( cont == true )
//			{
//				continue ; 
//			}
//			
//			foreach( string sample_name in stateNameExpressions )
//			{
//				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( sample_name , System.Text.RegularExpressions.RegexOptions.IgnoreCase) ; 
//				foreach( FsmState state in fsm.FsmStates )
//				{
//					RegEx.Match match = regex.Match( state.Name ) ; 
//					if( match.Success )
//					{
//						cont = true ; 
//						break ; 
//					}
//				}
//			}
//			if( cont == true )
//			{
//				continue ; 	
//			}
//			
//			foreach( string sample_name in localTransitionNameExpressions )
//			{
//				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( sample_name , System.Text.RegularExpressions.RegexOptions.IgnoreCase) ; 
//				foreach( FsmEvent eve in fsm.FsmEvents )
//				{
//					RegEx.Match match = regex.Match( eve.Name ) ; 
//					if( match.Success )
//					{
//						cont = true ; 
//						break ; 
//					}
//				}
//			}
//			if( cont == true )
//			{
//				continue ; 	
//			}
//			
//			
//			foreach( string sample_name in globalTransitionNameExpressions )
//			{
//				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( sample_name , System.Text.RegularExpressions.RegexOptions.IgnoreCase) ; 
//				foreach( FsmTransition transition in fsm.FsmGlobalTransitions )
//				{
//					RegEx.Match match = regex.Match( transition.EventName ) ; 
//					if( match.Success )
//					{
//						cont = true ; 
//						break ; 
//					}
//				}
//			}
//			if( cont == true )
//			{
//				continue ; 	
//			}
//			
//			fsm.Fsm.RestartOnEnable = false ; 
//		}	
//	}
}
	
	
	
