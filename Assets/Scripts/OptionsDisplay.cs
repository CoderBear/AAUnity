using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class OptionsDisplay : MonoBehaviour {
	
	public UICheckbox upgradeOption1, upgradeOption2, upgradeOption3, upgradeOption4, upgradeOption5;
	
	// Use this for initialization
	void Start () {
		if(StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId) == 6)
			upgradeOption1.gameObject.SetActive(true);
		if(StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.SUPER_GOOD.ItemId) == 6)
			upgradeOption2.gameObject.SetActive(true);
		if(StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.DOUBLE_GOOD.ItemId) == 6)
			upgradeOption3.gameObject.SetActive(true);
		if(StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.REPELLENT_GOOD.ItemId) == 6)
			upgradeOption4.gameObject.SetActive(true);
		if(StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.LONGEVITY_GOOD.ItemId) == 6)
			upgradeOption5.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	}
}