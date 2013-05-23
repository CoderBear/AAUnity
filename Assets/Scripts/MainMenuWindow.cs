using UnityEngine;
using System.Collections;

public class MainMenuWindow : MonoBehaviour
{
	
	public GUISkin customSkin;
	// Textures
	public Texture t_title;
	public Texture t_basket;
	public Texture t_ray;
	public Texture t_fastApples;
	public Texture t_perfectionist;
	public Texture t_raySmall;
	// GUI Rects
	private Rect r_window = new Rect (0, 0, 1280, 720);
	private Rect r_basket = new Rect (130, 60, 420, 460);
	private Rect r_title = new Rect (90, 20, 500, 580);
	private Rect r_ray = new Rect (0, 40, 700, 700);
	private Rect r_rayFA = new Rect (590, 30, 300, 300);
	private Rect r_rayPM = new Rect (930, 30, 300, 300);
	private Rect faRect = new Rect (630, 100, 220, 160);
	private Rect pmRect = new Rect (940, 110, 280, 140);
	// Button Rects
	private Rect faButton = new Rect (580, 130, 320, 100);
	private Rect pmButton = new Rect (920, 130, 320, 100);
	private Rect statsButton = new Rect (580, 310, 320, 100);
	private Rect achievementsButton = new Rect (920, 310, 320, 100);
	private Rect helpButton = new Rect (580, 420, 320, 100);
	private Rect storeButton = new Rect (920, 420, 320, 100);
	private Rect optionsButton = new Rect (580, 530, 320, 100);
	private Rect purchaseButton = new Rect (920, 530, 320, 100);
	private Rect exitButton = new Rect(580, 640, 320, 100);
	
	private void Awake() {}
	
	// Use this for initialization
	public void Start ()
	{
	}
	
	// Update is called once per frame
	public void Update ()
	{
	}
	
	public void OnGUI ()
	{
		GUI.skin = customSkin;
		
		this.r_window = GUI.Window (0, r_window, new GUI.WindowFunction (DoMyWindow), string.Empty);
		this.r_window.x = Mathf.Clamp (this.r_window.x, 0, Screen.width - this.r_window.width);
		this.r_window.y = Mathf.Clamp (this.r_window.y, 0, Screen.height - this.r_window.height);
	}
	
	private void DoMyWindow (int windowID)
	{
		// Draw title screen on the left half of the screen
		// B->T 1) Ray, 2) Basket, 3) title
		GUI.DrawTexture(r_ray,t_ray);
		GUI.DrawTexture(r_basket, t_basket);
		GUI.DrawTexture(r_title, t_title);
		
		/*--- Menu Buttons ---*/
		// Fast Apples
		if (GUI.Button(faButton,string.Empty,GUI.skin.GetStyle("button"))) {
			Debug.Log("Fast Apples Button Pressed");
		}
		GUI.DrawTexture(r_rayFA,t_raySmall);
		GUI.DrawTexture(faRect, t_fastApples);
		
		// Perfectionist
		if (GUI.Button(pmButton,string.Empty,GUI.skin.GetStyle("button"))) {
			Debug.Log("Perfectionist Button Pressed");
		}
		GUI.DrawTexture(r_rayPM, t_raySmall);
		GUI.DrawTexture(pmRect, t_perfectionist);
		
		// Statistics
		if (GUI.Button(statsButton,"Statistics",GUI.skin.GetStyle("button"))) {
			Debug.Log("Statistics Button Pressed");
		}
		
		// Achievements
		if (GUI.Button(achievementsButton,"Achievements",GUI.skin.GetStyle("button"))) {
			Debug.Log("Acheivements Button Pressed");
			Application.LoadLevel("Achievements");
		}
		
		// Help
		if (GUI.Button(helpButton,"Help",GUI.skin.GetStyle("button"))) {
//			StoreWindow.StoreClosing();
			Debug.Log("Help Button Pressed");
			Application.LoadLevel("HelpMenu");
		}
		
		// Store
		if (GUI.Button(storeButton,"Store",GUI.skin.GetStyle("button"))) {
			Debug.Log("Store Button Pressed");
//			StoreWindow.OpenWindow();
		}
		
		// Options
		if (GUI.Button(optionsButton,"Options",GUI.skin.GetStyle("button"))) {
			Debug.Log("Options Button Pressed");
		}
		
		// Get Combos
		if (GUI.Button(purchaseButton,string.Empty,GUI.skin.GetStyle("Purchase Button"))) {
			Debug.Log("Get Combos Button Pressed");
//			StoreWindow.OpenPurchase();
		}
		
		// Exit Game App
		if(GUI.Button(exitButton, "Quit", GUI.skin.GetStyle("button"))) {
			Application.Quit();
		}
	}
}