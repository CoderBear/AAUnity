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
        foreach (VirtualGood vg in LocalStoreInfo.VirtualGoods)
        {
            VirtualGood uVG;
            if (vg.ItemId == AndysApplesAssets.FRENZY_GOOD.ItemId)
            {
                switch (StoreInventory.GetGoodUpgradeLevel(vg.ItemId))
                {
                    case 0: // Show info for Level 1
                        uVG = LocalStoreInfo.VirtualGoods[16];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[16 + 1];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[16 + 2];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[16 + 3];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[16 + 4];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[16 + 5];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[16 + 5];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = "Fully Upgraded";
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                }
            }
            if (vg.ItemId == AndysApplesAssets.SUPER_GOOD.ItemId)
            {
                switch (StoreInventory.GetGoodUpgradeLevel(vg.ItemId))
                {
                    case 0: // Show info for Level 1
                        uVG = LocalStoreInfo.VirtualGoods[22];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[22 + 1];
                        upgradeSuperFrenzy.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[22 + 2];
                        upgradeSuperFrenzy.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[22 + 3];
                        upgradeSuperFrenzy.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[22 + 4];
                        upgradeSuperFrenzy.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[22 + 5];
                        upgradeSuperFrenzy.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[22 + 5];
                        upgradeSuperFrenzy.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = "Fully Upgraded";
                        break;
                }
            }
            if (vg.ItemId == AndysApplesAssets.DOUBLE_GOOD.ItemId)
            {
                switch (StoreInventory.GetGoodUpgradeLevel(vg.ItemId))
                {
                    case 0: // Show info for Level 1
                        uVG = LocalStoreInfo.VirtualGoods[28];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[28 + 1];
                        upgradeDoublePoints.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[28 + 2];
                        upgradeDoublePoints.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[28 + 3];
                        upgradeDoublePoints.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[28 + 4];
                        upgradeDoublePoints.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[28 + 5];
                        upgradeDoublePoints.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[28 + 5];
                        upgradeDoublePoints.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = "Fully Upgraded";
                        break;
                }
            }
            if (vg.ItemId == AndysApplesAssets.REPELLENT_GOOD.ItemId)
            {
                switch (StoreInventory.GetGoodUpgradeLevel(vg.ItemId))
                {
                    case 0: // Show info for Level 1
                        uVG = LocalStoreInfo.VirtualGoods[34];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[34 + 1];
                        upgradeRepellent.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[34 + 2];
                        upgradeRepellent.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[34 + 3];
                        upgradeRepellent.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[34 + 4];
                        upgradeRepellent.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[34 + 5];
                        upgradeRepellent.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[34 + 5];
                        upgradeRepellent.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = "Fully Upgraded";
                        break;
                }
            }
            if (vg.ItemId == AndysApplesAssets.LONGEVITY_GOOD.ItemId)
            {
                switch (StoreInventory.GetGoodUpgradeLevel(vg.ItemId))
                {
                    case 0: // Show info for Level 1
                        uVG = LocalStoreInfo.VirtualGoods[40];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[40 + 1];
                        upgradeLongevity.amount.text = "Lv 1";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[40 + 2];
                        upgradeLongevity.amount.text = "Lv 2";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[40 + 3];
                        upgradeLongevity.amount.text = "Lv 3";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[40 + 4];
                        upgradeLongevity.amount.text = "Lv 4";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[40 + 5];
                        upgradeLongevity.amount.text = "Lv 5";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[40 + 5];
                        upgradeLongevity.amount.text = "Lv 6";// + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        AndyUtils.LogDebug(TAG, "cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = "Fully Upgraded";
                        break;
                }
            }
        }

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