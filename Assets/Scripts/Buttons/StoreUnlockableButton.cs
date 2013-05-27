using UnityEngine;
using System.Collections;

public class StoreUnlockableButton : MonoBehaviour
{
	public bool storeUnlockableActive = false;
	public UIPanel powerup, purchase, unlockable, upgrade;
	public UISprite powerupSprite, purchaseSprite, unlockableSprite, upgradeSprite;
	public UIScrollBar powerupScroll, unlockableScroll, upgradeScroll;
	
	void OnClick() {
        storeUnlockableActive = !storeUnlockableActive;

        powerup.gameObject.SetActive(false);
        purchase.gameObject.SetActive(false);
        unlockable.gameObject.SetActive(true);
        upgrade.gameObject.SetActive(false);

        powerupSprite.gameObject.SetActive(false);
        purchaseSprite.gameObject.SetActive(false);
        unlockableSprite.gameObject.SetActive(true);
        upgradeSprite.gameObject.SetActive(false);

        powerupScroll.gameObject.SetActive(false);
        unlockableScroll.gameObject.SetActive(true);
        upgradeScroll.gameObject.SetActive(false);
	}
}