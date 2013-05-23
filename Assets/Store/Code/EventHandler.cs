using System;
using UnityEngine;

namespace com.soomla.unity.example
{
	public class AndyEventHandler
	{
		public AndyEventHandler() {
			Events.OnMarketPurchase += onMarketPurchase;
			Events.OnMarketRefund += onMarketRefund;
			Events.OnItemPurchased += onItemPurchased;
			Events.OnGoodEquipped += onVirtualGoodEquipped;
			Events.OnGoodUnEquipped += onVirtualGoodUnequipped;
			Events.OnGoodUpgrade += onGoodUpgrade;
			Events.OnBillingSupported += onBillingSupported;
			Events.OnBillingNotSupported += onBillingNotSupported;
			Events.OnMarketPurchaseStarted += onMarketPurchaseStarted;
			Events.OnItemPurchaseStarted += onItemPurchaseStarted;
			Events.OnClosingStore += onClosingStore;
			Events.OnOpeningStore += onOpeningStore;
			Events.OnUnexpectedErrorInStore += onUnexpectedErrorInStore;
			Events.OnCurrencyBalanceChanged += onCurrencyBalancedChanged;
			Events.OnGoodBalanceChanged += onGoodBalanceChanged;
			Events.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;
			Events.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
			Events.OnRestoreTransactions += onRestoreTransactions;
		}
	
		public void onMarketPurchase (PurchasableVirtualItem marketItem) {
			Debug.Log("AAUNITY/SOOMLA Going to purchase an item with productId: " + marketItem.ItemId);
		}
		
		public void onMarketRefund (PurchasableVirtualItem marketItem) {
		}
		
		public void onItemPurchased (PurchasableVirtualItem marketItem) {
		}
			
		public void onVirtualGoodEquipped (EquippableVG good) {
		}
		
		public void onVirtualGoodUnequipped (EquippableVG good) {
		}
		
		public void onGoodUpgrade(VirtualGood good, UpgradeVG currentUpgrade) {
			Debug.Log ("The current uprade of " + good.ItemId + " is " + currentUpgrade.ItemId);
		}
		
		public void onBillingSupported () {
		}
		
		public void onBillingNotSupported () {
		}
		
		public void onMarketPurchaseStarted (PurchasableVirtualItem marketItem) {
		}
		
		public void onItemPurchaseStarted (PurchasableVirtualItem marketItem) {
		}
		
		public void onMarketPurchaseCancelled (PurchasableVirtualItem marketItem) {
		}
		
		public void onClosingStore () {
		}
		
		public void onUnexpectedErrorInStore () {
		}
		
		public void onOpeningStore () {
		}
		
		public void onCurrencyBalancedChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded){
			Debug.Log("New currency balance is " + balance);
			LocalStoreInfo.UpdateBalances();
		}
		
		public void onGoodBalanceChanged( VirtualGood good, int balance, int amountAdded) {
			Debug.Log("New balance of VirtualGood " + good.Name + " is " + balance);
			LocalStoreInfo.UpdateBalances();
		}
		
		public void onRestoreTransactionsStarted() {
		}
		
		public void onRestoreTransactions(bool success) {
		}
	}
}