using UnityEngine;
using HutongGames.PlayMaker;
using EleckTek ; 

[ActionCategory(ActionCategory.Time)]
[Tooltip("Easily suspend or resume groups of objects using PauseController")]
public class PauseControllerActivator : FsmStateAction
{
	
	[UIHint( UIHint.Description ) ] 
	public string pauseControllerDescriptionName ; 
	
		
	[ UIHint( UIHint.Comment ) ] 
	public string pauseControllerComment; 
	
	
	[RequiredField]
	[Tooltip( "Drop a PauseController over me" ) ] 
	public EleckTek.PauseController pause ; 

	[UIHint(UIHint.FsmBool)]
	public FsmBool activatePause ; 
	
	[UIHint(UIHint.FsmBool)]
	public FsmBool runEveryFrame ; 
		
	public override void Reset()
	{
		if( Owner )
		{
			pause = this.Owner.GetComponent< PauseController >() ; 
		}
	}
	
	public void SetPauseActivation()
	{
		if( pause )
		{
			pause.activatePause = activatePause.Value ; 
		}
	}
	
	
	// Code that runs on entering the state.
	public override void OnEnter()
	{
		if( !runEveryFrame.Value )
		{
			SetPauseActivation() ; 
			Finish();
		}
	}

	
	public override void OnUpdate ()
	{
		if( runEveryFrame.Value )
		{
			SetPauseActivation() ; 
		}
		else
		{
			Finish() ; 
		}
	}

	public override string ErrorCheck ()
	{
		if( pause == null && Owner )
		{
			pause = Owner.GetComponent< PauseController >() ; 
		}
		
		if( pause == null )
		{
			return "PauseController not defined" ; 
		}
		
		if( pauseControllerDescriptionName != "Name: " + pause.pauseName )
		{
			pauseControllerDescriptionName = "Name: " + pause.pauseName ;  
		}
		
		return null ; 
	}
}
