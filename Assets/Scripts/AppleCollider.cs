using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class AppleCollider : MonoBehaviour
{
    private const string TAG = "AAUNITY/GAME";

    public enum GAME_MODES
    {
        FAST_APPLES,
        PERFECTIONIST,
    };

    public enum GOLD_EFFECTS
    {
        NONE,
        FRENZY,
        SUPERFRENZY,
        DOUBLE,
        REPEL
    };

    public optionDB optionDB;
    public AchievementTracker achievementTracker;
    public Spawner spawnScript;
    public GAME_MODES GAME_MODE;
    public GOLD_EFFECTS CURRENT_EFFECT = GOLD_EFFECTS.NONE;
    public GOLD_EFFECTS LAST_EFFECT = GOLD_EFFECTS.NONE;
    public int GE_INDEX = (int)GOLD_EFFECTS.NONE;
    public int GM_INDEX;
    public playerAnimController script;
    public TimerCountdown timerScript;
    public tk2dTextMesh textScore;
    public tk2dTextMesh comboText;
    public tk2dTextMesh timerText;
    public tk2dAnimatedSprite animHighscore;
    public tk2dAnimatedSprite animGold;
    public StatsDB db;
    public AudioClip caughtGood;
    public AudioClip caughtGold;
    public AudioClip caughtBad;
    public AudioClip combo_increased;
    public bool comboIncreased, goldEffectActive, newHighscore, comboIncremented, caught;
    private int score, comboCount, combo;
    public int highscore, gameNum, displayedScore;
    public int lifeCounter;
    public bool audioOn;
    private bool firstCatch = false, firstGame = true;

    public int caughtApples
    {
        get;
        set;
    }

    public int totalGameCombos
    {
        get;
        set;
    }

    public int multiplier;
    int effectTimer, effectTimerCounter;
    bool result = true;

    // Automatically run when a game starts
    void Awake()
    {
        Debug.Log(TAG + " first catch is " + firstCatch);
        GM_INDEX = (int)GAME_MODE;

        script = transform.parent.GetComponent<playerAnimController>();
        score = int.Parse(textScore.text);
        combo = int.Parse(comboText.text);

        switch (Application.loadedLevel)
        {
            case 3: // Fast Apples
                gameNum = db.getValue("fa_games");
                //AndyUtils.LogDebug(TAG,"Fast Apples games played: " + gameNum);
                if (gameNum > 0)
                {
                    firstGame = false;
                    highscore = db.getValue("fa_gamescore");
                }
                break;
            case 4: // Perfectionist
                if (StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.LONGEVITY_GOOD.ItemId) > 4)
                {
                    lifeCounter = 5;
                }
                else
                {
                    lifeCounter = 3;
                }
                timerText.text = lifeCounter.ToString();
                timerText.Commit();
                gameNum = db.getValue("p_games");
                //AndyUtils.LogDebug(TAG,"Perfectionist games played: " + gameNum);
                if (gameNum > 0)
                {
                    firstGame = false;
                    highscore = db.getValue("p_gamescore");
                }
                break;
        }

#if UNITY_ANDROID
        TouchSenseSingleDevice device = new TouchSenseSingleDevice(0);
        //AndyUtils.LogDebug(TAG, "Device is " + device.name);
        //AndyUtils.LogDebug(TAG, "Device type is " + device.type.ToString());
        Debug.Log(TAG + "Device is " + device.name);
        Debug.Log(TAG + "Device type is " + device.type.ToString());
        if (device == null)
        {
            result = false;
            TouchSense.instance.hapticsEnabled = false;
        }
#endif

        effectTimer = 5;
    }

    // Use this for initialization
    void Start()
    {
        totalGameCombos = 0;
        displayedScore = 0;
        caughtApples = 0;

        comboIncreased = false;
        comboIncremented = false;

        caught = false;

        newHighscore = false;

        goldEffectActive = false;

        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;

        multiplier = db.getValue("multiplier");
        Debug.Log("AAUNITY/GAME Multiplier at game start is " + multiplier);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PauseGame()
    {
        if(IsInvoking())
        CancelInvoke();
    }

    public void ResumeGame()
    {
        Invoke("decrementEffectTimer", 1.0f);
        Invoke("deactivateEffect", (float)effectTimerCounter);
    }

    void OnCollisionEnter(Collision collision)
    {
        achievementTracker.AddProgressToAchievement("Apple Lover", 1.0f);
        achievementTracker.AddProgressToAchievement("Apple Champion", 1.0f);

        achievementTracker.AddProgressToAchievement("Rookie Picker", 1.0f);
        achievementTracker.AddProgressToAchievement("Novice Picker", 1.0f);
        achievementTracker.AddProgressToAchievement("Picker Pro", 1.0f);
        achievementTracker.AddProgressToAchievement("Apple Hungry", 1.0f);
        achievementTracker.AddProgressToAchievement("Bushel Master", 1.0f);
        achievementTracker.AddProgressToAchievement("Appleopoly", 1.0f);

        incrementAppleCaughtAchievement();

        GameObject ColGO = collision.gameObject;
        Destroy(ColGO);

        if (timerScript.timerActive)
        {
            if (ColGO.tag == "NormalApple")
            {
                caught = true;
                if (audioOn)
                    audio.PlayOneShot(caughtGood);
                caughtApples++;
                if (CURRENT_EFFECT == GOLD_EFFECTS.DOUBLE || CURRENT_EFFECT == GOLD_EFFECTS.SUPERFRENZY)
                {
                    score += 20;
                }
                else
                {
                    score += 10;
                }
                if (multiplier > 0)
                    displayedScore = multiplier * ((10 * caughtApples) + score + (10 * combo));
                else
                    displayedScore = ((10 * caughtApples) + score + (10 * combo));
            }
            if (ColGO.tag == "ComboApple")
            {
                caughtApples++;
                if (CURRENT_EFFECT == GOLD_EFFECTS.DOUBLE || CURRENT_EFFECT == GOLD_EFFECTS.SUPERFRENZY)
                {
                    score += 60;
                }
                else
                {
                    score += 30;
                }
                if (multiplier > 0)
                    displayedScore = multiplier * ((10 * caughtApples) + score + (10 * combo));
                else
                    displayedScore = ((10 * caughtApples) + score + (10 * combo));
                incrementCombo();
            }
            if (ColGO.tag == "GoldApple")
            {
#if UNITY_ANDROID
                if (result)
                    TouchSense.instance.playBuiltinEffect(TouchSense.IMPACT_WOOD_100);
#endif
                //AndyUtils.LogDebug(TAG,"Gold Apple Caught");
                incementGoldAppleAchievement();
                if (audioOn)
                    audio.PlayOneShot(caughtGold);
                caughtApples++;
                if (GAME_MODE == GAME_MODES.FAST_APPLES)
                {
                    if (int.Parse(timerText.text) > 5)
                    {
                        timerScript.countDownSeconds += 2;
                        timerText.text = timerScript.countDownSeconds.ToString();
                        timerText.Commit();
                    }
                }
                if (CURRENT_EFFECT == GOLD_EFFECTS.DOUBLE || CURRENT_EFFECT == GOLD_EFFECTS.SUPERFRENZY)
                {
                    score += 800;
                }
                else
                {
                    score += 400;
                }

                if (multiplier > 0)
                    displayedScore = multiplier * ((10 * caughtApples) + score + (10 * combo));
                else
                    displayedScore = ((10 * caughtApples) + score + (10 * combo));
                if (!goldEffectActive)
                {
                    //AndyUtils.LogDebug(TAG,"Now activating Gold Effect");
                    activateEffect();
                }

#if UNITY_ANDROID
                if (result)
                    TouchSense.instance.stopPlayingBuiltinEffect();
#endif
            }
            //			AndyUtils.LogDebug(TAG,"!firstGame is " + !firstGame);
            if (!firstGame)
            {
                //				AndyUtils.LogDebug(TAG,"!newHighscore is " + !newHighscore);
                if (!newHighscore)
                {
                    //					AndyUtils.LogDebug(TAG,"(displayedScore > highscore) is " + (displayedScore > highscore));
                    if (displayedScore > highscore)
                    {
                        newHighscore = true;
                    }
                }
            }

            textScore.text = displayedScore.ToString();
            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            textScore.Commit();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
#if UNITY_ANDROID
        if (result)
            TouchSense.instance.playBuiltinEffect(TouchSense.EXPLOSION1);
#endif
        spawnScript.removeFromList(collision.gameObject);
        Destroy(collision.gameObject);
        if (audioOn)
            audio.PlayOneShot(caughtBad);
        achievementTracker.AddProgressToAchievement("Rotten Palooza", 1.0f);
        if (GAME_MODE == GAME_MODES.PERFECTIONIST)
        {
            if (lifeCounter > 0)
            {
                lifeCounter--;
                timerText.text = lifeCounter.ToString();
                timerText.Commit();
            }
        }
        else
        {
            if (int.Parse(timerText.text) > 5)
            {
                timerScript.countDownSeconds -= 2;
                timerText.text = timerScript.countDownSeconds.ToString();
                timerText.Commit();
            }
        }

        if (CURRENT_EFFECT == GOLD_EFFECTS.DOUBLE)
        {
            score -= 200;
        }
        else
        {
            score -= 100;
        }
        combo = comboCount = 0;
        if (multiplier > 0)
            displayedScore = multiplier * ((10 * caughtApples) + score + (10 * combo));
        else
            displayedScore = ((10 * caughtApples) + score + (10 * combo));
#if UNITY_ANDROID
        if (result)
            TouchSense.instance.stopPlayingBuiltinEffect();
#endif
        comboText.text = combo.ToString();
        // This is important, your changes will not be updated until you call Commit()
        // This is so you can change multiple parameters without reconstructing
        // the mesh repeatedly
        comboText.Commit();

        textScore.text = displayedScore.ToString();
        // This is important, your changes will not be updated until you call Commit()
        // This is so you can change multiple parameters without reconstructing
        // the mesh repeatedly
        textScore.Commit();

        resetStreakAchievements();
    }

    private void incrementCombo()
    {
        if (comboCount < 2)
        {
            comboIncremented = true;
            comboCount++;
            //AndyUtils.LogDebug(TAG,"Current combo count: " + comboCount);
        }
        else if (comboCount == 2)
        {
            if (audioOn)
                audio.PlayOneShot(combo_increased);
            comboIncreased = true;
            combo++;
            totalGameCombos++;
            comboCount = 0;
            //AndyUtils.LogDebug(TAG,"Current combo total: " + combo);
            //AndyUtils.LogDebug(TAG,"Current game combo total: " + totalGameCombos);

            if (GAME_MODE == GAME_MODES.PERFECTIONIST)
            {
                if (combo > 99)
                {
                    if (lifeCounter < 9)
                        lifeCounter++;
                    timerText.text = lifeCounter.ToString();
                    timerText.Commit();
                    combo = 0;
                }
            }
            else
            {
                if (int.Parse(timerText.text) > 5)
                {
                    timerScript.countDownSeconds += 1;
                    timerText.text = timerScript.countDownSeconds.ToString();
                    timerText.Commit();
                }
            }

            comboText.text = combo.ToString();
            // This is important, your changes will not be updated until you call Commit()
            // This is so you can change multiple parameters without reconstructing
            // the mesh repeatedly
            comboText.Commit();
            incrementComboAchievements();
        }
    }

    public void DisplayLives()
    {
        timerText.text = lifeCounter.ToString();
        timerText.Commit();
    }

    public void ResetLives()
    {
        if ((StoreInventory.GetGoodUpgradeLevel(AndysApplesAssets.LONGEVITY_GOOD.ItemId) > 4) && optionDB.getStatus(3))
        {
            lifeCounter = 5;
        }
        else
        {
            lifeCounter = 3;
        }
        DisplayLives();
    }

    /*--- Gold Effect Methods ---*/
    #region Gold Effects Functions
    private void activateEffect()
    {
        string itemId = "";
        goldEffectActive = true;
        MersenneTwister random = new MersenneTwister();
        int index = random.Next(1, 5);
        if (!firstCatch)
        {
            Debug.Log(TAG + " first catch was " + firstCatch);
            firstCatch = !firstCatch;
            Debug.Log(TAG + " first catch is now " + firstCatch);
            if (effectTimer == 0) effectTimer = 5;
            switch (index)
            {
                case 1:
                    //AndyUtils.LogDebug(TAG, "Index " + index + ": Frenzy");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Frenzy");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
                case 2:
                    //AndyUtils.LogDebug(TAG, "Index " + index + ": Super Frenzy");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Super Frenzy");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
                case 3:
                    //AndyUtils.LogDebug(TAG, "Index " + index + ": Double Points");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Double");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
                case 4:
                    //AndyUtils.LogDebug(TAG, "Index " + index + ": Repellent");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Repellent");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
            }
        }

        // set the item id for the store invetory retrival
        switch (index)
        {
            case 1: // Frenzy
                //AndyUtils.LogDebug(TAG,"Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.FRENZY;
                //AndyUtils.LogDebug(TAG,"Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.FRENZY_GOOD.ItemId;
                break;
            case 2: // Super Frenzy
                //AndyUtils.LogDebug(TAG,"Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.SUPERFRENZY;
                //AndyUtils.LogDebug(TAG,"Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.SUPER_GOOD.ItemId;
                break;
            case 3: // Double Points
                //AndyUtils.LogDebug(TAG,"Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.DOUBLE;
                //AndyUtils.LogDebug(TAG,"Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.DOUBLE_GOOD.ItemId;
                break;
            case 4: // Repellent
                //AndyUtils.LogDebug(TAG,"Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.REPEL;
                //AndyUtils.LogDebug(TAG,"Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.REPELLENT_GOOD.ItemId;
                break;
        }
        //AndyUtils.LogDebug(TAG,"now adding to achievements");
        achievementTracker.AddProgressToAchievement("Gold Standard", 1.0f);

        GE_INDEX = index;
        //AndyUtils.LogDebug(TAG,"now switching on/ Gold effect");
        switch (CURRENT_EFFECT)
        {
            case GOLD_EFFECTS.FRENZY:
                achievementTracker.AddProgressToAchievement("Frenzy Fanatic", 1.0f);
                achievementTracker.AddProgressToAchievement("Fred's Frenzy Bonanaza", 1.0f);
                if (StoreInventory.GetGoodUpgradeLevel(itemId) < 6)
                    effectTimer += StoreInventory.GetGoodUpgradeLevel(itemId);
                else
                    effectTimer += 5;
                break;
            case GOLD_EFFECTS.SUPERFRENZY:
                achievementTracker.AddProgressToAchievement("Raining Combos", 1.0f);
                achievementTracker.AddProgressToAchievement("Super Frenzy Wizard", 1.0f);
                incrementSuperFrenzyAchievements();
                if (StoreInventory.GetGoodUpgradeLevel(itemId) < 6)
                    effectTimer += StoreInventory.GetGoodUpgradeLevel(itemId);
                else
                    effectTimer += 5;
                break;
            case GOLD_EFFECTS.DOUBLE:
                achievementTracker.AddProgressToAchievement("Twice The Charm", 1.0f);
                achievementTracker.AddProgressToAchievement("2X Mastery", 1.0f);
                if (StoreInventory.GetGoodUpgradeLevel(itemId) < 6)
                    effectTimer += StoreInventory.GetGoodUpgradeLevel(itemId);
                else
                    effectTimer += 5;
                break;
            case GOLD_EFFECTS.REPEL:
                achievementTracker.AddProgressToAchievement("Honor System", 1.0f);
                achievementTracker.AddProgressToAchievement("No No to Rottens", 1.0f);
                if (StoreInventory.GetGoodUpgradeLevel(itemId) < 6)
                    effectTimer += StoreInventory.GetGoodUpgradeLevel(itemId);
                else
                    effectTimer += 5;
                break;
            default:
                break;
        }

        //AndyUtils.LogDebug(TAG,"Effect timer length for Gold Effect " + CURRENT_EFFECT + " is " + effectTimer + " seconds.");
        effectTimerCounter = effectTimer;

        Invoke("decrementEffectTimer", 1.0f);
        Invoke("deactivateEffect", (float)effectTimer);
    }

    public void deactivateEffect()
    {
        CancelInvoke("decrementEffectTimer");
        GE_INDEX = 0;
        LAST_EFFECT = CURRENT_EFFECT;
        CURRENT_EFFECT = GOLD_EFFECTS.NONE;
        goldEffectActive = false;
        effectTimer = 5;
        effectTimerCounter = effectTimer;
    }

    void decrementEffectTimer() {
        effectTimerCounter--;
    }

    // This is called once the animation has compelted playing.
    public void AnimFinishedDelegate(tk2dAnimatedSprite sprite, int clipId)
    {
        sprite.gameObject.SetActive(false);
    }
    #endregion

    #region GameOver Functions
    public void StoreGameStats()
    {
        // No gold caught achievement

        // Check to make sure a golden apple was never caught
        // and that the game mode is Fast Apples (scene 3)
        if (!firstCatch  && (Application.loadedLevel == 3))
        {
            Debug.Log(TAG + " 'Allergic to Powerups' being added to");
            achievementTracker.AddProgressToAchievement("Allergic to Powerups", 1.0f);
        }

        // Score Achievements
        achievementTracker.AddProgressToAchievement("Big Show Joe", displayedScore);
        achievementTracker.AddProgressToAchievement("Andy's 250K", displayedScore);
        achievementTracker.AddProgressToAchievement("Andy's 500K", displayedScore);
        achievementTracker.AddProgressToAchievement("Andy's 750K", displayedScore);
        achievementTracker.AddProgressToAchievement("Andy's Million", displayedScore);
        achievementTracker.AddProgressToAchievement("Exclusive Company", displayedScore);
        achievementTracker.AddProgressToAchievement("Hall of Famer", displayedScore);

        StoreInventory.GiveItem(AndysApplesAssets.COMBO_CURRENCY_ITEM_ID, totalGameCombos);
        // Specific Mode Achievements
        switch (GAME_MODE)
        {
            case GAME_MODES.FAST_APPLES:
                GA.API.Design.NewEvent("Mode: " + Application.loadedLevelName, timerScript.analyticsTimer);
                if (db.getValue("fa_games") != 0)
                {
                    db.StoreValue(2, db.getValue("lifetime_apples") + caughtApples);
                    db.StoreValue(3, db.getValue("lifetime_games") + 1);
                    db.StoreValue(5, db.getValue("fa_games") + 1);
                    db.StoreValue(8, db.getValue("fa_combo_total") + totalGameCombos);
                    if (db.getValue("fa_apples") < caughtApples)
                        db.StoreValue(4, caughtApples);
                    if (db.getValue("fa_gamescore") < displayedScore)
                        db.StoreValue(9, displayedScore);
                    if (db.getValue("fa_combo") < totalGameCombos)
                        db.StoreValue(7, totalGameCombos);
                    if (db.getValue("fa_time") < timerScript.totalTime)
                        db.StoreValue(6, timerScript.totalTime);
                }
                else
                {
                    db.StoreValue(2, caughtApples); // lifetime apples
                    db.StoreValue(3, db.getValue("lifetime_games") + 1); // lifetime games
                    db.StoreValue(5, 1); // fast apple_games
                    db.StoreValue(4, caughtApples);
                    db.StoreValue(9, displayedScore);
                    db.StoreValue(7, totalGameCombos);
                    db.StoreValue(8, totalGameCombos);
                    db.StoreValue(6, timerScript.totalTime);
                }
                break;
            case GAME_MODES.PERFECTIONIST:
                GA.API.Design.NewEvent("Mode: " + Application.loadedLevelName, timerScript.analyticsTimer);
                achievementTracker.AddProgressToAchievement("A Tad Insane", 1.0f);
                achievementTracker.AddProgressToAchievement("Mr. Clean Basket", 1.0f);
                achievementTracker.AddProgressToAchievement("Mr. Bateman", 1.0f);

                if (db.getValue("p_games") != 0)
                {
                    db.StoreValue(2, db.getValue("lifetime_apples") + caughtApples);
                    db.StoreValue(3, db.getValue("lifetime_games") + 1);
                    db.StoreValue(11, db.getValue("p_games") + 1);
                    db.StoreValue(14, db.getValue("p_combo_total") + totalGameCombos);
                    if (db.getValue("p_apples") < caughtApples)
                        db.StoreValue(10, caughtApples);
                    if (db.getValue("p_gamescore") < displayedScore)
                        db.StoreValue(15, displayedScore);
                    if (db.getValue("p_combo") < totalGameCombos)
                        db.StoreValue(13, totalGameCombos);
                    if (db.getValue("p_time") < timerScript.totalTime)
                        db.StoreValue(12, timerScript.totalTime);
                }
                else
                {
                    db.StoreValue(2, caughtApples); // lifetime apples
                    db.StoreValue(3, db.getValue("lifetime_games") + 1); // lifetime games
                    db.StoreValue(11, 1); // perfectionist_games
                    db.StoreValue(10, caughtApples);
                    db.StoreValue(15, displayedScore);
                    db.StoreValue(13, totalGameCombos);
                    db.StoreValue(14, totalGameCombos);
                    db.StoreValue(12, timerScript.totalTime);
                }
                break;
        }

        // Games Played Achievements
        achievementTracker.AddProgressToAchievement("Prime Time", 1.0f);

        db.StoreValue(1, achievementTracker.getRewardPoints()); // multiplier
        multiplier = achievementTracker.getRewardPoints();
        //AndyUtils.LogDebug(TAG, "Multiplier at game end is " + multiplier);
        Debug.Log(TAG + " Multiplier at game end is " + multiplier);

        achievementTracker.StoreInfo();
    }
    #endregion

    #region Achievement Tracker functions
    public void incrementAppleCaughtAchievement()
    {
        achievementTracker.AddProgressToAchievement("On a Streak", 1.0f);
        achievementTracker.AddProgressToAchievement("First 50", 1.0f);
    }

    public void incrementSuperFrenzyAchievements()
    {
        // Super Frenzy Fanatic
        if (!achievementTracker.Achievements[30].Earned)
        {
            if (LAST_EFFECT == GOLD_EFFECTS.NONE)
            {
                achievementTracker.AddProgressToAchievement("Super Frenzy Fanatic", 1.0f);
            }
            else if (LAST_EFFECT == CURRENT_EFFECT)
            {
                achievementTracker.AddProgressToAchievement("Super Frenzy Fanatic", 1.0f);
            }
            else
            {
                achievementTracker.SetProgressToAchievement("Super Frenzy Fanatic", 0.0f);
            }
        }
        // A Long Shot
        if (!achievementTracker.Achievements[31].Earned)
        {
            if (LAST_EFFECT == GOLD_EFFECTS.NONE)
            {
                achievementTracker.AddProgressToAchievement("A Long Shot", 1.0f);
            }
            else if (LAST_EFFECT == CURRENT_EFFECT)
            {
                achievementTracker.AddProgressToAchievement("A Long Shot", 1.0f);
            }
            else
            {
                achievementTracker.SetProgressToAchievement("A Long Shot", 0.0f);
            }
        }
    }

    public void incementGoldAppleAchievement()
    {
        achievementTracker.AddProgressToAchievement("Goldfinger", 1.0f);
        achievementTracker.AddProgressToAchievement("Gold Basket", 1.0f);
        achievementTracker.AddProgressToAchievement("Golden Goose", 1.0f);
    }
    //		achievementTracker.AddProgressToAchievement ("", 1.0f);

    public void incrementComboAchievements()
    {
        achievementTracker.AddProgressToAchievement("Apple Ninja", 1.0f);
        achievementTracker.AddProgressToAchievement("Combo Fever", 1.0f);
    }

    public void resetStreakAchievements()
    {
        if (!achievementTracker.Achievements[15].Earned)
            achievementTracker.SetProgressToAchievement("Apple Ninja", 0.0f);
        if (!achievementTracker.Achievements[16].Earned)
            achievementTracker.SetProgressToAchievement("Combo Fever", 0.0f);

        if (!achievementTracker.Achievements[2].Earned)
            achievementTracker.SetProgressToAchievement("On a Streak", 0.0f);
        if (!achievementTracker.Achievements[7].Earned)
            achievementTracker.SetProgressToAchievement("First 50", 0.0f);
    }
    #endregion
}