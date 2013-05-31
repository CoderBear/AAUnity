using UnityEngine;
using System.Collections;

public class EquipButton : MonoBehaviour {

    private const string TAG = "AAUNITY/SOOMLA";
    public Store store;

    void OnClick()
    {
        // Unlockable - Skin goods
        if (this.gameObject.tag == "Skin1")
        {
            AndyUtils.LogDebug(TAG, "EquipAndy Pressed");
            store.EquipAndy();
        }
        else if (this.gameObject.tag == "Skin2")
        {
            AndyUtils.LogDebug(TAG, "EquipKelly Pressed");
            store.EquipKelly();
        }
        else if (this.gameObject.tag == "Skin3")
        {
            AndyUtils.LogDebug(TAG, "EquipNinja Pressed");
            store.EquipNinja();
        }
        else if (this.gameObject.tag == "Skin4")
        {
            AndyUtils.LogDebug(TAG, "EquipPig Pressed");
            store.EquipPig();
        }
        else if (this.gameObject.tag == "Skin5")
        {
            AndyUtils.LogDebug(TAG, "EquipPirate Pressed");
            store.EquipPirate();
        }
        else if (this.gameObject.tag == "Skin6")
        {
            AndyUtils.LogDebug(TAG, "EquipWizard Pressed");
            store.EquipWizard();
        }
        // Unlockable - Background 
        if (this.gameObject.tag == "Background1")
        {
            AndyUtils.LogDebug(TAG, "EquipDefaultBG Pressed");
            store.EquipDefaultBG();
        }

        if (this.gameObject.tag == "Background2")
        {
            AndyUtils.LogDebug(TAG, "EquipBlossomBG Pressed");
            store.EquipBlossomBG();
        }
    }
}