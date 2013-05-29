using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class AppleCollider : MonoBehaviour
{
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
    //public GameObject shieldHitAnim;
    public AudioClip caughtGood;
    public AudioClip caughtGold;
    public AudioClip caughtBad;
    public AudioClip combo_increased;
    public bool comboIncreased, goldEffectActive, newHighscore, comboIncremented, caught;
    private int score, comboCount, combo;
    public int highscore, gameNum, displayedScore;
    public int lifeCounter;
    public bool audioOn;
    TouchSense touchsense;
    private bool firstCatch = true, firstGame = true;

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

    int pinkCaught, rottenCaught, goldCaught;
    int multiplier, effectTimer;
    AndroidJavaObject activity;
    AndroidJavaObject mWindowManager;
    bool result;

    // Automatically run when a game starts
    void Awake()
    {
        GM_INDEX = (int)GAME_MODE;

        script = transform.parent.GetComponent<playerAnimController>();
        score = int.Parse(textScore.text);
        combo = int.Parse(comboText.text);

        switch (Application.loadedLevel)
        {
            case 3: // Fast Apples
                gameNum = db.getValue("fa_games");
                Debug.Log("AAUNITY/GAME Fast Apples games played: " + gameNum);
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
                timerText.text = lifeCounter.ToString();
                timerText.Commit();
                gameNum = db.getValue("p_games");
                Debug.Log("AAUNITY/GAME Perfectionist games played: " + gameNum);
                if (gameNum > 0)
                {
                    firstGame = false;
                    highscore = db.getValue("p_gamescore");
                }
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR		
		if (mWindowManager == null) {
			using (AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").
                            GetStatic<AndroidJavaObject>("currentActivity")) {
				mWindowManager = activity.Call<AndroidJavaObject> ("getSystemService", "sensor");
			}
		}
		result = mWindowManager.Call<bool> ("hasVibrator");
		touchsense = TouchSense.instance;
#endif

        totalGameCombos = 0;
        displayedScore = 0;
        caughtApples = 0;

        comboIncreased = false;
        comboIncremented = false;

        caught = false;

        multiplier = achievementTracker.getRewardPoints();

        effectTimer = 5;

        newHighscore = false;

        goldEffectActive = false;

        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        GameObject ColGO = collision.gameObject;
        Destroy(ColGO);

        if (timerScript.timerActive)
        {
            if (ColGO.tag == "NormalApple")
            {
                //#if UNITY_ANDROID && !UNITY_EDITOR
                //				if(result)
                //				touchsense.playBuiltinEffect (TouchSense.IMPACT_WOOD_33);
                //#endif
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
                //#if UNITY_ANDROID && !UNITY_EDITOR
                //				touchsense.stopPlayingBuiltinEffect ();
                //#endif
            }
            if (ColGO.tag == "ComboApple")
            {
                //#if UNITY_ANDROID && !UNITY_EDITOR
                //				if(result)
                //				touchsense.playBuiltinEffect (TouchSense.IMPACT_WOOD_66);
                //#endif
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
                //#if UNITY_ANDROID && !UNITY_EDITOR
                //				touchsense.stopPlayingBuiltinEffect ();
                //#endif
            }
            if (ColGO.tag == "GoldApple")
            {
#if UNITY_ANDROID && !UNITY_EDITOR
				if(result)
				touchsense.playBuiltinEffect (TouchSense.IMPACT_WOOD_100);
#endif
                Debug.Log("AAUNITY/GAME Gold Apple Caught");
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
                    Debug.Log("AAUNITY/GAME Now activating Gold Effect");
                    activateEffect();
                }
            }
            //			Debug.Log("AAUNITY/GAME !firstGame is " + !firstGame);
            if (!firstGame)
            {
                //				Debug.Log("AAUNITY/GAME !newHighscore is " + !newHighscore);
                if (!newHighscore)
                {
                    //					Debug.Log("AAUNITY/GAME (displayedScore > highscore) is " + (displayedScore > highscore));
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

#if UNITY_ANDROID && !UNITY_EDITOR && !UNITY_EDITOR
			if(result)
			touchsense.stopPlayingBuiltinEffect ();
#endif
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //Transform position = collision.gameObject.transform;
#if UNITY_ANDROID && !UNITY_EDITOR
		if(result)
		touchsense.playBuiltinEffect (TouchSense.EXPLOSION1);
#endif
        Destroy(collision.gameObject);
        if (audioOn)
            audio.PlayOneShot(caughtBad);

        //Vector3 loc = position.position + new Vector3(0, -100, 0);

        //Debug.Log("AAUNITY/GAME Basket Collide | Animation " + shieldHitAnim.name + " play at " + position.ToString());
        //Instantiate(shieldHitAnim, position.position, Quaternion.identity);

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
#if UNITY_ANDROID && !UNITY_EDITOR
		if(result)
		touchsense.stopPlayingBuiltinEffect ();
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
            //Debug.Log("AAUNITY/GAME Current combo count: " + comboCount);
        }
        else if (comboCount == 2)
        {
            if (audioOn)
                audio.PlayOneShot(combo_increased);
            comboIncreased = true;
            combo++;
            totalGameCombos++;
            comboCount = 0;
            //Debug.Log("AAUNITY/GAME Current combo total: " + combo);
            //Debug.Log("AAUNITY/GAME Current game combo total: " + totalGameCombos);

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

    /*--- Gold Effect Methods ---*/
    #region Gold Effects Functions
    private void activateEffect()
    {
        string itemId = "";
        goldEffectActive = true;
        MersenneTwister random = new MersenneTwister();
        int index = random.Next(1,5);
        if (firstCatch)
        {
            firstCatch = !firstCatch;
            if (effectTimer == 0) effectTimer = 5;
            switch (index)
            {
                case 1:
                    Debug.Log("AAUNITY/GAME Index " + index + ": Frenzy");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Frenzy");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
                case 2:
                    Debug.Log("AAUNITY/GAME Index " + index + ": Super Frenzy");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Super Frenzy");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
                case 3:
                    Debug.Log("AAUNITY/GAME Index " + index + ": Double Points");
                    animGold.gameObject.SetActive(true);
                    animGold.Play("Double");

                    // The delegate is used here to return to the previously
                    // playing clip after the "hit" animation is done playing.
                    animGold.animationCompleteDelegate = AnimFinishedDelegate;
                    break;
                case 4:
                    Debug.Log("AAUNITY/GAME Index " + index + ": Repellent");
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
                Debug.Log("AAUNITY/GAME Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.FRENZY;
                Debug.Log("AAUNITY/GAME Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.FRENZY_GOOD.ItemId;
                break;
            case 2: // Super Frenzy
                Debug.Log("AAUNITY/GAME Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.SUPERFRENZY;
                Debug.Log("AAUNITY/GAME Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.SUPER_GOOD.ItemId;
                break;
            case 3: // Double Points
                Debug.Log("AAUNITY/GAME Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.DOUBLE;
                Debug.Log("AAUNITY/GAME Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.DOUBLE_GOOD.ItemId;
                break;
            case 4: // Repellent
                Debug.Log("AAUNITY/GAME Current Effect Before:" + CURRENT_EFFECT);
                CURRENT_EFFECT = GOLD_EFFECTS.REPEL;
                Debug.Log("AAUNITY/GAME Current Effect After:" + CURRENT_EFFECT);
                itemId = AndysApplesAssets.REPELLENT_GOOD.ItemId;
                break;
        }
        Debug.Log("AAUNITY/GAME now adding to achievements");
        achievementTracker.AddProgressToAchievement("Gold Standard", 1.0f);

        GE_INDEX = index;
        Debug.Log("AAUNITY/GAME now switching on/ Gold effect");
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

        Debug.Log("AAUNITY/GAME Effect timer length for Gold Effect " + CURRENT_EFFECT + " is " + effectTimer + " seconds.");

        Invoke("deactivateEffect", (float)effectTimer);
    }

    public void deactivateEffect()
    {
        GE_INDEX = 0;
        LAST_EFFECT = CURRENT_EFFECT;
        CURRENT_EFFECT = GOLD_EFFECTS.NONE;
        goldEffectActive = false;
        effectTimer = 5;
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
                        db.StoreValue(6, (int)timerScript.totalTime);
                }
                else
                {
                    db.StoreValue(2, caughtApples); // lifetime apples
                    db.StoreValue(3, 1); // lifetime games
                    db.StoreValue(5, 1); // fast apple_games
                    db.StoreValue(4, caughtApples);
                    db.StoreValue(9, displayedScore);
                    db.StoreValue(7, totalGameCombos);
                    db.StoreValue(8, totalGameCombos);
                    db.StoreValue(6, (int)timerScript.totalTime);
                }
                break;
            case GAME_MODES.PERFECTIONIST:
                achievementTracker.AddProgressToAchievement("A Tad Insane", 1.0f);
                achievementTracker.AddProgressToAchievement("Mr. Clean Basket", 1.0f);
                achievementTracker.AddProgressToAchievement("Mr. Bateman", 1.0f);

                if (db.getValue("fa_games") != 0)
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
                        db.StoreValue(12, (int)timerScript.totalTime);
                }
                else
                {
                    db.StoreValue(2, caughtApples); // lifetime apples
                    db.StoreValue(3, 1); // lifetime games
                    db.StoreValue(11, 1); // perfectionist_games
                    db.StoreValue(10, caughtApples);
                    db.StoreValue(15, displayedScore);
                    db.StoreValue(13, totalGameCombos);
                    db.StoreValue(14, totalGameCombos);
                    db.StoreValue(12, (int)timerScript.totalTime);
                }
                break;
        }

        // Games Played Achievements
        achievementTracker.AddProgressToAchievement("Prime Time", 1.0f);

        db.StoreValue(1, achievementTracker.getRewardPoints()); // multiplier
        multiplier = achievementTracker.getRewardPoints();

        achievementTracker.StoreInfo();
    }
    #endregion

    #region Achievement Tracker functions
    public void incrementAppleCaughtAchievement()
    {
        achievementTracker.AddProgressToAchievement("On a Streak", 1.0f);
        achievementTracker.AddProgressToAchievement("First public void 50", 1.0f);
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