using UnityEngine;
using System.Collections;

public class OptionsMusicButton : MonoBehaviour
{
	UICheckbox checkbox;
	public bool result;
	
	// Use this for initialization
	void Start ()
	{
		checkbox = this.gameObject.GetComponent<UICheckbox>();
		result = checkbox.isChecked;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnClick() {
		// if the music is off set to on
		if(checkbox.isChecked)
			result = true;
		else // set the music to on
			result = false;
	}
}