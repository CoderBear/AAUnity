using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class Store : MonoBehaviour
{
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

    public void Start()
    {
        string ItemId;
        handler = new AndyEventHandler();

        Debug.Log("AAUNITY/SOOMLA LocalStoreInfo Initializing");
        LocalStoreInfo.Init();
        Debug.Log("AAUNITY/SOOMLA LocalStoreInfo Initialized");

        Debug.Log("AAUNITY/SOOMLA CurrencyBalance: " + StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID));
        currencyBalanceLabel.text = StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID).ToString();
        ItemId = AndysApplesAssets.SHIELD_POTION_GOOD.ItemId;
        Debug.Log("AAUNITY/SOOMLA Shield Balace is " + StoreInventory.GetItemBalance(ItemId));
        shieldBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        ItemId = AndysApplesAssets.ENERGY_POTION_GOOD.ItemId;
        Debug.Log("AAUNITY/SOOMLA Energy Balance is " + StoreInventory.GetItemBalance(ItemId));
        energyBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();
        ItemId = AndysApplesAssets.SUPER_SEED_GOOD.ItemId;
        Debug.Log("AAUNITY/SOOMLA Seed Balance is " + StoreInventory.GetItemBalance(ItemId));
        seedBalance.text = StoreInventory.GetItemBalance(ItemId).ToString();

        displayInfo();

        if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 0)
        {
            StoreInventory.GiveItem(AndysApplesAssets.ANDY_GOOD.ItemId, 1);
            andy.allowEquipping();
            StoreInventory.EquipVirtualGood(AndysApplesAssets.ANDY_GOOD.ItemId);
            andy.displayEquipStats(true);
        }
        else
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
            Debug.Log("AAUNITY/SOOMLA [" + i + "].ItemId= " + vg.ItemId);
            i++;
        }

        StoreController.StoreOpening();
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
        Debug.Log("AAUNITY/SOOMLA CurrencyBalance: " + StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID));
        currencyBalanceLabel.text = StoreInventory.GetItemBalance(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID).ToString();
    }
    #endregion

    #region Currency Pack Functions
    public void BuyPack1()
    {
        StoreInventory.BuyItem(AndysApplesAssets.COMBO725_PACK.ItemId);
        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    public void BuyPack2()
    {
        StoreInventory.BuyItem(AndysApplesAssets.COMBO2500_PACK.ItemId);
        Invoke("DisplayCurrencyInfo", 1.0f);
    }

    public void BuyPack3()
    {
        StoreInventory.BuyItem(AndysApplesAssets.COMBO5K_PACK.ItemId);
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
                        uVG = LocalStoreInfo.VirtualGoods[14];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[14 + 1];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[14 + 2];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[14 + 3];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[14 + 4];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[14 + 5];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = uVG.Description;
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[14 + 5];
                        upgradeFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(vg.ItemId).ToString();
                        upgradeFrenzy.description.text = "Fully Upgraded";
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        break;
                }
            }
            if (vg.ItemId == AndysApplesAssets.SUPER_GOOD.ItemId)
            {
                switch (StoreInventory.GetGoodUpgradeLevel(vg.ItemId))
                {
                    case 0: // Show info for Level 1
                        uVG = LocalStoreInfo.VirtualGoods[20];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[20 + 1];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[20 + 2];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[20 + 3];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[20 + 4];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[20 + 5];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeSuperFrenzy.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeSuperFrenzy.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[20 + 5];
                        upgradeSuperFrenzy.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
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
                        uVG = LocalStoreInfo.VirtualGoods[26];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[26 + 1];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[26 + 2];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[26 + 3];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[26 + 4];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[26 + 5];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeDoublePoints.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeDoublePoints.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[26 + 5];
                        upgradeDoublePoints.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
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
                        uVG = LocalStoreInfo.VirtualGoods[32];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[32 + 1];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[32 + 2];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[32 + 3];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[32 + 4];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[32 + 5];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeRepellent.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeRepellent.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[32 + 5];
                        upgradeRepellent.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
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
                        uVG = LocalStoreInfo.VirtualGoods[38];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 1: // Show info for Level 2
                        uVG = LocalStoreInfo.VirtualGoods[38 + 1];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 2: // Show info for Level 3
                        uVG = LocalStoreInfo.VirtualGoods[38 + 2];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 3: // Show info for Level 4
                        uVG = LocalStoreInfo.VirtualGoods[38 + 3];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 4: // Show info for Level 5
                        uVG = LocalStoreInfo.VirtualGoods[38 + 4];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    case 5:  // Show info for Level 6
                        uVG = LocalStoreInfo.VirtualGoods[38 + 5];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
                        upgradeLongevity.cost.text = ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount.ToString();
                        upgradeLongevity.description.text = uVG.Description;
                        break;
                    default:  // Show info for Fully Upgraded (Level 6)
                        uVG = LocalStoreInfo.VirtualGoods[38 + 5];
                        upgradeLongevity.amount.text = "Lv " + StoreInventory.GetGoodUpgradeLevel(uVG.ItemId).ToString();
                        Debug.Log("AAUNITY/SOOMLA cost for " + uVG.ItemId + " is " + ((PurchaseWithVirtualItem)uVG.PurchaseType).Amount);
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
        Debug.Log("AAUNITY/SOOMLA Frenzy Level = " + balance);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
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
            StoreInventory.UpgradeGood(ItemId);
        }
        displayInfo();
    }

    // Double Points Upgrade
    public void BuyUpgrade3()
    {
        string ItemId = AndysApplesAssets.DOUBLE_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            StoreInventory.UpgradeGood(ItemId);
        }
        displayInfo();
    }

    // Repellent Upgrade
    public void BuyUpgrade4()
    {
        string ItemId = AndysApplesAssets.REPELLENT_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            StoreInventory.UpgradeGood(ItemId);
        }
        displayInfo();
    }

    // Longevity Upgrade
    public void BuyUpgrade5()
    {
        string ItemId = AndysApplesAssets.LONGEVITY_GOOD.ItemId;
        int balance = StoreInventory.GetGoodUpgradeLevel(ItemId);

        if (balance < 6)
        {
            tracker.AddProgressToAchievement("Straight A's", 1.0f);
            StoreInventory.UpgradeGood(ItemId);
        }
        displayInfo();
    }
    #endregion

    #region Unlockable good functions
    public void BuySkin2()
    {
        string itemId = AndysApplesAssets.KELLY_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        Invoke("DisplayCurrencyInfo", 0.5f);
        kelly.allowEquipping();
    }

    public void BuySkin3()
    {
        string itemId = AndysApplesAssets.NINJA_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        Invoke("DisplayCurrencyInfo", 0.5f);
        ninja.allowEquipping();
    }

    public void BuySkin4()
    {
        string itemId = AndysApplesAssets.PIG_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        Invoke("DisplayCurrencyInfo", 0.5f);
        pig.allowEquipping();
    }

    public void BuySkin5()
    {
        string itemId = AndysApplesAssets.PIRATE_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        Invoke("DisplayCurrencyInfo", 0.5f);
        pirate.allowEquipping();
    }

    public void BuySkin6()
    {
        string itemId = AndysApplesAssets.WIZARD_GOOD.ItemId;
        StoreInventory.BuyItem(itemId);
        tracker.AddProgressToAchievement("The Starting Lineups", 1.0f);
        Invoke("DisplayCurrencyInfo", 0.5f);
        wizard.allowEquipping();
    }
    #endregion

    #region Equippable good functions
    public void EquipAndy()
    {
        string itemId = AndysApplesAssets.ANDY_GOOD.ItemId;

        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            andy.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            kelly.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            ninja.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            pig.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            pirate.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            wizard.displayEquipStats(false);
        }
    }

    public void EquipKelly()
    {
        string itemId = AndysApplesAssets.KELLY_GOOD.ItemId;

        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            kelly.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            andy.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            ninja.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            pig.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            pirate.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            wizard.displayEquipStats(false);
        }
    }

    public void EquipNinja()
    {
        string itemId = AndysApplesAssets.NINJA_GOOD.ItemId;

        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            ninja.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            andy.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            kelly.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            pig.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            pirate.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            wizard.displayEquipStats(false);
        }
    }

    public void EquipPig()
    {
        string itemId = AndysApplesAssets.PIG_GOOD.ItemId;

        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            pig.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            andy.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            kelly.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            ninja.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            pirate.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            wizard.displayEquipStats(false);
        }
    }

    public void EquipPirate()
    {
        string itemId = AndysApplesAssets.PIRATE_GOOD.ItemId;

        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            pirate.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            andy.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            kelly.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            ninja.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            pig.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.WIZARD_GOOD.ItemId) == 1)
            wizard.displayEquipStats(false);
        }
    }

    public void EquipWizard()
    {
        string itemId = AndysApplesAssets.WIZARD_GOOD.ItemId;

        if (!StoreInventory.IsVirtualGoodEquipped(itemId))
        {
            StoreInventory.EquipVirtualGood(itemId);
            wizard.displayEquipStats(true);

            // turn all others off
            if (StoreInventory.GetItemBalance(AndysApplesAssets.ANDY_GOOD.ItemId) == 1)
            andy.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.KELLY_GOOD.ItemId) == 1)
            kelly.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.NINJA_GOOD.ItemId) == 1)
            ninja.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIG_GOOD.ItemId) == 1)
            pig.displayEquipStats(false);
            if (StoreInventory.GetItemBalance(AndysApplesAssets.PIRATE_GOOD.ItemId) == 1)
            pirate.displayEquipStats(false);
        }
    }
    #endregion
}