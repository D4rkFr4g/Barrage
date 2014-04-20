using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public float sensitivityX = 0.5f;
	public float sensitivityY = 0.5f;
	public float sensitivityZ = 5.0f;
	public float minZoom = 14.0f;
	public float maxZoom = 50.0f;
	public float damping = 0.1f;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float maxSpeed;
	
	// Use this for initialization
	void Start () 
	{
		//GameObject map = GameObject.FindGameObjectWithTag("map");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float translateY = Input.GetAxis("Vertical") * sensitivityY;
        transform.Translate(0, translateY, 0);
        
        float translateX = Input.GetAxis("Horizontal") * sensitivityX;
        transform.Translate(translateX, 0, 0);
        
		//MouseWheel Zoom
		float translateZ = Input.GetAxis("Mouse ScrollWheel") * sensitivityZ;
		
/*        
		if (translateZ != 0.0f)
		{
			if (translateZ <= minZoom)
				translateZ = minZoom;
			else if (translateZ > maxZoom)
				translateZ = maxZoom;
		}
*/			
		//transform.Translate(0, 0, translateZ);
		
		if (translateZ != 0.0f)
		{
			//print(translateZ);
			Vector3 temp = new Vector3(transform.position.x, transform.position.y - translateZ, transform.position.z);
			transform.position = Vector3.MoveTowards(transform.position, temp, maxSpeed);
		}
		
		//	transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - translateZ, transform.position.z), Time.deltaTime * damping);
		
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
}
