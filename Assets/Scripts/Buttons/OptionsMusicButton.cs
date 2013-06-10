using UnityEngine;
using System.Collections;

public class OptionsMusicButton : MonoBehaviour
{
    UICheckbox checkbox;
    public bool result;
    public optionDB db;

    // Use this for initialization
    void Start()
    {
        checkbox = this.gameObject.GetComponent<UICheckbox>();
        result = checkbox.isChecked;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnClick()
    {
        // if the music is off set to on
        if (checkbox.isChecked)
        {
            result = true;
            MainMenuAudio.Instance.StartInstanceAudio();
            db.setStatus(1, 1);
        }
        else // set the music to off
        {
            result = false;
            MainMenuAudio.Instance.StopInstanceAudio();
            db.setStatus(1, 0);
        }
    }
}