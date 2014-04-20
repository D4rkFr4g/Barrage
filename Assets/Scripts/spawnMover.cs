using UnityEngine;
using System.Collections;

public class spawnMover : MonoBehaviour {

	public float spawnMoveSpeed = 0.05f;
	public GameObject myBase;
	public GameObject furthest;
	public GameObject backWall;
	public GameObject frontWall;
	public float wallBuffer = 2;
	bool isGameOver = false;
	
	// Update is called once per frame
	void Update () 
	{
		if (!isGameOver)
		{
			//Move Spawner back and forth
			transform.Translate(spawnMoveSpeed, 0, 0);
			setToFurthestUnit();
		}
	}
	
	void gameOver()
	{
		isGameOver = true;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		//print ("Trigger: Spawner Hit Wall");
		spawnMoveSpeed *= -1;
	}
	
	void setToFurthestUnit()
	{
		Vector3 position;
		furthest = getFurthestUnit();
		
		if (furthest == null)
			furthest = gameObject;
		
		position = furthest.transform.position;
		
		
		float z = 0;

		if (transform.position.z > backWall.transform.position.z)
			z = backWall.transform.position.z - wallBuffer;
		else if (transform.position.z < frontWall.transform.position.z)
			z = frontWall.transform.position.z + wallBuffer;
		else
			z = position.z;

		
		transform.position = new Vector3(transform.position.x, transform.position.y, z);
	}
	
	GameObject getFurthestUnit()
	{
		GameObject[] allies = GameObject.FindGameObjectsWithTag("A");
		
		// Find and return the closest enemy within range
		GameObject objMax = null;
		float maxDist = Mathf.NegativeInfinity;
		Vector3 currentPos = myBase.transform.position;
		
		if (allies.Length > 0)
		{	
			foreach (GameObject obj in allies)
			{
				float dist = Vector3.Distance(obj.transform.position, currentPos);
				
				if (dist > maxDist && !obj.name.Equals("probeA(Clone)") && !obj.name.Equals("probeA") 
					&& !obj.name.Equals("Jeep_MainA") && !obj.name.Equals("Mrap_MainA") 
					&& !obj.name.Equals("P3J_MainA"))
				{
					objMax = obj;
					maxDist = dist;
				}
			}
		}
		else
			objMax = gameObject;
		
		//print ("maxDist = " + maxDist);
		furthest = objMax;
		return objMax;
	}
}
