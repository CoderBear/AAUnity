using UnityEngine;
using System.Collections;

public class EquipButton : MonoBehaviour {

    public Store store;

    void OnClick()
    {
        // Unlockable - Skin goods
        if (this.gameObject.tag == "Skin1")
        {
            store.EquipAndy();
        }
        else if (this.gameObject.tag == "Skin2")
        {
            store.EquipKelly();
        }
        else if (this.gameObject.tag == "Skin3")
        {
            store.EquipNinja();
        }
        else if (this.gameObject.tag == "Skin4")
        {
            store.EquipPig();
        }
        else if (this.gameObject.tag == "Skin5")
        {
            store.EquipPirate();
        }
        else if (this.gameObject.tag == "Skin6")
        {
            store.EquipWizard();
        }
        // Unlockable - Background 
        if (this.gameObject.tag == "Background")
        {
        }
    }
}