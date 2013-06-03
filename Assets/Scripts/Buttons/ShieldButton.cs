using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class ShieldButton : MonoBehaviour
{
	
	public int balance = 0;
	string itemId;
	public tk2dTextMesh textMesh;
	public AchievementTracker tracker;
	public tk2dSprite icon;
	
	public Spawner spawnScript;
	
	bool cooldownActive = false;
	
	// Use this for initialization
	void Start ()
	{	
		itemId = AndysApplesAssets.SHIELD_POTION_GOOD.ItemId;
		balance = StoreInventory.GetItemBalance (itemId);
        //balance = 1;

		Debug.Log ("Shield-Powerup Balance at Fast Apples Game Start: " + balance);

        textMesh.text = balance.ToString ();
		textMesh.Commit ();
	}

	void OnClick ()
	{
		if ((balance > 0) && !cooldownActive)
			clickedFA ();
	}

	public void clickedFA ()
	{
        tracker.AddProgressToAchievement("Apple Sauce", 1.0f);
        StoreInventory.TakeItem(itemId, 1);
        balance--;

        textMesh.text = balance.ToString ();
		textMesh.Commit ();
		
		icon.color = Color.gray;
		cooldownActive = !cooldownActive;
		
		Invoke("ResetIcon", 5);  // cooldown in 5 seconds.
		ActivateShield();
	}
	
	private void ActivateShield() {
		spawnScript.removeRotten();
	}

	private void ResetIcon() {
		cooldownActive = !cooldownActive;
		icon.color = Color.white;
	}
	
}