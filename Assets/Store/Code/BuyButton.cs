using UnityEngine;
using System.Collections;

public class BuyButton : MonoBehaviour
{
	public bool clicked = false;
	public Store store;
	
	void OnClick()
	{
		clicked = !clicked;
		
		if(this.gameObject.tag == "Pack1") {
			Debug.Log("AAUNITY/SOOMLA Pack1 pressed");
			store.BuyPack1();
		}
		if(this.gameObject.tag == "Pack2") {
			Debug.Log("AAUNITY/SOOMLA Pack2 pressed");
			store.BuyPack2();
		}
		if(this.gameObject.tag == "Pack3") {
			Debug.Log("AAUNITY/SOOMLA Pack3 pressed");
			store.BuyPack3();
		}
		// Powerup goods
		if(this.gameObject.tag == "Shield"){
			store.BuyShield();
		}
		else if(this.gameObject.tag == "Energy"){
			store.BuyEnergy();
		}
		else if(this.gameObject.tag == "Seed"){
			store.BuySeed();
		}
		// Upgrade goods
		if(this.gameObject.tag == "Upgrade1") {
			store.BuyUpgrade1();
		}
		else if(this.gameObject.tag == "Upgrade2") {
			store.BuyUpgrade2();
		}
		else if(this.gameObject.tag == "Upgrade3") {
			store.BuyUpgrade3();
		}
		else if(this.gameObject.tag == "Upgrade4") {
			store.BuyUpgrade4();
		}
		else if(this.gameObject.tag == "Upgrade5") {
			store.BuyUpgrade5();
		}
		// Unlockable - Skin goods
		if(this.gameObject.tag == "Skin1") {
//			store.BuySkin1();
		}
		else if(this.gameObject.tag == "Skin2") {
//			store.BuySkin2();
		}
		else if(this.gameObject.tag == "Skin3") {
//			store.BuySkin3();
		}
		else if(this.gameObject.tag == "Skin4") {
//			store.BuySkin4();
		}
		else if(this.gameObject.tag == "Skin5") {
//			store.BuySkin5();
		}
		else if(this.gameObject.tag == "Skin6") {
//			store.BuySkin6();
		}
		// Unlockable - Background 
		if(this.gameObject.tag == "Background") {
		}
	}
}