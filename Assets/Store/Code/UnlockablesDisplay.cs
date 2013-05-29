using UnityEngine;
using System.Collections.Generic;

public class UnlockablesDisplay : MonoBehaviour
{
    public UILabel equipText;

    public UILabel costText, buyText;
    public UIButton button, equipButton;
    public UISprite icon, equipOn, equipOff;

    public void allowEquipping()
    {
        // show these after purchase
        equipButton.gameObject.SetActive(true);
        equipText.gameObject.SetActive(true);

        // hide these after purchase
        costText.gameObject.SetActive(false);
        buyText.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        icon.gameObject.SetActive(false);

        // set to unequipped initially
        displayEquipStats(false);
    }

    public void notPurchased()
    {
        // show these after purchase
        equipButton.gameObject.SetActive(false);
        equipText.gameObject.SetActive(false);

        // hide these after purchase
        costText.gameObject.SetActive(true);
        buyText.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        icon.gameObject.SetActive(true);
    }

    public void displayEquipStats(bool result)
    {
        if (result)
        {
            equipOn.gameObject.SetActive(true);
            equipOff.gameObject.SetActive(false);
        }
        else
        {
            equipOn.gameObject.SetActive(false);
            equipOff.gameObject.SetActive(true);
        }
    }
}