using UnityEngine;
using System.Collections;

public class MainMenuAudio : MonoBehaviour {

	private static MainMenuAudio instance;
	
	void Awake() {
        if (MainMenuAudio.instance == null)
        {
            MainMenuAudio.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    void Start()
    {
    }

    public void turnMusicOff()
    {
        this.gameObject.audio.Stop();
        Destroy(this.gameObject);
        MainMenuAudio.instance = null;
    }
	
	void OnApplicationQuit() {
		MainMenuAudio.instance = null;
	}
}