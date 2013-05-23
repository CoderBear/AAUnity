using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {

	void OnClick() {
		Debug.Log("Help Button Pressed");
		Application.LoadLevel("HelpMenu");
	}
}