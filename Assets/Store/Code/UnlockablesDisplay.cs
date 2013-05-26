using UnityEngine;
using System.Collections.Generic;

public class UnlockablesDisplay : MonoBehaviour
{
    public UICheckbox equipCheck;
    public UILabel equipText;

    public UILabel costText, buyText;
    public UIButton button;
    public UISprite icon;

    public void allowEquipping()
    {
        // show these after purchase
        equipCheck.gameObject.SetActive(true);
        equipText.gameObject.SetActive(true);

        // hide these after purchase
        costText.gameObject.SetActive(false);
        buyText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        icon.gameObject.SetActive(false);
    }
}