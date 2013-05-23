using UnityEngine;
using System.Collections;

public class PurchaseButton : MonoBehaviour {
	public bool purchaseActive = false;
	
	void OnClick() {
		Debug.Log("Get Combos Button Pressed");
		purchaseActive = !purchaseActive;
	}
}