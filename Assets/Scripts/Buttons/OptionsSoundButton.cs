using UnityEngine;
using System.Collections;

public class OptionsSoundButton : MonoBehaviour
{
	UICheckbox checkbox;
	public bool result;
	
	// Use this for initialization
	void Start ()
	{
		checkbox = this.gameObject.GetComponent<UICheckbox>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnClick() {
		if(checkbox.isChecked)
			result = true;
		else
			result = false;
	}
}