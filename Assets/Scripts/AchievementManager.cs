using System.Linq;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Achievement
{
    public string Name;
    public string Description;
    public int RewardPoints;
    public float TargetProgress;
    public bool Secret;

    [HideInInspector]
    public bool Earned = false;
    private float currentProgress = 0.0f;

    public float getProgress() { return currentProgress; }

    public bool AddProgress(float progress)
    {
        if (Earned)
        {
            return false;
        }

        currentProgress += progress;
        if (currentProgress >= TargetProgress)
        {
            Earned = true;
            return true;
        }

        return false;
    }

    public bool SetProgress(float progress)
    {
        if (Earned)
        {
            return false;
        }

        currentProgress = progress;
        if (progress >= TargetProgress)
        {
            Earned = true;
            return true;
        }

        return false;
    }
}

public class AchievementManager : MonoBehaviour
{
	public AchieveDB db;
	
	string filename;
	
    public Achievement[] Achievements;
    public AudioClip EarnedSound;
	
	/*--- NGUI Elements ---*/
	public UIDraggablePanel MasterDragPanel;
	UIGrid MasterGrid;
	UIDragPanelContents dragPanelContents;
	public GameObject achievePrefab;

    private int currentRewardPoints = 0;
    private int potentialRewardPoints = 0;
	
	void Start()
	{			
		MasterGrid = this.transform.GetComponent<UIGrid>();
		AchievementDisplay display = achievePrefab.GetComponent<AchievementDisplay>();
		GameObject newAchievementObj = null;
		
		for (int j = 0; j < Achievements.Length; j++) {
			//Fill achievements with current info
			Debug.Log ("AAUNITY/ACHIEVEMENT Achievement " + Achievements[j].Name + " is unlocked=" + db.isUnlocked(j+1));
			if(db.isUnlocked(j+1)) {
				Debug.Log("AAUNITY/ACHIEVEMENT Now set setting " + Achievements[j].Name + " to full progress of " + Achievements[j].TargetProgress);
				Achievements[j].SetProgress(Achievements[j].TargetProgress);
			}
			if(j >= 39 || (j >= 27 && j <= 29)) //for store and lifetime achievements show current progress
				Achievements[j].SetProgress((float)db.getProgress(j+1));
			
			// Get UI Label for name in child obj and set it to Achievments[j].name
			// Do this for description, points, and target
			display.nameLabel.text = Achievements[j].Name;
			display.descriptionLabel.text = Achievements[j].Description;
			display.targetLabel.text = Achievements[j].getProgress().ToString() + " / " + Achievements[j].TargetProgress.ToString();
			
			Debug.Log ("AAUNITY/ACHIEVEMENT Achievement " + Achievements[j].Name + " is Earned? " + Achievements[j].Earned);
			if(Achievements[j].Earned) {
				display.earned.SetActive(true);
				display.unearned.SetActive(false);
			} else {
				display.earned.SetActive(false);
				display.unearned.SetActive(true);
			}
			dragPanelContents = achievePrefab.GetComponent<UIDragPanelContents>();
			dragPanelContents.draggablePanel = MasterDragPanel;
			
			newAchievementObj = NGUITools.AddChild(MasterGrid.gameObject, achievePrefab.gameObject);
		}
		
		MasterGrid.Reposition();
		
	    ValidateAchievements();
        UpdateRewardPointTotals();
	}
	
    // Make sure the setup assumptions we have are met.
    private void ValidateAchievements()
    {
        ArrayList usedNames = new ArrayList();
        foreach (Achievement achievement in Achievements)
        {
            if (achievement.RewardPoints < 0)
            {
                Debug.LogError("AchievementManager::ValidateAchievements() - Achievement with negative RewardPoints! " + achievement.Name + " gives " + achievement.RewardPoints + " points!");
            }

            if (usedNames.Contains(achievement.Name))
            {
                Debug.LogError("AchievementManager::ValidateAchievements() - Duplicate achievement names! " + achievement.Name + " found more than once!");
            }
            usedNames.Add(achievement.Name);
        }
    }

    private Achievement GetAchievementByName(string achievementName)
    {
        return Achievements.FirstOrDefault(achievement => achievement.Name == achievementName);
    }

    private void UpdateRewardPointTotals()
    {
        currentRewardPoints = 0;
        potentialRewardPoints = 0;

        foreach (Achievement achievement in Achievements)
        {
            if (achievement.Earned)
            {
                currentRewardPoints += achievement.RewardPoints;
            }

            potentialRewardPoints += achievement.RewardPoints;
        }
    }

    private void AchievementEarned()
    {
        UpdateRewardPointTotals();
        AudioSource.PlayClipAtPoint(EarnedSound, Camera.main.transform.position);        
    }

    public void AddProgressToAchievement(string achievementName, float progressAmount)
    {
        Achievement achievement = GetAchievementByName(achievementName);
        if (achievement == null)
        {
            Debug.LogWarning("AchievementManager::AddProgressToAchievement() - Trying to add progress to an achievemnet that doesn't exist: " + achievementName);
            return;
        }

        if (achievement.AddProgress(progressAmount))
        {
            AchievementEarned();
        }
    }

    public void SetProgressToAchievement(string achievementName, float newProgress)
    {
        Achievement achievement = GetAchievementByName(achievementName);
        if (achievement == null)
        {
            Debug.LogWarning("AchievementManager::SetProgressToAchievement() - Trying to add progress to an achievemnet that doesn't exist: " + achievementName);
            return;
        }

        if (achievement.SetProgress(newProgress))
        {
            AchievementEarned();
        }
    }
}