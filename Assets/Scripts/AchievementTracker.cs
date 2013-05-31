using System.Linq;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class AchievementTrack
{
	public string Name;
	public string Description;
	public int RewardPoints;
	public float TargetProgress;
	public bool Secret;
	[HideInInspector]
	public bool Earned = false;
	private float currentProgress = 0.0f;
	
	public float getProgress ()
	{
		return currentProgress;
	}
	
	public bool AddProgress (float progress)
	{
		if (Earned) {
			return false;
		}

		currentProgress += progress;
        //if(Name != "All Nighter")
//			Debug.Log("AAUNITY/GAME " + Name + ": " + currentProgress + " / " + TargetProgress);
		if (currentProgress >= TargetProgress) {
			Earned = true;
			return true;
		}

		return false;
	}

	public bool SetProgress (float progress)
	{
		if (Earned) {
			return false;
		}

		currentProgress = progress;
		if (progress >= TargetProgress) {
			Earned = true;
			return true;
		}

		return false;
	}
}

public class AchievementTracker : MonoBehaviour
{
	public AchieveDB db;
	public AchievementTrack[] Achievements;
	
	private int currentRewardPoints = 0;
	private int potentialRewardPoints = 0;
	
	public int getRewardPoints() { return currentRewardPoints; }
	
	void Awake() {
	}
	
	void Start ()
	{
		for(int i = 0; i < Achievements.Length; i++) {
			Achievements[i].Name = db.getName(i + 1);
			Achievements[i].Description = db.getDesc(i + 1);
			Achievements[i].TargetProgress = (float)db.getTarget(i + 1);
//			Debug.Log(i + " Name: " + Achievements[i].Name + ", Target = " + db.getTarget(i+1) );
			if(db.getProgress(i + 1) > 0)
				Achievements[i].SetProgress((float)db.getProgress(i + 1));
		}
		
		ValidateAchievements ();
		UpdateRewardPointTotals ();
	}
	
	// Make sure the setup assumptions we have are met.
	private void ValidateAchievements ()
	{
		ArrayList usedNames = new ArrayList ();
		foreach (AchievementTrack achievement in Achievements) {
			if (achievement.RewardPoints < 0) {
				Debug.LogError ("AchievementManager::ValidateAchievements() - Achievement with negative RewardPoints! " + achievement.Name + " gives " + achievement.RewardPoints + " points!");
			}

			if (usedNames.Contains (achievement.Name)) {
				Debug.LogError ("AchievementManager::ValidateAchievements() - Duplicate achievement names! " + achievement.Name + " found more than once!");
			}
			usedNames.Add (achievement.Name);
		}
	}

	private AchievementTrack GetAchievementByName (string achievementName)
	{
		return Achievements.FirstOrDefault (achievement => achievement.Name == achievementName);
	}

	private void UpdateRewardPointTotals ()
	{
		currentRewardPoints = 0;
		potentialRewardPoints = 0;

		foreach (AchievementTrack achievement in Achievements) {
			if (achievement.Earned) {
				currentRewardPoints += achievement.RewardPoints;
			}

			potentialRewardPoints += achievement.RewardPoints;
		}
	}

	private void AchievementEarned ()
	{
		UpdateRewardPointTotals ();
	}

	public void AddProgressToAchievement (string achievementName, float progressAmount)
	{
		AchievementTrack achievement = GetAchievementByName (achievementName);
		if (achievement == null) {
			Debug.LogWarning ("AchievementManager::AddProgressToAchievement() - Trying to add progress to an achievemnet that doesn't exist: " + achievementName);
			return;
		}

		if (achievement.AddProgress (progressAmount)) {
			AchievementEarned ();
		}
	}

	public void SetProgressToAchievement (string achievementName, float newProgress)
	{
		AchievementTrack achievement = GetAchievementByName (achievementName);
		if (achievement == null) {
			Debug.LogWarning ("AchievementManager::SetProgressToAchievement() - Trying to add progress to an achievemnet that doesn't exist: " + achievementName);
			return;
		}

		if (achievement.SetProgress (newProgress)) {
			AchievementEarned ();
		}
	}

    public void StoreIAPprogress() {
        if (Achievements[27].Earned) // Straight A's
        {
            db.unlock(28);
            db.StoreProgress(28, (int)Achievements[27].getProgress());
        }
        else
        {
            db.StoreProgress(28, (int)Achievements[27].getProgress());
        }

        if (Achievements[28].Earned) // The Starting Lineup
        {
            db.unlock(29);
            db.StoreProgress(29, (int)Achievements[28].getProgress());
        }
        else
        {
            db.StoreProgress(29, (int)Achievements[28].getProgress());
        }

        if (Achievements[29].Earned) // Change of Scenery
        {
            db.unlock(30);
            db.StoreProgress(30, (int)Achievements[29].getProgress());
        }
    }
	
	public void StoreInfo ()
	{
		for (int i = 0; i < Achievements.Length; i++) {
			// unlock achievement if not already unlocked in database
			if (Achievements [i].Earned && !db.isUnlocked(i + 1) && (i != 27 || i != 28 || i != 29)) {
				db.unlock (i + 1);
				db.StoreProgress(i + 1, (int)Achievements[i].getProgress());
			}
			
			switch (i) {
			case 39: // Mr. Clean Basket
				db.StoreProgress(i + 1,(int)Achievements[i].getProgress());
				break;
			case 40: // A tad insane
				db.StoreProgress(i + 1,(int)Achievements[i].getProgress());
				break;
			case 41: // Mr. Bateman
				db.StoreProgress(i + 1,(int)Achievements[i].getProgress());
				break;
			case 42: // Apple Lover
				db.StoreProgress(i + 1,(int)Achievements[i].getProgress());
				break;
			case 43: // Apple Champion
				db.StoreProgress(i + 1,(int)Achievements[i].getProgress());
				break;
			case 44: // Prime Time
				db.StoreProgress(i + 1,(int)Achievements[i].getProgress());
				break;
			default:
				break;
			}
		}
	}
}