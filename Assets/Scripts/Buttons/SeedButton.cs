using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class SeedButton : MonoBehaviour
{
    private const string TAG = "AAUNITY/GAME";

    public bool pressed = false;
    public int balance = 0;
    string itemId;
    public TimerCountdown timerScript;
    public AppleCollider colliderScript;
    public tk2dTextMesh textMesh;
    tk2dSprite sprite;
    bool used = false;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<tk2dSprite>();

        itemId = AndysApplesAssets.SUPER_SEED_GOOD.ItemId;
        balance = StoreInventory.GetItemBalance(itemId);

        //balance = 1;
        //Debug.Log("Seed-Powerup Balance at Fast Apples Game Start: " + balance);
        textMesh.text = balance.ToString();
        textMesh.Commit();
        HideIcon();

        InvokeRepeating("CheckThenActivate", 0.01f, 1.0f);
    }

    void CheckThenActivate()
    {
        //AndyUtils.LogDebug(TAG, "!used is " + !used);
        //AndyUtils.LogDebug(TAG, "balance = " + balance);
        //AndyUtils.LogDebug(TAG, "(!used && balance >0) is " + (!used && balance > 0));
        if (!used && balance > 0)
        {
            //AndyUtils.LogDebug(TAG, " Selecting Game Mode");
            switch (Application.loadedLevelName)
            {
                case "Fast Apples":
                    //AndyUtils.LogDebug(TAG, "(timerScript.countDownSeconds <= 5) is " + (timerScript.countDownSeconds <= 5));
                    if (timerScript.countDownSeconds <= 5)
                    {
                        used = !used;
                        ShowIcon();
                    }
                    break;
                case "Perfectionist":
                    //AndyUtils.LogDebug(TAG,"(colliderScript.lifeCounter == 1) is " + (colliderScript.lifeCounter == 1));
                    if (colliderScript.lifeCounter == 1)
                    {
                        used = !used;
                        ShowIcon();
                    }
                    break;
            }
        }
    }

    void ShowIcon()
    {
        sprite.gameObject.SetActive(true);
    }

    void HideIcon()
    {
        sprite.gameObject.SetActive(false);
    }

    void OnClick()
    {
        switch (Application.loadedLevelName)
        {
            case "Fast Apples":
                //AndyUtils.LogDebug(TAG, "Super Seed Button Pressed");
                clickedFA();
                break;
            case "Perfectionist":
                clickedPM();
                break;
        }
    }

    public void clickedFA()
    {
        StoreInventory.TakeItem(itemId, 1);
        HideIcon();
        //AndyUtils.LogDebug(TAG, "Reseting Timer");
        timerScript.resetTimer();
        CancelInvoke("CheckThenActivate");
    }

    public void clickedPM()
    {
        StoreInventory.TakeItem(itemId, 1);
        HideIcon();
        colliderScript.ResetLives();
        CancelInvoke("CheckThenActivate");
    }
}