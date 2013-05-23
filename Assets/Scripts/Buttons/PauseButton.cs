using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{
	public TimerCountdown script;
	public Spawner scriptSpawn;
	
	void OnClick ()
	{
		if (script.getRestSeconds () > 1) {
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