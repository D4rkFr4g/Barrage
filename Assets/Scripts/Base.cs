using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
	
	public float health;
	public GameObject tower;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void takeDamage(float dmg)
	{
		health -= dmg;
		
		if (health <= 0)
		{
			tower.SendMessage("explode");
			Destroy(gameObject);
			
			GameObject.FindGameObjectWithTag("MainCamera").SendMessage("gameOver",gameObject.tag);
		}
	}
}
