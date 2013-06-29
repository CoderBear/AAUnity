using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class GameStartup : MonoBehaviour
{
    public static string lastLevelLoaded;

	void Awake()
    {
        ChartBoostAndroid.init("51c797cb16ba47fe02000009", "a58d9cbbb5a4db2d7c62eb7c146b75d7c070691e", true);
    }


	// Use this for initialization
	void Start ()
	{
        //ChartBoostAndroid.onStart();
        //ChartBoostAndroid.showInterstitial(null);
        GoogleAnalyticsHelper.Init();
		StoreController.Initialize (new AndysApplesAssets ());

        // Acquire default player skin "Andy" and equip him for use in game.
        // This is is only run on the first startup of the game or if data is deleted.
        if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 0)
        {
            StoreInventory.GiveItem(AndysApplesAssets.ANDY_GOOD.ItemId, 1);
            StoreInventory.EquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
        }

        // Acquire default background and equip it for use in game.
        // This is is only run on the first startup of the game or if data is deleted.
        if (StoreInventory.GetItemBalance(AndysApplesAssets.DEFAULT_BG.ItemId) == 0)
        {
            StoreInventory.GiveItem(AndysApplesAssets.DEFAULT_BG.ItemId, 1);
            StoreInventory.EquipVirtualGood(AndysApplesAssets.DEFAULT_BG.ItemId);
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}