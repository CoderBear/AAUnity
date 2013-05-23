using UnityEngine;
using System.Collections;

public class StorePowerupButton : MonoBehaviour
{
	public bool storePowerupActive = false;
	public UIPanel powerup, purchase, unlockable, upgrade;
	public UISprite powerupSprite, purchaseSprite, unlockableSprite, upgradeSprite;
	public UIScrollBar powerupScroll, unlockableScroll, upgradeScroll;
	
	void OnClick() {
		storePowerupActive = !storePowerupActive;
		
		powerup.gameObject.SetActive(true);
		purchase.gameObject.SetActive(false);
		unlockable.gameObject.SetActive(false);
		upgrade.gameObject.SetActive(false);
		
		powerupSprite.gameObject.SetActive(true);
		purchaseSprite.gameObject.SetActive(false);
		unlockableSprite.gameObject.SetActive(false);
		upgradeSprite.gameObject.SetActive(false);
		
		powerupScroll.gameObject.SetActive(true);
		unlockableScroll.gameObject.SetActive(false);
		upgradeScroll.gameObject.SetActive(false);
	}
}