using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {

	public float speed;
	//public float range;
	public GameObject particleExplode;
	public GameObject target;
	
	float damage;
	
	//float dist;
	
	// Update is called once per frame
	void Update () 
	{
		if (target != null)
		{
			transform.LookAt(target.transform);
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}
		else
			Destroy(gameObject);
	}
	
	void setTarget(GameObject obj)
	{
		target = obj;
	}
	
	void setDamage(float dmg)
	{
		damage = dmg;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		//Add damage call to this section instead of from gun
		if (collider.gameObject == target)
		{
			target.SendMessage("takeDamage", damage);
			Instantiate(particleExplode, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
