using UnityEngine;
using System.Collections;

public class AchieveDB : MonoBehaviour {
		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public string getName(int id) {
		string name = "";
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		db.Open(dbFile);
		SQLiteQuery qr = new SQLiteQuery(db, "SELECT Name FROM achieve_table WHERE id=?");
		qr.Bind(id);
		while (qr.Step()) {
			name = qr.GetString("Name");
		}
		qr.Release();
		db.Close();
		return name;
	}
	
	public string getDesc(int id) {
		string description = "";
		
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		db.Open(dbFile);
		SQLiteQuery qr = new SQLiteQuery(db, "SELECT Description FROM achieve_table WHERE id=?");
		qr.Bind(id);
		while (qr.Step()) {
			description = qr.GetString("Description");
		}
		qr.Release();
		db.Close();
		
		return description;
	}
	
	public int getProgress(int id) {
		int num = 0;
		
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		db.Open(dbFile);
		SQLiteQuery qr = new SQLiteQuery(db, "SELECT Progress FROM achieve_table WHERE id=?");
		qr.Bind(id);
		qr.Step();
		num = qr.GetInteger("Progress");
		qr.Release();
		db.Close();
		
		return num;
	}
	
	public int getTarget(int id) {
		int num = 0;
		
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		db.Open(dbFile);
		SQLiteQuery qr = new SQLiteQuery(db, "SELECT Target FROM achieve_table WHERE id=?");
		qr.Bind(id);
		qr.Step();
		num = qr.GetInteger("Target");
		qr.Release();
		db.Close();
		
		return num;
	}
	
	public bool isUnlocked(int id) {
		bool result = false;
		int num;
		
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		db.Open(dbFile);
		SQLiteQuery qr = new SQLiteQuery(db, "SELECT Unlocked FROM achieve_table WHERE id=?");
		qr.Bind(id);
		qr.Step();
		num = qr.GetInteger("Unlocked");
		switch(num) {
		case 0:
			result = false;
			break;
		case 1:
			result = true;
			break;
		}
		
		qr.Release();
		db.Close();
		
		return result;
	}
	
	public void unlock(int id) {
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		int yes = 1;
		string query = "UPDATE achieve_table SET Unlocked = " + yes.ToString() + " WHERE id =" + id.ToString();
		db.Open(dbFile);
		
		SQLiteQuery qr = new SQLiteQuery(db, query);
		qr.Step();
		qr.Release();
		db.Close();
	}
	
	public void StoreProgress(int id, int progress) {
		string dbFile = Application.persistentDataPath + "/achieveDB_playmaker.db";
		SQLiteDB db = new SQLiteDB();
		
		string query = "UPDATE achieve_table SET Progress = " + progress.ToString() + " WHERE id =" + id.ToString();
		
		db.Open(dbFile);
		SQLiteQuery qr = new SQLiteQuery(db, query);
		qr.Step();
		qr.Release();
		db.Close();
	}
}