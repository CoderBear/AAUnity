using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;


public class Analytics : MonoBehaviour {
	
	public string uacode = "UA-XXXXXXXX-1";
	public string domain = "mydomain.com";
	public string applicationName = "MyGame";
	
	int cookieId;
	int sessionStart;
	int lastUpdate;
	string lastPage;
	int visits;
	int siteId;
	int lastSessionStart;
	int firstSessionStart;
	
	void Start () {
		DontDestroyOnLoad(gameObject);
		siteId = domain.GetHashCode();
		cookieId = PlayerPrefs.GetInt("cookieId", -1);
		if(cookieId < 0) {
			cookieId  = RandomID();	
			PlayerPrefs.SetInt("cookieId", cookieId);
			PlayerPrefs.SetInt("firstSessionStart", Epoch());
		}
		firstSessionStart = PlayerPrefs.GetInt("firstSessionStart", Epoch());
		lastSessionStart = PlayerPrefs.GetInt("lastSessionStart", Epoch());
		visits = PlayerPrefs.GetInt("visits", 1);
		sessionStart = Epoch();
		
		PlayerPrefs.SetInt("lastSessionStart", sessionStart);
		PlayerPrefs.SetInt("visits", visits+1);
		
		lastPage = null;
		RegisterView("");
	}
	
	public void RegisterView(string pageTitle) {
		Debug.Log(cookieId);
		var q = new Dictionary<string,string>();
		if(lastPage != null) 
			q["utmr"] = WWW.EscapeURL(string.Format("http://{0}/{1}", domain, lastPage));
		q["utmje"] = "0";
		q["utmcs"] = "-";
		q["utmfl"] = "-";
		q["utmcr"] = "1";
		q["utmwv"] = "4.6.5";
		q["utmac"] = uacode;
		q["utmdt"] = WWW.EscapeURL(pageTitle);
		q["utmhn"] = WWW.EscapeURL(domain);
		q["utmn"] = RandomID().ToString();
		q["utmsc"] = WWW.EscapeURL("24-bit");
		q["utmsr"] = string.Format("{0}x{1}", Screen.width, Screen.height);
		q["utmul"] = "en";
		q["utmp"] = lastPage = applicationName + "/" + pageTitle;
		var utma = string.Format("__utma={0}.{1}.{2}.{3}.{4}.{5};", siteId, cookieId, firstSessionStart, lastSessionStart, sessionStart, visits);
		var utmb = string.Format("__utmb={0};", siteId);
		var utmc = string.Format("__utmc={0};", siteId);
		var utmz = string.Format("__utmz={0}.{1}.{2}.1.utmccn=(direct)|utmcsr=(direct)|utmcmd=(none);", siteId, Epoch(), visits);
		q["utmcc"] = WWW.EscapeURL(string.Format("{0}+{1}+{2}+{3}", utma, utmb, utmc, utmz));
		var url = "http://www.google-analytics.com/__utm.gif?";
		foreach(var i in q) {
			url = url + string.Format("{0}={1}&", i.Key, i.Value);
		}
		url = url.Substring(0, url.Length-1);
		StartCoroutine(SendRequest(url));
	}
	
	IEnumerator SendRequest(string url) {
		var www = new WWW(url);
		yield return www;
		
	}
	
	int RandomID() {
		return UnityEngine.Random.Range(0, 2147483647);
	}
		              
	int Epoch() {
		return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
	}
	

}
