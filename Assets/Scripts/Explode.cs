using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour 
{
	public AudioClip explosion;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void explode()
	{
		audio.PlayOneShot(explosion, 1);
	}
}
