using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

	void OnClick() {
		Debug.Log("Exit Button Pressed");
		Application.Quit();
	}
}