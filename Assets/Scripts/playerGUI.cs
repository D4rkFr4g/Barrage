using UnityEngine;
using System.Collections;

public class playerGUI : MonoBehaviour {
	
	public float quit_x = 0.85f;
	public float quit_y = 0.01f;
	public float quit_width = 80.0f;
	public float quit_height = 20.0f;
	
	public float units_x = 0.0f;
	public float units_y = 0.0f;
	public float unit_width = 58.0f;
	public float unit_height = 52.0f;
	
	public float score_x = 0.01f;
	public float score_y = 0.85f;
	public float score_width = 90.0f;
	public float score_height = 60.0f;
	
	public float score_x2 = 0.82f;
	public float score_y2 = 0.85f;
	public float score_width2 = 110.0f;
	public float score_height2 = 60.0f;
	
	public Texture unit1Texture;
	public Texture unit2Texture;
	public Texture unit3Texture;
	PlayerControl player;
	public GameObject enemyBase;
	enemySpawn computer;
	
	float unit_spacing = 60.0f;
	
	void Start()
	{
		player = (PlayerControl) gameObject.GetComponent("PlayerControl");
		computer = (enemySpawn) enemyBase.GetComponent("enemySpawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () 
	{
		// Make a background box
		//GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		GUI.BeginGroup(new Rect(Screen.width * score_x, Screen.height * score_y, score_width, score_height));
		GUI.Box(new Rect(0,0,100,20),"");
		GUI.Label(new Rect(5,0,100,50),"Money: $" + player.myMoney);
		GUI.EndGroup();
		
		GUI.BeginGroup(new Rect(Screen.width * score_x2, Screen.height * score_y2, score_width2, score_height2));
		GUI.Box(new Rect(0,0,110,20),"");
		GUI.Label(new Rect(5,0,100,50),"Computer: $" + computer.myMoney);
		GUI.EndGroup();
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width * quit_x,Screen.height * quit_y,quit_width,quit_height), "Quit")) 
		{
			Application.LoadLevel(0);
		}
		
		//Unit Selection Box
		GUI.BeginGroup(new Rect(Screen.width * units_x,Screen.height * units_y,unit_width,unit_height * 4));
		if(GUI.Button(new Rect(0, 0, unit_width, unit_height), unit1Texture)) 
		{
			gameObject.SendMessage("setSpawnObject", 1);
		}
		GUI.Label(new Rect(35,0,100,100),"$10");
		
		if(GUI.Button(new Rect(0, unit_spacing, unit_width, unit_height), unit2Texture)) 
		{
			gameObject.SendMessage("setSpawnObject", 2);
		}
		GUI.Label(new Rect(35,unit_spacing,100,100),"$50");
		
		if(GUI.Button(new Rect(0, unit_spacing * 2, unit_width, unit_height), unit3Texture)) 
		{
			gameObject.SendMessage("setSpawnObject", 3);
		}
		GUI.Label(new Rect(30,unit_spacing * 2,100,100),"$100");
		GUI.EndGroup();
	}
}
