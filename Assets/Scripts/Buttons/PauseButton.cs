using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{
	public TimerCountdown script;
	public Spawner scriptSpawn;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (script.getRestSeconds() > 1 && !script.gameOver)
            {
                script.timerActive = !script.timerActive;
                script.gamePaused = !script.gamePaused;
                script.pause.activatePause = !script.timerActive;

                if (script.gamePaused)
                {
                    scriptSpawn.PauseGame();
                    script.PauseGame();
                }
                else
                {
                    scriptSpawn.ResumeGame();
                    script.ResumeGame();
                }
            }
        }
    }
	
	void OnClick ()
	{
		if (script.getRestSeconds () > 1 && !script.gameOver) {
			script.timerActive = !script.timerActive;
			script.gamePaused = !script.gamePaused;
			script.pause.activatePause = !script.timerActive;
		
			if (script.gamePaused) {
				scriptSpawn.PauseGame ();
				script.PauseGame();
			} else {
				scriptSpawn.ResumeGame ();
				script.ResumeGame();
			}
		}
	}
}