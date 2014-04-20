using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
	
	public float spawnRate;
	float spawnTime;
	Vector3 spawnPosition;
	GameObject spawnObject;
	public GameObject spawner;
	public float myMoney = 100.0f;
	float spawnCost;
	GameObject unit1;
	GameObject unit2;
	GameObject unit3;
	public float unit1SpawnCost = 10;
	public float unit2SpawnCost = 50;
	public float unit3SpawnCost = 100;
	public float saveTime = 0.0f;
	public float saveMaxTime = 5.0f;
	bool isSaving = false;

	// Use this for initialization
	void Start () 
	{
		//spawnObject = GameObject.FindGameObjectWithTag("jeepA");
		unit1 = GameObject.Find("Jeep_MainA");
		unit2 = GameObject.Find("Mrap_MainA");
		unit3 = GameObject.Find("P3J_MainA");
		
		//Initialize first object to be spawned
		//spawnObject = unit1;
		//spawnCost = unit1SpawnCost;
		
		//Setup the enemy spawn location
		spawnPosition = spawner.transform.position;
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (!isSaving)
		{
			
			if (myMoney >= unit3SpawnCost + 30)
				setSpawnObject(3);
			else if (myMoney >= unit2SpawnCost + 30)
				setSpawnObject(2);
			else
				setSpawnObject(1);
			
			spawn();
			//Debug.Log(Time.time - spawnTime);
			if (Time.time - spawnTime >= spawnRate)
			{
				//spawn();
				//spawnTime = Time.time;
				isSaving = true;
				saveTime = Time.time;
			}
		}
		else
		{
			if (Time.time - saveTime >= saveMaxTime)
				isSaving = false;
			
			spawnTime = Time.time;
		}
	}
	
	public void addMoney(float amount)
	{
		myMoney += amount;
	}
	
	bool subtractMoney(float amount)
	{
		if (myMoney < amount)
			return false;
		else
		{
			myMoney -= amount;
			return true;
		}
	}
	
	void spawn()
	{
		spawnPosition = spawner.transform.position;
		spawnPosition = new Vector3(spawnPosition.x, 10, spawnPosition.z);
		
		if (subtractMoney(spawnCost))
		{
			//print("My Money: " + myMoney);
			//print("Spawn cost: " + spawnCost);
			Instantiate(spawnObject,spawnPosition,Quaternion.Euler(0,180,0));
		}
	}	
	
	void setSpawnObject(int unit)
	{
		switch (unit)
		{	
		case 1:	
			spawnObject = unit1;
			spawnCost = unit1SpawnCost;
			break;
		case 2:
			spawnObject = unit2;
			spawnCost = unit2SpawnCost;
			break;
		case 3:
			spawnObject = unit3;
			spawnCost = unit3SpawnCost;
			break;
		}	
	}
}
