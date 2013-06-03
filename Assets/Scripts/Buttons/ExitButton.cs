using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	void OnClick() {
		Debug.Log("Exit Button Pressed");
		Application.Quit();
	}
}