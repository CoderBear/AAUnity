using UnityEngine;
using System.Collections;

public class PausePrefButton : MonoBehaviour
{
	public TimerCountdown script;
	public Spawner scriptSpawn;
	
	void OnClick ()
	{
		script.timerActive = !script.timerActive;
		script.gamePaused = !script.gamePaused;
		script.pause.activatePause = !script.timerActive;
		
		if (script.gamePaused) {
			scriptSpawn.PauseGame ();
			script.PausePerfGame ();
		} else {
			scriptSpawn.ResumeGame ();
			script.ResumePerfGame ();
		}
	}
}