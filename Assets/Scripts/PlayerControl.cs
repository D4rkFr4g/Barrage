using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{	
	public float sensitivityX = 0.75f;
	public float sensitivityY = 0.75f;
	public float sensitivityZ = 20.0f;
	public float minZoom = 14.0f;
	public float maxZoom = 50.0f;
	public float damping = 5.0f;
	public float minX = 55.0f;
	public float maxX = 145.0f;
	public float minY = 30.0f;
	public float maxY = 170.0f;
	public float maxSpeed = 1.0f;
	GameObject spawnObject;
	bool isSpawning = false;
	public float spawnHeight;
	float spawnCost;
	public float myMoney;
	GameObject unit1;
	public float unit1SpawnCost;
	GameObject unit2;
	public float unit2SpawnCost;
	GameObject unit3;
	public float unit3SpawnCost;
	public float spawnDistance = 10;
	
	// Use this for initialization
	void Start () 
	{
		unit1 = GameObject.Find("Jeep_MainB");
		unit2 = GameObject.Find("Mrap_MainB");
		unit3 = GameObject.Find("P3J_MainB");
		setSpawnObject(1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
			isSpawning = true;
		if(Input.GetMouseButtonUp(0))
			isSpawning = false;
		
		if(isSpawning)
				spawn();
		
		if (sensitivityX > 0f)
		{
			float translateY = Input.GetAxis("Vertical") * sensitivityY;
        	transform.Translate(0, translateY, 0);
		}
		
		if (sensitivityY > 0f)
		{
        	float translateX = Input.GetAxis("Horizontal") * sensitivityX;
       		transform.Translate(translateX, 0, 0);
		}
		
		if (sensitivityZ > 0f)
		{
			//MouseWheel Zoom
			float translateZ = Input.GetAxis("Mouse ScrollWheel") * sensitivityZ;
			transform.Translate(0, 0, translateZ);
		}

		//Boundaries
		if (transform.position.y < minZoom)
			transform.Translate(0, 0, transform.position.y - minZoom);
		if (transform.position.y > maxZoom)
			transform.Translate(0, 0, transform.position.y - maxZoom);
		if (transform.position.x < minX)
			transform.Translate(minX - transform.position.x, 0, 0);
		if (transform.position.x > maxX)
			transform.Translate(maxX - transform.position.x, 0, 0);
		if (transform.position.z < minY)
			transform.Translate(0, minY - transform.position.z, 0);
		if (transform.position.z > maxY)
			transform.Translate(0, maxY - transform.position.z, 0);
			
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
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	RaycastHit hit=new RaycastHit();
   
		//float closest = GetClosestAlly(GameObject.FindGameObjectsWithTag("B"));
			
		if(Physics.Raycast(ray,out hit) && ((hit.collider.name.Equals("spawnPlane1")) 
			|| (hit.collider.name.Equals("spawnPlane2") && getClosestAlly(hit.point) <= spawnDistance)))
		{
			Vector3 spawnPoint = new Vector3(hit.point.x, spawnHeight, hit.point.z);
			
			if (subtractMoney(spawnCost))
			{
				//print("My Money: " + myMoney);
				//print("Spawn cost: " + spawnCost);
				Instantiate(spawnObject,spawnPoint,Quaternion.Euler(0,0,0));
			}
		}
	}
	
	float getClosestAlly(Vector3 hit)
	{
		GameObject[] allies = GameObject.FindGameObjectsWithTag("B");
		
		// Find and return the closest enemy within range
		//GameObject objMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = hit;
		
		if (allies.Length > 0)
		{	
			foreach (GameObject obj in allies)
			{
				float dist = Vector3.Distance(obj.transform.position, currentPos);
				
				if (dist < minDist)
				{
					//objMin = obj;
					minDist = dist;
				}
			}
		}
		//print ("minDist = " + minDist);
		return minDist;
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
