using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour {
	
	ParticleSystem myParticle;
	
	// Use this for initialization
	void Start () 
	{
		myParticle = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (myParticle.isStopped)
			Destroy(gameObject);
	}
}
