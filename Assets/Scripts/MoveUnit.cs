using UnityEngine;
using System.Collections;

public class MoveUnit : MonoBehaviour {
	
	public GameObject enemyBase;
	GameObject[] enemyBases;
	public GameObject target;
	public string enemy;
	public float attackRange;
	public float speed;
	public float health;
	public float damage;
	public GameObject spawnPoint;
	public GameObject bulletObject;
	public GameObject fireEffect;
	public float fireRate;
	public float destroyWorth;
	public GameObject playerB;
	public GameObject playerA;
	public AudioClip gunSound;
	bool isGameOver = false;
	
	float fireTime;
	float ground = 0.1f;
	
	// Use this for initialization
	void Start () 
	{
		enemyBases = new GameObject[1];
		enemyBases[0] = enemyBase;
		
		fireTime = Time.time - fireRate;
		
		if (name.Equals("Jeep_MainA") || name.Equals("Mrap_MainA") || name.Equals("P3J_MainA"))
			isGameOver = true;
		if (name.Equals("Jeep_MainB") || name.Equals("Mrap_MainB") || name.Equals("P3J_MainB"))
			isGameOver = true;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (!isGameOver)
		{
			//If enemyBase within range only attack enemybase
			if (enemyBase != null)
			{
				target = GetClosestEnemy(enemyBases);
				//Debug.Log(enemyBases[0].tag);
				
				//If enemyBase out of range attack closest target within range
				if (target == null)
					target = GetClosestEnemy(GameObject.FindGameObjectsWithTag(enemy));
				
				//If no enemies within range move towards enemyBase
				if (target == null && transform.position.y <= ground)
				{
					transform.Translate(0, 0, speed);
				}
				
				lookAtTarget();
				if (target != null)
					attack ();
			}
		}
	}
	
	void lookAtTarget()
	{
		if (gameObject.name.Equals("probeA(Clone)") || gameObject.name.Equals("probeB(Clone)"))
		{
			if (target == null)
				transform.LookAt(enemyBase.transform);
			else
				transform.LookAt(target.transform);	
		}
		else if (transform.position.y <= ground)
		{
			if (target == null)
				transform.LookAt(enemyBase.transform);
			else
			{
				transform.LookAt(target.transform);
				transform.Rotate(-transform.eulerAngles.x, 0, -transform.eulerAngles.z);
			}
		}
	}
	
	void gameOver()
	{
		isGameOver = true;
	}
	
	float getDestroyWorth()
	{
		return destroyWorth;
	}
	
	GameObject GetClosestEnemy(GameObject[] enemies)
	{
		// Find and return the closest enemy within range
		GameObject objMin = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		
		if (enemies.Length > 0)
		{	
			foreach (GameObject obj in enemies)
			{
				float dist = Vector3.Distance(obj.transform.position, currentPos);
				
				if (dist < minDist && dist <= attackRange)
				{
					objMin = obj;
					minDist = dist;
				}
			}
		}
		return objMin;
	}
	
	void attack()
	{		
		if (Time.time - fireTime >= fireRate)
		{
			audio.PlayOneShot(gunSound,1);
			Instantiate(fireEffect, spawnPoint.transform.position, spawnPoint.transform.rotation);
			GameObject bullet = (GameObject) Instantiate(bulletObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
			bullet.SendMessage("setTarget", target);
			bullet.SendMessage("setDamage", damage);
			
			fireTime = Time.time;
			
			//target.SendMessage("takeDamage", damage);
		}
	}
	
	void takeDamage(float dmg)
	{
		health -= dmg;
		
		if (health <= 0)
		{
			sendMoney();
			//print ("$" + destroyWorth + " Sent");
			
			if (gameObject.name.Equals("probeA(Clone)") || gameObject.name.Equals("probeB(Clone)"))
				SendMessage("switchCheckPoint");
		
			Destroy(gameObject);
		}
	}
	
	void sendMoney()
	{
		if (gameObject.tag.Equals("A") && playerB != null)
			playerB.SendMessage("addMoney", destroyWorth);
		else if (playerA != null)
			playerA.SendMessage("addMoney", destroyWorth);
	}
	
	//Prevents unit from sitting on checkpoint
	void OnTriggerStay(Collider collider)
	{
		if (collider.name.Equals("probeA(Clone)") || collider.name.Equals("probeB(Clone)"))
		{
			//print (collider.gameObject.name);	
			transform.Translate(new Vector3(0,-0.05f,0));
		}
	}
}
