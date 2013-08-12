using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class Store : MonoBehaviour
{
    private const string TAG = "AAUNITY/SOOMLA";

    public UILabel currencyBalanceLabel;
    private static AndyEventHandler handler;
    public UpgradeDisplay upgradeFrenzy;
    public UpgradeDisplay upgradeSuperFrenzy;
    public UpgradeDisplay upgradeDoublePoints;
    public UpgradeDisplay upgradeRepellent;
    public UpgradeDisplay upgradeLongevity;
    public UILabel shieldBalance, energyBalance, seedBalance;
    public AchievementTracker tracker;

    public UnlockablesDisplay andy, kelly, ninja, pig, pirate, wizard;
    public UnlockablesDisplay defaultBG, blossomBG;

    public void Start()
    {
        string ItemId;
        handler = new AndyEventHandler();

        AndyUtils.LogDebug(TAG, "LocalStoreInfo Initializing");
        LocalStoreInfo.Init();
        AndyUtils.LogDebug(TAG, "LocalStoreInfo Initialized");

        AndyUtils.LogDebug(TAG, "CurrencyBalance: " + StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID));
        currencyBalanceLabel.text = StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID).ToString();
        ItemId = AndysApplesAssets.SHIELD_POTION_GOOD.ItemId;
        AndyUtils.LogDebug(TAG, "Shield Balace is " + StoreInventory.GetItemBalance(ItemId));
        shieldBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        ItemId = AndysApplesAssets.ENERGY_POTION_GOOD.ItemId;
        AndyUtils.LogDebug(TAG, "Energy Balance is " + StoreInventory.GetItemBalance(ItemId));
        energyBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        ItemId = AndysApplesAssets.SUPER_SEED_GOOD.ItemId;
        AndyUtils.LogDebug(TAG, "Seed Balance is " + StoreInventory.GetItemBalance(ItemId));
        seedBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();

        displayInfo();

        // Initialize skins
        if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
        {
            andy.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
                andy.displayEquipStats(true);
            else
                andy.displayEquipStats(false);
        }

        if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
        {
            kelly.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
                kelly.displayEquipStats(true);
            else
                kelly.displayEquipStats(false);
        }
        else
        {
            kelly.notPurchased();
        }

        if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
        {
            ninja.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
                ninja.displayEquipStats(true);
            else
                ninja.displayEquipStats(false);
        }
        else
        {
            ninja.notPurchased();
        }

        if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
        {
            pig.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
                pig.displayEquipStats(true);
            else
                pig.displayEquipStats(false);
        }
        else
        {
            pig.notPurchased();
        }

        if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
        {
            pirate.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
                pirate.displayEquipStats(true);
            else
                pirate.displayEquipStats(false);
        }
        else
        {
            pirate.notPurchased();
        }

        if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
        {
            wizard.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
                wizard.displayEquipStats(true);
            else
                wizard.displayEquipStats(false);
        }
        else
        {
            wizard.notPurchased();
        }

        int i = 0;
        foreach (var vg in LocalStoreInfo.VirtualGoods)
        {
            AndyUtils.LogDebug(TAG, "[" + i + "].ItemId= " + vg.ItemId);
            i++;
        }

        StoreController.StoreOpening();

        // initialize backgrounds
        if (StoreInventory.GetItemBalance(AndysApplesAssets.DEFAULT_BG.ItemId) == 1)
        {
            defaultBG.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.DEFAULT_BG.ItemId))
                defaultBG.displayEquipStats(true);
            else
                defaultBG.displayEquipStats(false);
        }

        if (StoreInventory.GetItemBalance(AndysApplesAssets.CBLOSSOM_BG.ItemId) == 1)
        {
            AndyUtils.LogDebug(TAG, "Running allowEquipping() for " + AndysApplesAssets.CBLOSSOM_BG.ItemId);
            blossomBG.allowEquipping();
            if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.CBLOSSOM_BG.ItemId))
                blossomBG.displayEquipStats(true);
            else
                blossomBG.displayEquipStats(false);
        }
        else
        {
            AndyUtils.LogDebug(TAG, "Running notPurchased() for " + AndysApplesAssets.CBLOSSOM_BG.ItemId);
            blossomBG.notPurchased();
        }

    }

    public void CloseStore()
    {
        StoreController.StoreClosing();
    }

    void OnApplicationQuit()
    {
        StoreController.StoreClosing();
    }

    // Update is called once per frame
    void Update()
    {
    }

    #region Display Functions
    void DisplayCurrencyInfo()
    {
        AndyUtils.LogDebug(TAG, "CurrencyBalance: " + StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID));
        currencyBalanceLabel.text = StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID).ToString();
    }
    #endregion

    #region Currency Pack Functions
    public void BuyPack1()
    {
        StoreInventory.BuyItem(AndysApplesAssets.COMBO2K_PACK.ItemId);
        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    public void BuyPack2()
    {
        StoreInventory.BuyItem(AndysApplesAssets.COMBO5K_PACK.ItemId);
        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    public void BuyPack3()
    {
        StoreInventory.BuyItem(AndysApplesAssets.COMBO15K_PACK.ItemId);
        Invoke("DisplayCurrencyInfo", 1.0f);
    }
    #endregion

    #region Powerup Good Functions
    public void BuyShield()
    {
        string ItemId = AndysApplesAssets.SHIELD_POTION_GOOD.ItemId;
        int balance = LocalStoreInfo.GoodsBalances[ItemId];
        if (balance < 99)
        {
            StoreInventory.BuyItem(ItemId);
        }
        shieldBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    public void BuyEnergy()
    {
        string ItemId = AndysApplesAssets.ENERGY_POTION_GOOD.ItemId;
        int balance = LocalStoreInfo.GoodsBalances[ItemId];

        if (balance < 99)
        {
            StoreInventory.BuyItem(ItemId);
        }
        energyBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    public void BuySeed()
    {
        string ItemId = AndysApplesAssets.SUPER_SEED_GOOD.ItemId;
        int balance = LocalStoreInfo.GoodsBalances[ItemId];

        if (balance < 99)
        {
            StoreInventory.BuyItem(ItemId);
        }
        seedBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        Invoke("DisplayCurrencyInfo", 1.0f);
    }
    #endregion

    #region Upgrade Good Functions
    void displayInfo()
    {
        VirtualGood uVG;
        #region Frenzy Upgrades
        switch (StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId))
        {
            case 0: // Show info for Level 1
                uVG = AndysApplesAssets.FRENZY_UPGRADE1;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = uVG.Description;
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
            case 1: // Show info for Level 2
                uVG = AndysApplesAssets.FRENZY_UPGRADE2;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = uVG.Description;
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
            case 2: // Show info for Level 3
                uVG = AndysApplesAssets.FRENZY_UPGRADE3;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = uVG.Description;
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
            case 3: // Show info for Level 4
                uVG = AndysApplesAssets.FRENZY_UPGRADE4;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = uVG.Description;
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
            case 4: // Show info for Level 5
                uVG = AndysApplesAssets.FRENZY_UPGRADE5;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = uVG.Description;
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
            case 5:  // Show info for Level 6
                uVG = AndysApplesAssets.FRENZY_UPGRADE6;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = uVG.Description;
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
            default:  // Show info for Fully Upgraded (Level 6)
                uVG = AndysApplesAssets.FRENZY_UPGRADE6;
                upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.FRENZY_GOOD.ItemId).ToString();
                upgradeFrenzy.description.text = "Fully Upgraded";
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                break;
        }
        #endregion

        #region Super Frenzy Upgrades
        switch (StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.SUPER_GOOD.ItemId))
        {
            case 0: // Show info for Level 1
                uVG = AndysApplesAssets.SUPER_UPGRADE1;
                upgradeSuperFrenzy.amount.text = "Lv 0";
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = uVG.Description;
                break;
            case 1: // Show info for Level 2
                uVG = AndysApplesAssets.SUPER_UPGRADE2;
                upgradeSuperFrenzy.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = uVG.Description;
                break;
            case 2: // Show info for Level 3
                uVG = AndysApplesAssets.SUPER_UPGRADE3;
                upgradeSuperFrenzy.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = uVG.Description;
                break;
            case 3: // Show info for Level 4
                uVG = AndysApplesAssets.SUPER_UPGRADE4;
                upgradeSuperFrenzy.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = uVG.Description;
                break;
            case 4: // Show info for Level 5
                uVG = AndysApplesAssets.SUPER_UPGRADE5;
                upgradeSuperFrenzy.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = uVG.Description;
                break;
            case 5:  // Show info for Level 6
                uVG = AndysApplesAssets.SUPER_UPGRADE6;
                upgradeSuperFrenzy.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = uVG.Description;
                break;
            default:  // Show info for Fully Upgraded (Level 6)
                uVG = AndysApplesAssets.SUPER_UPGRADE6;
                upgradeSuperFrenzy.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeSuperFrenzy.description.text = "Fully Upgraded";
                break;
        }
        #endregion

        #region Double Points Upgrade
        switch (StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.DOUBLE_GOOD.ItemId))
        {
            case 0: // Show info for Level 1
                uVG = AndysApplesAssets.DOUBLE_UPGRADE1;
                upgradeDoublePoints.amount.text = "Lv 0";
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = uVG.Description;
                break;
            case 1: // Show info for Level 2
                uVG = AndysApplesAssets.DOUBLE_UPGRADE2;
                upgradeDoublePoints.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = uVG.Description;
                break;
            case 2: // Show info for Level 3
                uVG = AndysApplesAssets.DOUBLE_UPGRADE3;
                upgradeDoublePoints.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = uVG.Description;
                break;
            case 3: // Show info for Level 4
                uVG = AndysApplesAssets.DOUBLE_UPGRADE4;
                upgradeDoublePoints.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = uVG.Description;
                break;
            case 4: // Show info for Level 5
                uVG = AndysApplesAssets.DOUBLE_UPGRADE5;
                upgradeDoublePoints.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = uVG.Description;
                break;
            case 5:  // Show info for Level 6
                uVG = AndysApplesAssets.DOUBLE_UPGRADE6;
                upgradeDoublePoints.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = uVG.Description;
                break;
            default:  // Show info for Fully Upgraded (Level 6)
                uVG = AndysApplesAssets.DOUBLE_UPGRADE6;
                upgradeDoublePoints.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeDoublePoints.description.text = "Fully Upgraded";
                break;
        }
        #endregion

        #region Repellent Upgrades
        switch (StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.REPELLENT_GOOD.ItemId))
        {
            case 0: // Show info for Level 1
                uVG = AndysApplesAssets.REPELLENT_UPGRADE1;
                upgradeRepellent.amount.text = "Lv 0";
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = uVG.Description;
                break;
            case 1: // Show info for Level 2
                uVG = AndysApplesAssets.REPELLENT_UPGRADE2;
                upgradeRepellent.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = uVG.Description;
                break;
            case 2: // Show info for Level 3
                uVG = AndysApplesAssets.REPELLENT_UPGRADE3;
                upgradeRepellent.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = uVG.Description;
                break;
            case 3: // Show info for Level 4
                uVG = AndysApplesAssets.REPELLENT_UPGRADE4;
                upgradeRepellent.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = uVG.Description;
                break;
            case 4: // Show info for Level 5
                uVG = AndysApplesAssets.REPELLENT_UPGRADE5;
                upgradeRepellent.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = uVG.Description;
                break;
            case 5:  // Show info for Level 6
                uVG = AndysApplesAssets.REPELLENT_UPGRADE6;
                upgradeRepellent.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = uVG.Description;
                break;
            default:  // Show info for Fully Upgraded (Level 6)
                uVG = AndysApplesAssets.REPELLENT_UPGRADE6;
                upgradeRepellent.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeRepellent.description.text = "Fully Upgraded";
                break;
        } 
        #endregion

        #region Longevity Upgrades
        switch (StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.LONGEVITY_GOOD.ItemId))
        {
            case 0: // Show info for Level 1
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE1;
                upgradeLongevity.amount.text = "Lv 0";
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = uVG.Description;
                break;
            case 1: // Show info for Level 2
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE2;
                upgradeLongevity.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = uVG.Description;
                break;
            case 2: // Show info for Level 3
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE3;
                upgradeLongevity.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = uVG.Description;
                break;
            case 3: // Show info for Level 4
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE4;
                upgradeLongevity.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = uVG.Description;
                break;
            case 4: // Show info for Level 5
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE5;
                upgradeLongevity.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = uVG.Description;
                break;
            case 5:  // Show info for Level 6
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE6;
                upgradeLongevity.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = uVG.Description;
                break;
            default:  // Show info for Fully Upgraded (Level 6)
                uVG = AndysApplesAssets.LONGEVITY_UPGRADE6;
                upgradeLongevity.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                upgradeLongevity.description.text = "Fully Upgraded";
                break;
        }
        #endregion

        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    // Frenzy Upgrade
    public void BuyUpgrade1()
    {
        string ItemId = AndysApplesAssets.FRENZY_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);
        AndyUtils.LogDebug(TAG, "Frenzy Level = " + balance);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            tracker.StoreIAPprogress();
            StoreInventory.UpgradeGood(ItemId);
            displayInfo();
        }
    }

    // Super Frenzy Upgrade
    public void BuyUpgrade2()
    {
        string ItemId = AndysApplesAssets.SUPER_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            tracker.StoreIAPprogress();
            StoreInventory.UpgradeGood(ItemId);
            displayInfo();
        }
    }

    // Double Points Upgrade
    public void BuyUpgrade3()
    {
        string ItemId = AndysApplesAssets.DOUBLE_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            tracker.StoreIAPprogress();
            StoreInventory.UpgradeGood(ItemId);
            displayInfo();
        }
    }

    // Repellent Upgrade
    public void BuyUpgrade4()
    {
        string ItemId = AndysApplesAssets.REPELLENT_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            tracker.StoreIAPprogress();
            StoreInventory.UpgradeGood(ItemId);
            displayInfo();
        }
    }

    // Longevity Upgrade
    public void BuyUpgrade5()
    {
        string ItemId = AndysApplesAssets.LONGEVITY_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            tracker.StoreIAPprogress();
            StoreInventory.UpgradeGood(ItemId);
            displayInfo();
        }
    }
    #endregion

    #region Unlockable good functions
    public void BuySkin2()
    {
        string itemId = AndysApplesAssets.KELLY_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        tracker.StoreIAPprogress();
        Invoke("DisplayCurrencyInfo", 0.5f);
        kelly.allowEquipping();
    }

    public void BuySkin3()
    {
        string itemId = AndysApplesAssets.NINJA_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        tracker.StoreIAPprogress();
        Invoke("DisplayCurrencyInfo", 0.5f);
        ninja.allowEquipping();
    }

    public void BuySkin4()
    {
        string itemId = AndysApplesAssets.PIG_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        tracker.StoreIAPprogress();
        Invoke("DisplayCurrencyInfo", 0.5f);
        pig.allowEquipping();
    }

    public void BuySkin5()
    {
        string itemId = AndysApplesAssets.PIRATE_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        tracker.StoreIAPprogress();
        Invoke("DisplayCurrencyInfo", 0.5f);
        pirate.allowEquipping();
    }

    public void BuySkin6()
    {
        string itemId = AndysApplesAssets.WIZARD_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        tracker.StoreIAPprogress();
        Invoke("DisplayCurrencyInfo", 0.5f);
        wizard.allowEquipping();
    }

    public void BuyBackground2()
    {
        string itemId = AndysApplesAssets.CBLOSSOM_BG.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("Change of Scenery", 1.0f);
        tracker.StoreIAPprogress();
        Invoke("DisplayCurrencyInfo", 0.5f);
        blossomBG.allowEquipping();
    }
    #endregion

    #region Equippable good functions
    public void EquipAndy()
    {
        string itemId = AndysApplesAssets.ANDY_GOOD.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            andy.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.KELLY_GOOD.ItemId);
                kelly.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.NINJA_GOOD.ItemId);
                ninja.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIG_GOOD.ItemId);
                pig.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIRATE_GOOD.ItemId);
                pirate.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.WIZARD_GOOD.ItemId);
                wizard.displayEquipStats(false);
            }
        }
    }

    public void EquipKelly()
    {
        string itemId = AndysApplesAssets.KELLY_GOOD.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            kelly.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            {
                if(StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
                andy.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.NINJA_GOOD.ItemId);
                ninja.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIG_GOOD.ItemId);
                pig.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIRATE_GOOD.ItemId);
                pirate.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.WIZARD_GOOD.ItemId);
                wizard.displayEquipStats(false);
            }
        }
    }

    public void EquipNinja()
    {
        string itemId = AndysApplesAssets.NINJA_GOOD.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            ninja.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
                andy.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.KELLY_GOOD.ItemId);
                kelly.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIG_GOOD.ItemId);
                pig.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIRATE_GOOD.ItemId);
                pirate.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.WIZARD_GOOD.ItemId);
                wizard.displayEquipStats(false);
            }
        }
    }

    public void EquipPig()
    {
        string itemId = AndysApplesAssets.PIG_GOOD.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            pig.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
                andy.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.KELLY_GOOD.ItemId);
                kelly.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.NINJA_GOOD.ItemId);
                ninja.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIRATE_GOOD.ItemId);
                pirate.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.WIZARD_GOOD.ItemId);
                wizard.displayEquipStats(false);
            }
        }
    }

    public void EquipPirate()
    {
        string itemId = AndysApplesAssets.PIRATE_GOOD.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            pirate.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
                andy.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.KELLY_GOOD.ItemId);
                kelly.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.NINJA_GOOD.ItemId);
                ninja.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIG_GOOD.ItemId);
                pig.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.WIZARD_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.WIZARD_GOOD.ItemId);
                wizard.displayEquipStats(false);
            }
        }
    }

    public void EquipWizard()
    {
        string itemId = AndysApplesAssets.WIZARD_GOOD.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            wizard.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.ANDY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
                andy.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.KELLY_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.KELLY_GOOD.ItemId);
                kelly.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.NINJA_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.NINJA_GOOD.ItemId);
                ninja.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIG_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIG_GOOD.ItemId);
                pig.displayEquipStats(false);
            }
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.PIRATE_GOOD.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.PIRATE_GOOD.ItemId);
                pirate.displayEquipStats(false);
            }
        }
    }
    #endregion

    #region Equippable Backgrounds Functions
    public void EquipDefaultBG()
    {
        string itemId = AndysApplesAssets.DEFAULT_BG.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            defaultBG.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.CBLOSSOM_BG.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.CBLOSSOM_BG.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.CBLOSSOM_BG.ItemId);
                blossomBG.displayEquipStats(false);
            }
        }
    }

    public void EquipBlossomBG()
    {
        string itemId = AndysApplesAssets.CBLOSSOM_BG.ItemId;

        AndyUtils.LogDebug(TAG, "StoreInventory.IsVirtualGoodEquipped(" + itemId + ") is " + !StoreInventory.IsVirtualGoodEquipped(itemId));
        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            blossomBG.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.DEFAULT_BG.ItemId) == 1)
            {
                if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.DEFAULT_BG.ItemId))
                    StoreInventory.UnEquipVirtualGood(AndysApplesAssets.DEFAULT_BG.ItemId);
                defaultBG.displayEquipStats(false);
            }
        }
    }
    #endregion
}