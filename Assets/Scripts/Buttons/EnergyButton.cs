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
        //balance = 1;
        //Debug.Log ("Energy-Powerup Balance at Fast Apples Game Start: " + balance);
		
		textMesh.text = balance.ToString ();
		textMesh.Commit ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnClick ()
	{
		if ((balance > 0) && !cooldownActive) {
			switch (Application.loadedLevel) {
			case 3: // Fast Apples
				if (timerScript.countDownSeconds > 5) {
                    pressed = !pressed;
					clickedFA();
				}
				break;
			case 4: // Perfectionist
				if (colliderScript.lifeCounter < 9) {
                    pressed = !pressed;
					clickedPM();
				}
				break;
			}
		}
		
	}
	
	public void clickedFA ()
	{
		tracker.AddProgressToAchievement ("Energy Boost", 1.0f);
        balance--;
        //balance = 1;

        icon.color = Color.gray;
        cooldownActive = !cooldownActive;

        timerScript.countDownSeconds += 5;

        Invoke("changedDisplayFA", 0.5f);
        Invoke("ActivateCooldown", 10); // cooldown lasts 10 secs
	}
	
	public void clickedPM ()
	{
		tracker.AddProgressToAchievement ("Energy Boost", 1.0f);
        balance--;

        icon.color = Color.gray;
		cooldownActive = true;

        colliderScript.lifeCounter++;

        Invoke("changedDisplayPM", 0.5f);
        Invoke("ActivateCooldown", 10); // cooldown lasts 10 secs
	}

    void changedDisplayFA()
    {
        textMesh.text = balance.ToString();
        textMesh.Commit();

        //timerScript.DisplayTimer();
        StoreInventory.TakeItem(itemId, 1);
    }

    void changedDisplayPM()
    {
        textMesh.text = balance.ToString();
        textMesh.Commit();

        colliderScript.DisplayLives();
        StoreInventory.TakeItem(itemId, 1);
    }
	
	private void ActivateCooldown() {
        icon.color = Color.white;
        pressed = !pressed;
		cooldownActive = !cooldownActive;
	}
}