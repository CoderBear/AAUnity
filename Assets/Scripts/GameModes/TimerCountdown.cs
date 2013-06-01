using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;
using EleckTek;
using com.soomla.unity;
using com.soomla.unity.example;

public class TimerCountdown : MonoBehaviour
{
    private const string TAG = "AAUNITY/GAME";

	tk2dTextMesh textMesh;
	public PauseController pause;
	public AudioClip game_end;
	public AchievementTracker tracker;
	public Spawner script;
	public AppleCollider colliderscript;
	
	#region Fields
	
	int restSeconds; // amount of seconds left in counddown
	int roundedRestSeconds; // amount of seconds left in counddown (rounded up)

	public int totalTime;
	public int countDownSeconds; // timelimit for countdown in seconds
	
	public bool timerActive; // determines whether timer is active
	public bool gameOver;
	public bool endSoundPlaying;
	public bool gamePaused;
	public bool audioOn = true;
	
	#endregion
	
	void Awake ()
	{
		timerActive = true;
		gameOver = false;
		endSoundPlaying = false;
		gamePaused = false;
				
		countDownSeconds = 60;
		
		totalTime = 0;
	}
	
	// Use this for initialization
	void Start ()
	{
		string ItemId = AndysApplesAssets.LONGEVITY_GOOD.ItemId;
		int level = StoreInventory.GetGoodUpgradeLevel (ItemId);
		
		textMesh = GetComponent<tk2dTextMesh> ();
		
		switch (colliderscript.GAME_MODE) {
		case AppleCollider.GAME_MODES.FAST_APPLES:
			if (level < 6) {
				countDownSeconds += (5 * level);
			} else {
				countDownSeconds += 25;
			}
            //countDownSeconds = 10;
			textMesh.text = countDownSeconds.ToString ();
			break;
		case AppleCollider.GAME_MODES.PERFECTIONIST:
			textMesh.text = colliderscript.lifeCounter.ToString ();
			break;
		}
		
		textMesh.Commit ();
		
		if (game_end != null && audio == null) {
			AudioSource source = gameObject.AddComponent<AudioSource> ();
			source.playOnAwake = false;
		}
		
		if (timerActive) {
			switch (colliderscript.GAME_MODE) {
			case AppleCollider.GAME_MODES.FAST_APPLES:
				InvokeRepeating ("InitiateCountdown", 0.0f, 1.0f);
				break;
			case AppleCollider.GAME_MODES.PERFECTIONIST:
				InvokeRepeating ("TimeGame", 0.0f, 1.0f);
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (colliderscript.GAME_MODE) {
		case AppleCollider.GAME_MODES.FAST_APPLES:
			if (countDownSeconds == 0 && !gameOver) {
				timerActive = false;
				gameOver = true;
				script.PauseGame ();
				pause.activatePause = !timerActive;
				PauseGame ();
			}
			break;
		case AppleCollider.GAME_MODES.PERFECTIONIST:
//			Debug.Log("AAUNITY/GAME LifeCounter = " + colliderscript.lifeCounter);
//			Debug.Log ("AAUNITY/GAME (colliderscript.lifeCounter == 0 && !gameOver) is " + (colliderscript.lifeCounter == 0 && !gameOver));
			if (colliderscript.lifeCounter == 0 && !gameOver) {
				Debug.Log ("AAUNITY/GAME Ending Game");
				timerActive = false;
				gameOver = true;
				script.PauseGame ();
				pause.activatePause = !timerActive;
				PausePerfGame ();
			}
			break;
		}
		
		if (!endSoundPlaying && restSeconds == 5) {
			if (audioOn) {
				Debug.Log("AAUNITY/GAME endSoundPlaying is " + endSoundPlaying);
				PlaySound (game_end);
				endSoundPlaying = true;
			}
		}
				
		if (timerActive) {
			if (!tracker.Achievements [10].Earned)
				tracker.AddProgressToAchievement ("All Nighter", Time.deltaTime);
		}
	}
	
	void TimeGame ()
	{
		totalTime++;
	}
	
	void InitiateCountdown ()
	{
		// Make sure that your time is based on ** when the script is first called**
		// instead of when your game started
        totalTime++;
		countDownSeconds--;
		restSeconds = countDownSeconds;
		
		// display the timer
		roundedRestSeconds = Mathf.CeilToInt (restSeconds);
		roundedRestSeconds = Mathf.Clamp (roundedRestSeconds, 0, roundedRestSeconds);
		
		DisplayCountdown ();
	}
		
	void DisplayCountdown ()
	{
		textMesh.text = roundedRestSeconds.ToString ();
		// This is important, your changes will not be updated until you call Commit()
		// This is so you can change multiple parameters without reconstructing
		// the mesh repeatedly
		textMesh.Commit ();
	}
	
	public void DisplayTimer ()
	{
		restSeconds = countDownSeconds;
		
		// display the timer
		roundedRestSeconds = Mathf.CeilToInt (restSeconds);
		roundedRestSeconds = Mathf.Clamp (roundedRestSeconds, 0, roundedRestSeconds);
		
		DisplayCountdown ();
	}

    public void resetTimer()
    {
        //PauseGame();
        string ItemId = AndysApplesAssets.LONGEVITY_GOOD.ItemId;
        int level = StoreInventory.GetGoodUpgradeLevel(ItemId);
        endSoundPlaying = !endSoundPlaying;

        AndyUtils.LogDebug(TAG, "Setting time to default");
        countDownSeconds = 60;

        if (level < 6)
        {
            countDownSeconds += (5 * level);
        }
        else
        {
            countDownSeconds += 25;
        }
        AndyUtils.LogDebug(TAG, "CountdownSeconds are now " + countDownSeconds);

        DisplayTimer();
        //ResumeGame();
    }
	
	void OnClick ()
	{
		timerActive = !timerActive;
		gamePaused = !gamePaused;
	}
	
	void PlaySound (AudioClip source)
	{
		if (audio && source) {
			audio.PlayOneShot (source);
		}
	}

	#region Pause/Resume Game Functions
	public void PauseGame ()
	{
		if (!timerActive) {
//			Debug.Log ("AAUNITY/GAME Pausing Timer");
			CancelInvoke ("InitiateCountdown");
		}
	}
	
	public void ResumeGame ()
	{
		if (timerActive) {
			Debug.Log ("AAUNITY/GAME Resuming Timer");
			InvokeRepeating ("InitiateCountdown", 0.0f, 1.0f);
		}
	}
	
	public void PausePerfGame ()
	{
		if (!timerActive) {
//			Debug.Log ("Perfectionist Paused");
			CancelInvoke ("TimeGame");
		}
	}
	
	public void ResumePerfGame ()
	{
		if (timerActive) {
			Debug.Log ("Perfectionist Resumed");
			InvokeRepeating ("TimeGame", 0.0f, 1.0f);
		}
	}
	#endregion
	
	public int getRestSeconds ()
	{
		return roundedRestSeconds;
	}
}