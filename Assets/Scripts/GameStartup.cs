using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class GameStartup : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		StoreController.Initialize (new AndysApplesAssets ());

        // Acquire default player skin "Andy" and equip him for use in game
        // This is is only run on the first startup of the game or if data is deleted.
        if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 0)
        {
            StoreInventory.GiveItem(AndysApplesAssets.ANDY_GOOD.ItemId, 1);
            StoreInventory.EquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}