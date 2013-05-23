using UnityEngine;
using System.Collections;

public class StoreUpgradeButton : MonoBehaviour
{
	public bool storeUpgradeActive = false;
	public UIPanel powerup, purchase, unlockable, upgrade;
	public UISprite powerupSprite, purchaseSprite, unlockableSprite, upgradeSprite;
	public UIScrollBar powerupScroll, unlockableScroll, upgradeScroll;
	
	void OnClick() {
		storeUpgradeActive = !storeUpgradeActive;
		
		powerup.gameObject.SetActive(false);
		purchase.gameObject.SetActive(false);
		unlockable.gameObject.SetActive(false);
		upgrade.gameObject.SetActive(true);
		
		powerupSprite.gameObject.SetActive(false);
		purchaseSprite.gameObject.SetActive(false);
		unlockableSprite.gameObject.SetActive(false);
		upgradeSprite.gameObject.SetActive(true);
		
		powerupScroll.gameObject.SetActive(false);
		unlockableScroll.gameObject.SetActive(false);
		upgradeScroll.gameObject.SetActive(true);
	}
}