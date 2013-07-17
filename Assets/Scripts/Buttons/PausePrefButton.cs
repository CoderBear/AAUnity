using UnityEngine;
using System.Collections;

public class PausePrefButton : MonoBehaviour
{
    public TimerCountdown script;
    public Spawner scriptSpawn;
    public AppleCollider colliderScript;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            script.timerActive = !script.timerActive;
            script.gamePaused = !script.gamePaused;
            script.pause.activatePause = !script.timerActive;

            if (script.gamePaused)
            {
                scriptSpawn.PauseGame();
                script.PauseGame();
                colliderScript.PauseGame();
            }
            else
            {
                scriptSpawn.ResumeGame();
                script.ResumeGame();
                colliderScript.ResumeGame();
            }
        }
    }


    void OnClick()
    {
        script.timerActive = !script.timerActive;
        script.gamePaused = !script.gamePaused;
        script.pause.activatePause = !script.timerActive;

        if (script.gamePaused)
        {
            scriptSpawn.PauseGame();
            script.PausePerfGame();
            colliderScript.PauseGame();
        }
        else
        {
            scriptSpawn.ResumeGame();
            script.ResumePerfGame();
            colliderScript.ResumeGame();
        }
    }
}