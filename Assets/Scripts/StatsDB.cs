using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Threading;

public class StatsDB : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
	}
	
	public int getValue (string name)
	{
		int num = 0;
		string filename = Application.persistentDataPath + "/statsDB_playmaker.db";
					
		SQLiteDB db = new SQLiteDB ();
		SQLiteQuery qr;
		string query = "SELECT value FROM stats_table WHERE name =?";
		db.Open (filename);
		qr = new SQLiteQuery (db, query);
		qr.Bind (name);
		qr.Step ();
		num = qr.GetInteger ("value");
		qr.Release ();
		db.Close ();
		
		return num;
	}
	
	public void StoreValue (int id, int a_value)
	{	
		SQLiteQuery qr;
		string query = "UPDATE stats_table SET value = " + a_value.ToString() + " WHERE id =" + id.ToString();
		
		SQLiteDB db = new SQLiteDB ();
		string filename = Application.persistentDataPath + "/statsDB_playmaker.db";
					
		db.Open (filename);
		qr = new SQLiteQuery (db, query);
		qr.Step ();
		qr.Release();
		db.Close ();
	}
}