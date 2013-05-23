using UnityEngine;
using System.Collections;
using com.soomla.unity;
using com.soomla.unity.example;

public class SeedButton : MonoBehaviour
{
	public bool pressed = false;
	public int balance = 0;
	string itemId;
	public tk2dTextMesh textMesh;
	
	// Use this for initialization
	void Start ()
	{
		itemId = AndysApplesAssets.SUPER_SEED_GOOD.ItemId;
		balance = StoreInventory.GetItemBalance (itemId);
		Debug.Log ("Seed-Powerup Balance at Fast Apples Game Start: " + balance);
		this.gameObject.SetActive (false);
		textMesh.text = balance.ToString ();
		textMesh.Commit ();
	}
	
	void ShowIcon ()
	{
		this.gameObject.SetActive (true);
	}
	
	void HideIcon ()
	{
		this.gameObject.SetActive (false);
	}

	void OnClick ()
	{
		pressed = true;
	}
	
	public void clickedFA ()
	{
		if (balance > 0)
			StoreInventory.TakeItem (itemId, 1);
		
//		balance = StoreInventory.GetItemBalance (itemId);
//		textMesh.text = balance.ToString ();
//		textMesh.Commit ();
	}
	
	public void clickedPM ()
	{
		if (balance > 0)
			StoreInventory.TakeItem (itemId, 1);
		
//		balance = StoreInventory.GetItemBalance (itemId);
//		textMesh.text = balance.ToString ();
//		textMesh.Commit ();
	}

}