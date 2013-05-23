using UnityEngine;
using System.Collections;

public class HelpWindow : MonoBehaviour {
	
	public GUISkin customSkin;
	
	private Rect r_window = new Rect (0, 0, 1280, 720);
	private Rect r_backButton = new Rect (550,642,169,78);
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI() {
		GUI.skin = customSkin;
		
		this.r_window = GUI.Window (0, this.r_window, new GUI.WindowFunction (this.DoMyWindow), string.Empty);

		this.r_window.x = Mathf.Clamp (this.r_window.x, 0, Screen.width - this.r_window.width);
		this.r_window.y = Mathf.Clamp (this.r_window.y, 0, Screen.height - this.r_window.height);
	}
	
	private void DoMyWindow(int windowID) {
		if (GUI.Button(r_backButton, string.Empty, GUI.skin.GetStyle("button"))) {
			Debug.Log ("Back Button Pressed");
			Application.LoadLevel("AAMainMenu"); // Load Main Menu
		}
	}
}