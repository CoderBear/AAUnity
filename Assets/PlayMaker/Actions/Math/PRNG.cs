using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory(ActionCategory.Math)]
[Tooltip("Uses the MersenneTwister to create better random numbers")]
public class PRNG : FsmStateAction
{
	[RequiredField]
	public FsmInt max;
	[RequiredField]
	[UIHint(UIHint.Variable)]
	public FsmInt storeResult;
	MersenneTwister random;

	// Code that runs on entering the state.
	public override void OnEnter()
	{
		MersenneTwister random = new MersenneTwister();
		storeResult.Value = random.Next(max.Value);
		
		Finish();
	}

	// Code that runs every frame.
	public override void OnUpdate()
	{
		
	}
	
}