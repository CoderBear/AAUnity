using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class EnergyButton : MonoBehaviour
{
	
	public bool pressed = false;
	public int balance = 0;
	string itemId;
	public tk2dTextMesh textMesh;
	public AchievementTracker tracker;
	public AppleCollider colliderScript;
	public TimerCountdown timerScript;
	
	public tk2dSprite icon;
	
	bool cooldownActive = false;
		
	// Use this for initialization
	void Start ()
	{
		itemId = AndysApplesAssets.ENERGY_POTION_GOOD.ItemId;
		balance = StoreInventory.GetItemBalance (itemId);
		
		Debug.Log ("Energy-Powerup Balance at Fast Apples Game Start: " + balance);
		
		textMesh.text = balance.ToString ();
		textMesh.Commit ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnClick ()
	{
//		pressed = true;
		
		if ((balance > 0) && !cooldownActive) {
			switch (Application.loadedLevel) {
			case 3: // Fast Apples
				if (timerScript.countDownSeconds > 5) {
					clickedFA();
				}
				break;
			case 4: // Perfectionist
				if (colliderScript.lifeCounter < 9) {
					clickedPM();
				}
				break;
			}
		}
		
	}
	
	public void clickedFA ()
	{
		tracker.AddProgressToAchievement ("Energy Boost", 1.0f);
		StoreInventory.TakeItem (itemId, 1);
		
		balance = StoreInventory.GetItemBalance (itemId);
		textMesh.text = balance.ToString ();
		textMesh.Commit ();
		
		icon.color = Color.gray;
		cooldownActive = true;
		
		timerScript.countDownSeconds += 10;
		timerScript.DisplayTimer();
		
		Invoke("ActivateCooldown", 10); // cooldown lasts 10 secs
	}
	
	public void clickedPM ()
	{
		tracker.AddProgressToAchievement ("Energy Boost", 1.0f);
		StoreInventory.TakeItem (itemId, 1);

		balance = StoreInventory.GetItemBalance (itemId);
		textMesh.text = balance.ToString ();
		textMesh.Commit ();
		
		icon.color = Color.gray;
		cooldownActive = true;
		
		colliderScript.lifeCounter++;
		colliderScript.DisplayLives();
		
		Invoke("ActivateCooldown", 10); // cooldown lasts 10 secs
	}
	
	private void ActivateCooldown() {
		icon.color = Color.white;
		cooldownActive = false;
	}
}