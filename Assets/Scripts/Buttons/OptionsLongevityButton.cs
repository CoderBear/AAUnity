using UnityEngine;
using System.Collections;

public class OptionsLongevityButton : MonoBehaviour {

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
        // if longevity is off set to on
        if (checkbox.isChecked)
        {
            result = true;
            db.setStatus(3, 1);
        }
        else // set longevity to off
        {
            result = false;
            db.setStatus(3, 0);
        }
    }
}