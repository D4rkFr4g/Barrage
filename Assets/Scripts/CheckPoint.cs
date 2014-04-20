using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	
	public GameObject otherProbe;
	float angle = 0;
	Vector3 direction;
	public GameObject spawn2;
	
	// Use this for initialization
	void Start () 
	{
		if (gameObject.tag.Equals("B"))
			angle = 180;
		
		direction = new Vector3(0,angle,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void switchCheckPoint()
	{
			Instantiate(otherProbe, gameObject.transform.position,Quaternion.Euler(direction));
	}
}
