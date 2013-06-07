using UnityEngine;
using System.Collections;

public class OptionsGEButton : MonoBehaviour {

    UICheckbox checkbox;
    public bool result;
    public optionDB db;

	// Use this for initialization
	void Start () {
        checkbox = this.gameObject.GetComponent<UICheckbox>();
        result = checkbox.isChecked;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        // if Gold Effects are off set to on
        if (checkbox.isChecked)
        {
            result = true;
            db.setStatus(4, 1);
        }
        else // set Gold Effects to off
        {
            result = false;
            db.setStatus(4, 0);
        }
    }
}