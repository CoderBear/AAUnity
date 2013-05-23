using UnityEngine;
using System.Collections;

public class StorePurchaseButton : MonoBehaviour
{
	public bool storePurchaseActive = false;
	public UIPanel powerup, purchase, unlockable, upgrade;
	public UISprite powerupSprite, purchaseSprite, unlockableSprite, upgradeSprite;
	public UIScrollBar powerupScroll, unlockableScroll, upgradeScroll;
	
	void OnClick() {
		storePurchaseActive = !storePurchaseActive;
		
		powerup.gameObject.SetActive(false);
		purchase.gameObject.SetActive(true);
		unlockable.gameObject.SetActive(false);
		upgrade.gameObject.SetActive(false);
		
		powerupSprite.gameObject.SetActive(false);
		purchaseSprite.gameObject.SetActive(true);
		unlockableSprite.gameObject.SetActive(false);
		upgradeSprite.gameObject.SetActive(false);
		
		powerupScroll.gameObject.SetActive(false);
		unlockableScroll.gameObject.SetActive(false);
		upgradeScroll.gameObject.SetActive(false);
	}
}