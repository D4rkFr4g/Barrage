using UnityEngine;
using System.Collections;

public class DM : MonoBehaviour {
	
	public GameObject results;
	public float offset = 0.33f;
	bool isGameOver = false;
	public float FIXED_WIDTH = 0.45f;
	public float FIXED_HEIGHT = 0.6f;
	public float width = 80.0f;
	public float height = 20.0f;
	public float moneyRate = 1.0f;
	float moneyTime;
	public float moneyPerTime = 1.0f;
	public GameObject player1;
	public GameObject player2;
	Vector3 checkPointPos;
	
	void Start()
	{
		checkPointPos = new Vector3(102,7,102);
		Instantiate(GameObject.Find("probeA"), checkPointPos, Quaternion.identity);
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		//Give out Free Money!!!
		if (!isGameOver)
		{
			if (Time.time - moneyTime >= moneyRate)
			{
				player1.SendMessage("addMoney", moneyPerTime);
				player2.SendMessage("addMoney", moneyPerTime);
				moneyTime = Time.time;
			}
		}
	}
	
	void gameOver(string loser)
	{
		isGameOver = true;
		
		results.gameObject.SetActive(true);
		
		if (loser.Equals("baseB"))
			results.renderer.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
		
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("A"))
		{
			obj.SendMessage("gameOver");
		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("B"))
		{
			obj.SendMessage("gameOver");
		}
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("turret"))
		{
			obj.SendMessage("gameOver");
		}
		
		GameObject.FindGameObjectWithTag("enemySpawn").SendMessage("gameOver");
		
	}
	
	void OnGUI () 
	{
		if (isGameOver)
		{
			if(GUI.Button(new Rect(Screen.width * FIXED_WIDTH,Screen.height * FIXED_HEIGHT,width,height), "Main Menu")) 
			{
				Application.LoadLevel(0);
			}
		}
	}
}
