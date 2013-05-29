using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class playerAnimController : MonoBehaviour {
	tk2dSprite basket;
	tk2dAnimatedSprite anim;
	
	public TimerCountdown script;
	
	public float speed;
	public float BOUNDS_LEFT = 10.0f;
	public float BOUNDS_RIGHT = 10.0f;
	
	public bool flipped, hasflipped;
	
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
		anim = GetComponent<tk2dAnimatedSprite>();
		flipped = hasflipped = false;

        // set character skin
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
        {
            anim.Play("Andy");
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
        {
            anim.Play("Kelly");
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
        {
            anim.Play("Ninja");
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
        {
            anim.Play("Pig");
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
        {
            anim.Play("Pirate");
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
        {
            anim.Play("Wizard");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (script.timerActive) {
//			Debug.Log("Acceleration Normalized <x,y,z>: " + Input.acceleration.normalized.ToString());
			
			if(Input.acceleration.normalized.x > 0) {
				flipped = true;
			} else {
				flipped = false;
			}
			
			Vector3 dir = Vector3.zero;
			
			dir.x = Input.acceleration.x;
			
			// clamp acceleration vector to the unit sphere
			if (dir.sqrMagnitude > 1)
				dir.Normalize();
			
			// Make it move X meters per second instead of X meters per frame... where X == speed
			dir *= Time.deltaTime;
			
			anim.transform.Translate(dir * speed);
			
			// Restrict movement between two values
			if (transform.position.x <= BOUNDS_LEFT || transform.position.x >= BOUNDS_RIGHT) {
				float xPos = Mathf.Clamp(transform.position.x, BOUNDS_LEFT, BOUNDS_RIGHT);
				anim.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
			}
			
			if(!hasflipped && flipped){
				anim.FlipX();
				hasflipped = !hasflipped;
			} else if(hasflipped && !flipped) {
				anim.FlipX();
				hasflipped = !hasflipped;
			}
		}
	}
}