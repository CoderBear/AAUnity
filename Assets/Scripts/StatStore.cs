using UnityEngine;
using System.Collections;

public class StatStore : MonoBehaviour
{
	public StatsDB db;
	
	public int multiplier;
	public int lifetime_apples;
	public int lifetime_games;
	public int fa_apples;
	public int fa_games;
	public int fa_time;
	public int fa_combo;
	public int fa_combo_total;
	public int fa_gamescore;
	public int p_apples;
	public int p_games;
	public int p_time;
	public int p_combo;
	public int p_combo_total;
	public int p_gamescore;

	// Use this for initialization
	void Start ()
	{
	}
	
	public void setupInfo(){
		multiplier = db.getValue("multiplier");
		lifetime_apples = db.getValue("lifetime_apples");
		lifetime_games = db.getValue("lifetime_games");
		
		fa_apples = db.getValue("fa_apples");
		fa_games = db.getValue("fa_games");
		fa_time = db.getValue("fa_time");
		fa_combo = db.getValue("fa_combo");
		fa_combo_total = db.getValue("fa_combo_total");
		fa_gamescore = db.getValue("fa_gamescore");
		
		p_apples = db.getValue("p_apples");
		p_games = db.getValue("p_games");
		p_time = db.getValue("p_time");
		p_combo = db.getValue("p_combo");
		p_combo_total = db.getValue("p_combo_total");
		p_gamescore = db.getValue("p_gamescore");
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
}