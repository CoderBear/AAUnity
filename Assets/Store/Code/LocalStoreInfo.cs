using System;
using System.Collections.Generic;
using UnityEngine;
using com.soomla.unity;

namespace com.soomla.unity.example {
	/** Currency and Goods balances ! **/
	/** we keep these balances so we won't have to make too many calls to the native (Java/iOS) code **/
	public static class LocalStoreInfo {

        private const string TAG = "AAUNITY/SOOMLA";

		// In this example we have a single currency so we can just save its balance. 
		// If have more than one currency than you'll have to save a dictionary here.
		public static int CurrencyBalance = 0;
		
        //public static Dictionary<string, int> GoodsBalancesPowerups = new Dictionary<string, int> ();
        //public static Dictionary<string, int> GoodsBalancesUnlockables = new Dictionary<string, int> ();
        //public static Dictionary<string, int> GoodsBalancesUpgrades = new Dictionary<string, int> ();
		public static Dictionary<string, int> GoodsBalances = new Dictionary<string, int>();
		public static VirtualCurrency VirtualCurrency;
        //public static List<VirtualGood> VirtualGoodPowerups = new List<VirtualGood>();
        //public static List<VirtualGood> VirtualGoodUnlockables = new List<VirtualGood>();
        //public static List<VirtualGood> VirtualGoodUpgrades = new List<VirtualGood>();
		public static List<VirtualGood> VirtualGoods = new List<VirtualGood>();
		public static List<VirtualCurrencyPack> VirtualCurrencyPacks = new List<VirtualCurrencyPack>();
		
		public static void UpdateBalances ()
		{
			CurrencyBalance = StoreInventory.GetItemBalance(VirtualCurrency.ItemId);
			foreach (VirtualGood vg in VirtualGoods) {
				GoodsBalances[vg.ItemId] = StoreInventory.GetItemBalance(vg.ItemId);
			}
//			foreach (VirtualGood vg in VirtualGoodPowerups) {
//				GoodsBalancesPowerups [vg.ItemId] = StoreInventory.GetItemBalance (vg.ItemId);
//			}
//			foreach (VirtualGood vg in VirtualGoodUnlockables) {
//				GoodsBalancesUnlockables [vg.ItemId] = StoreInventory.GetItemBalance (vg.ItemId);
//			}
//			foreach (VirtualGood vg in VirtualGoodUpgrades) {
//				GoodsBalancesUpgrades [vg.ItemId] = StoreInventory.GetItemBalance (vg.ItemId);
//			}
		}

		public static void Init ()
		{
//			List<VirtualCategory> category = StoreInfo.GetVirtualCategories();
			AndyUtils.LogDebug(TAG, "getting Virtual Goods");
			VirtualGoods = StoreInfo.GetVirtualGoods();
//			List<VirtualGood> good = StoreInfo.GetVirtualGoods ();
			AndyUtils.LogDebug(TAG, "getting Virtual Currency");
			VirtualCurrency = StoreInfo.GetVirtualCurrencies()[0];
			AndyUtils.LogDebug(TAG, "Got Virtual Currency");
			
			AndyUtils.LogDebug(TAG, "Seperating Virtual Goods by Category");
			
//			foreach (VirtualGood vg in good) {
//				Debug.Log ("AAUNITY/SOOMLA - VG name: " + vg.Name + ", id: " + vg.ItemId + ", category: " + StoreInfo.GetCategoryForVirtualGood(vg.ItemId).Name);
//				if(StoreInfo.GetCategoryForVirtualGood(vg.ItemId).Name == "Powerup") {
//					VirtualGoodPowerups.Add (vg);
//				}
//				if(StoreInfo.GetCategoryForVirtualGood(vg.ItemId).Name == "Upograde") {
//					VirtualGoodUpgrades.Add (vg);
//				}
//				if(StoreInfo.GetCategoryForVirtualGood(vg.ItemId).Name == "Unlockable") {
//					VirtualGoodUnlockables.Add(vg);
//				}
//			}
			AndyUtils.LogDebug(TAG, "Finished Seperating");
			
			VirtualCurrencyPacks = StoreInfo.GetVirtualCurrencyPacks ();
			UpdateBalances ();
		}
	}
}