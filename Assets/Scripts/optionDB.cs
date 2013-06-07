using UnityEngine;
using System.Collections;

public class optionDB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void setStatus(int id, int choice)
    {
        string dbFile = Application.persistentDataPath + "/optionDB_playmaker.db";
        SQLiteDB db = new SQLiteDB();

        string query = "UPDATE option_table SET Unlocked = " + choice.ToString() + " WHERE id =" + id.ToString();
        db.Open(dbFile);

        SQLiteQuery qr = new SQLiteQuery(db, query);
        qr.Step();
        qr.Release();
        db.Close();
    }

    public bool getStatus(int id)
    {
        bool result = false;
        int num;

        string dbFile = Application.persistentDataPath + "/optionDB_playmaker.db";
        SQLiteDB db = new SQLiteDB();

        db.Open(dbFile);
        SQLiteQuery qr = new SQLiteQuery(db, "SELECT result FROM option_table WHERE id=?");
        qr.Bind(id);
        qr.Step();
        num = qr.GetInteger("result");
        switch (num)
        {
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
}