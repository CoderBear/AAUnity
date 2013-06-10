using UnityEngine;
using System.Collections;

public class MainMenuAudio : MonoBehaviour
{
    private const string TAG = "AAUNITY/MAIN_MENU";
    private static MainMenuAudio instance;

    public static MainMenuAudio Instance
    {
        get { return instance; }
    }

    public static bool isObjectActive = false;

    void Awake()
    {
        AndyUtils.LogDebug(TAG, "(instance != null && instance != this) is " + (instance != null && instance != this));
        if (instance != null && instance != this)
        {
            AndyUtils.LogDebug(TAG, "Destorying Object");
            Destroy(this.gameObject);
            AndyUtils.LogDebug(TAG, "Object Destroyed");
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
    }

    public void StopInstanceAudio()
    {
        instance.audio.Stop();
    }

    public void StartInstanceAudio()
    {
        instance.audio.Play();
    }

    public void turnMusicOff()
    {
        AndyUtils.LogDebug(TAG, "instance is " + instance.ToString());
        AndyUtils.LogDebug(TAG, "instance.gameObject is " + instance.gameObject.ToString());
        AndyUtils.LogDebug(TAG, "(instance != null) is " + (instance != null));
        if (instance != null)
        {
            AndyUtils.LogDebug(TAG, "!isObjectActive is " + !isObjectActive);
            if (!isObjectActive)
            {
                AndyUtils.LogDebug(TAG, "gameObject is " + this.gameObject.ToString());
                AndyUtils.LogDebug(TAG, "(this.gameObject != null) is " + (this.gameObject != null));
                Destroy(this.gameObject);
            }
            else
            {
                if (instance.audio.isPlaying)
                    instance.audio.Stop();
                Destroy(instance.gameObject);
            }
            instance = null;
            isObjectActive = false;
        }
    }

    void OnApplicationQuit()
    {
        instance = null;
    }
}