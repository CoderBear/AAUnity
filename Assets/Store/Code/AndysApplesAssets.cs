using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.soomla.unity.example
{
	public class AndysApplesAssets : IStoreAssets
	{
		/** Static Final members **/
		public static string COMBO_CURRENCY_ITEM_ID = "currency_combo";
		public static string COMBO2K_PACK_PRODUCT_ID = "android.test.purchased";
		public static string COMBO5K_PACK_PRODUCT_ID = "android.test.purchased";
        public static string COMBO15K_PACK_PRODUCT_ID = "android.test.purchased";

		/** Virtual Currencies **/
		public static VirtualCurrency COMBO_CURRENCY = new VirtualCurrency ("Combos", "", COMBO_CURRENCY_ITEM_ID);
    
		/** Virtual Goods **/
		//Upgrades - Frenzy
		public static VirtualGood FRENZY_GOOD = new SingleUseVG (
    		"Frenzy", // name
    		"Increase effect length", // description
			"frenzy", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 0));
		public static VirtualGood FRENZY_UPGRADE1 = new UpgradeVG ("frenzy", "frenzy2", "", FRENZY_GOOD.Name, FRENZY_GOOD.Description, "frenzy1", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood FRENZY_UPGRADE2 = new UpgradeVG ("frenzy", "frenzy3", "frenzy1", FRENZY_GOOD.Name, FRENZY_GOOD.Description, "frenzy2", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 250));
		public static VirtualGood FRENZY_UPGRADE3 = new UpgradeVG ("frenzy", "frenzy4", "frenzy2", FRENZY_GOOD.Name, FRENZY_GOOD.Description, "frenzy3", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 500));
		public static VirtualGood FRENZY_UPGRADE4 = new UpgradeVG ("frenzy", "frenzy5", "frenzy3", FRENZY_GOOD.Name, FRENZY_GOOD.Description, "frenzy4", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1000));
		public static VirtualGood FRENZY_UPGRADE5 = new UpgradeVG ("frenzy", "frenzy6", "frenzy4", FRENZY_GOOD.Name, FRENZY_GOOD.Description, "frenzy5", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood FRENZY_UPGRADE6 = new UpgradeVG ("frenzy", "", "frenzy5", FRENZY_GOOD.Name, FRENZY_GOOD.Description, "frenzy6", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1500));
		
		//Upgrades - Super Frenzy
		public static VirtualGood SUPER_GOOD = new SingleUseVG (
    		"Super Frenzy", // name
    		"Increase effect length", // description
			"super", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 0));
		public static VirtualGood SUPER_UPGRADE1 = new UpgradeVG ("super", "super2", "", SUPER_GOOD.Name, SUPER_GOOD.Description, "super1", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood SUPER_UPGRADE2 = new UpgradeVG ("super", "super3", "super1", SUPER_GOOD.Name, SUPER_GOOD.Description, "super2", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 250));
		public static VirtualGood SUPER_UPGRADE3 = new UpgradeVG ("super", "super4", "super2", SUPER_GOOD.Name, SUPER_GOOD.Description, "super3", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 500));
		public static VirtualGood SUPER_UPGRADE4 = new UpgradeVG ("super", "super5", "super3", SUPER_GOOD.Name, SUPER_GOOD.Description, "super4", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1000));
		public static VirtualGood SUPER_UPGRADE5 = new UpgradeVG ("super", "super6", "super4", SUPER_GOOD.Name, SUPER_GOOD.Description, "super5", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood SUPER_UPGRADE6 = new UpgradeVG ("super", "", "super5", SUPER_GOOD.Name, SUPER_GOOD.Description, "super6", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1500));
    
		// Upgrades - Double
		public static VirtualGood DOUBLE_GOOD = new SingleUseVG (
    		"Double", // name
    		"Increase effect length", // description
			"double", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 0));
		public static VirtualGood DOUBLE_UPGRADE1 = new UpgradeVG ("double", "double2", "", DOUBLE_GOOD.Name, DOUBLE_GOOD.Description, "double1", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood DOUBLE_UPGRADE2 = new UpgradeVG ("double", "double3", "double1", DOUBLE_GOOD.Name, DOUBLE_GOOD.Description, "double2", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 250));
		public static VirtualGood DOUBLE_UPGRADE3 = new UpgradeVG ("double", "double4", "double2", DOUBLE_GOOD.Name, DOUBLE_GOOD.Description, "double3", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 500));
		public static VirtualGood DOUBLE_UPGRADE4 = new UpgradeVG ("double", "double5", "double3", DOUBLE_GOOD.Name, DOUBLE_GOOD.Description, "double4", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1000));
		public static VirtualGood DOUBLE_UPGRADE5 = new UpgradeVG ("double", "double6", "double4", DOUBLE_GOOD.Name, DOUBLE_GOOD.Description, "double5", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood DOUBLE_UPGRADE6 = new UpgradeVG ("double", "", "double5", DOUBLE_GOOD.Name, DOUBLE_GOOD.Description, "double6", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1500));
    
		// Upgrades - Repellent
		public static VirtualGood REPELLENT_GOOD = new SingleUseVG (
    		"Repellent", // name
    		"Increase effect length", // description
			"repellent", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood REPELLENT_UPGRADE1 = new UpgradeVG ("repellent", "repellent2", "", REPELLENT_GOOD.Name, REPELLENT_GOOD.Description, "repellent1", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood REPELLENT_UPGRADE2 = new UpgradeVG ("repellent", "repellent3", "repellent1", REPELLENT_GOOD.Name, REPELLENT_GOOD.Description, "repellent2", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 250));
		public static VirtualGood REPELLENT_UPGRADE3 = new UpgradeVG ("repellent", "repellent4", "repellent2", REPELLENT_GOOD.Name, REPELLENT_GOOD.Description, "repellent3", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 500));
		public static VirtualGood REPELLENT_UPGRADE4 = new UpgradeVG ("repellent", "repellent5", "repellent3", REPELLENT_GOOD.Name, REPELLENT_GOOD.Description, "repellent4", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1000));
		public static VirtualGood REPELLENT_UPGRADE5 = new UpgradeVG ("repellent", "repellent6", "repellent4", REPELLENT_GOOD.Name, REPELLENT_GOOD.Description, "repellent5", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood REPELLENT_UPGRADE6 = new UpgradeVG ("repellent", "", "repellent5", REPELLENT_GOOD.Name, REPELLENT_GOOD.Description, "repellent6", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1500));
    
		// Upgrades - Longevity
		public static VirtualGood LONGEVITY_GOOD = new SingleUseVG (
    		"Longevity", // name
    		"Adds an additional 5 seconds to the timer in Fast Apples", // description
			"longevity", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 0));
		public static VirtualGood LONGEVITY_UPGRADE1 = new UpgradeVG ("longevity", "longevity2", "", LONGEVITY_GOOD.Name, LONGEVITY_GOOD.Description, "longevity1", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood LONGEVITY_UPGRADE2 = new UpgradeVG ("longevity", "longevity3", "longevity1", LONGEVITY_GOOD.Name, LONGEVITY_GOOD.Description, "longevity2", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 250));
		public static VirtualGood LONGEVITY_UPGRADE3 = new UpgradeVG ("longevity", "longevity4", "longevity2", LONGEVITY_GOOD.Name, LONGEVITY_GOOD.Description, "longevity3", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 500));
		public static VirtualGood LONGEVITY_UPGRADE4 = new UpgradeVG ("longevity", "longevity5", "longevity3", LONGEVITY_GOOD.Name, LONGEVITY_GOOD.Description, "longevity4", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1000));
		public static VirtualGood LONGEVITY_UPGRADE5 = new UpgradeVG ("longevity", "longevity6", "longevity4", LONGEVITY_GOOD.Name, LONGEVITY_GOOD.Description, "longevity5", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood LONGEVITY_UPGRADE6 = new UpgradeVG ("longevity", "", "longevity5", LONGEVITY_GOOD.Name, LONGEVITY_GOOD.Description, "longevity6", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1500));
      
		/*--- Consumable Items ---*/
		public static VirtualGood ENERGY_POTION_GOOD = new SingleUseVG (
    		"Energy Potion", // name
    		"This potion will add either 10 seconds to the game timer for Fast Apples or 1 extra life in Perfectionist", // description
			"ep_good", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 50));
		public static VirtualGood SHIELD_POTION_GOOD = new SingleUseVG (
    		"Shield Potion", // name
    		"The shield potion can be used in game to protect Andy from the falling Rotten Apples", // description
			"sp_good", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 150));
		public static VirtualGood SUPER_SEED_GOOD = new SingleUseVG (
    		"Super Seed", // name
    		"In fast apples the game score will remain but the game time will reset. In Perfectionist the score will remain but the life counter will reset and the game will continue. (This can only be used 1 time per game)", // description
			"s2_good", // item id
			new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 500));
    
		/*--- Unlockable Skins ---*/
		public static VirtualGood ANDY_GOOD = new EquippableVG (EquippableVG.EquippingModel.CATEGORY, "Andy", "Andy Player Skin", "andy_skin", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 0));
		public static VirtualGood KELLY_GOOD = new EquippableVG (EquippableVG.EquippingModel.CATEGORY, "Kelly", "Kelly Player Skin", "kelly_skin", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood NINJA_GOOD = new EquippableVG (EquippableVG.EquippingModel.CATEGORY, "Ninja", "Ninja Player Skin", "ninja_skin", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 1250));
		public static VirtualGood PIG_GOOD = new EquippableVG (EquippableVG.EquippingModel.CATEGORY, "Pig", "Pig Player Skin", "pig_skin", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 5000));
		public static VirtualGood PIRATE_GOOD = new EquippableVG (EquippableVG.EquippingModel.CATEGORY, "Pirate", "Pirate Player Skin", "pirate_skin", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 5000));
		public static VirtualGood WIZARD_GOOD = new EquippableVG (EquippableVG.EquippingModel.CATEGORY, "Wizard", "Wizard Player Skin", "wizard_skin", new PurchaseWithVirtualItem (COMBO_CURRENCY_ITEM_ID, 5000));

        /*--- Unlockable Backgrounds ---*/
        public static VirtualGood DEFAULT_BG = new EquippableVG(EquippableVG.EquippingModel.CATEGORY, "Default", "The initial starting background", "default_bg", new PurchaseWithVirtualItem(COMBO_CURRENCY_ITEM_ID, 0));
        public static VirtualGood CBLOSSOM_BG = new EquippableVG(EquippableVG.EquippingModel.CATEGORY, "Cherry Blossom", "Experience the Japanese concept of 'Mono No Aware' with this background.", "blossom_bg", new PurchaseWithVirtualItem(COMBO_CURRENCY_ITEM_ID, 5000));

		/** Virtual Categories **/
		public static VirtualCategory UNLOCKABLE_CATEGORY = new VirtualCategory ("Unlockable", new List<string>(new string[] {ANDY_GOOD.ItemId, KELLY_GOOD.ItemId, NINJA_GOOD.ItemId, PIG_GOOD.ItemId, PIRATE_GOOD.ItemId, WIZARD_GOOD.ItemId}));
        public static VirtualCategory BACKGROUND_CATEGORY = new VirtualCategory("Background", new List<string>(new string[] { DEFAULT_BG.ItemId, CBLOSSOM_BG.ItemId }));

		/** Virtual Currency Packs **/
		public static VirtualCurrencyPack COMBO2K_PACK = new VirtualCurrencyPack (
    		"2000 Combos", // name
    		"Test purchase of an item", // description
    		"combos_2000", // item id
			2000, // number of currencies in the pack
			COMBO_CURRENCY_ITEM_ID,
			new PurchaseWithMarket (COMBO2K_PACK_PRODUCT_ID, 0.99));
		public static VirtualCurrencyPack COMBO5K_PACK = new VirtualCurrencyPack (
    		"5000 Combos", // name
    		"Test purchase of an item", // description
    		"combos_5K", // item id
			5000, // number of currencies in the pack
			COMBO_CURRENCY_ITEM_ID,
            new PurchaseWithMarket(COMBO5K_PACK_PRODUCT_ID, 4.99));
        public static VirtualCurrencyPack COMBO15K_PACK = new VirtualCurrencyPack(
            "15,000 Combos", // name
            "Test purchase of an item", // description
            "combos_10K", // item id
            15000, // number of currencies in the pack
            COMBO_CURRENCY_ITEM_ID,
            new PurchaseWithMarket(COMBO15K_PACK_PRODUCT_ID, 2.99));
    
		public int GetVersion ()
		{
			return 0;
		}
    
		public VirtualCurrency[] GetCurrencies ()
		{
			return new VirtualCurrency[] { COMBO_CURRENCY };
		}
    
		public VirtualGood[] GetGoods ()
		{
			return new VirtualGood[] {
				SHIELD_POTION_GOOD, ENERGY_POTION_GOOD, SUPER_SEED_GOOD, // Powerups
				FRENZY_GOOD, SUPER_GOOD, DOUBLE_GOOD, REPELLENT_GOOD, LONGEVITY_GOOD, // Upgrades
				FRENZY_UPGRADE1, FRENZY_UPGRADE2, FRENZY_UPGRADE3, FRENZY_UPGRADE4,FRENZY_UPGRADE5,FRENZY_UPGRADE6,
				SUPER_UPGRADE1,SUPER_UPGRADE2,SUPER_UPGRADE3,SUPER_UPGRADE4,SUPER_UPGRADE5,SUPER_UPGRADE6,
				DOUBLE_UPGRADE1,DOUBLE_UPGRADE2,DOUBLE_UPGRADE3,DOUBLE_UPGRADE4,DOUBLE_UPGRADE5,DOUBLE_UPGRADE6,
				REPELLENT_UPGRADE1,REPELLENT_UPGRADE2,REPELLENT_UPGRADE3,REPELLENT_UPGRADE4,REPELLENT_UPGRADE5,REPELLENT_UPGRADE6,
				LONGEVITY_UPGRADE1,LONGEVITY_UPGRADE2,LONGEVITY_UPGRADE3,LONGEVITY_UPGRADE4,LONGEVITY_UPGRADE5,LONGEVITY_UPGRADE6,
				ANDY_GOOD, KELLY_GOOD, NINJA_GOOD, PIG_GOOD, PIRATE_GOOD, WIZARD_GOOD, // Unlockables - Skins
                DEFAULT_BG, CBLOSSOM_BG // Unlockables - Backgrounds
    	};
		}
    
		public VirtualCurrencyPack[] GetCurrencyPacks ()
		{
			return new VirtualCurrencyPack[] { COMBO2K_PACK, COMBO15K_PACK, COMBO5K_PACK };
		}
    
		public VirtualCategory[] GetCategories ()
		{
			return new VirtualCategory[] {UNLOCKABLE_CATEGORY, BACKGROUND_CATEGORY};
		}
    
		public NonConsumableItem[] GetNonConsumableItems ()
		{
			return new NonConsumableItem[] {};
		}
	}
}