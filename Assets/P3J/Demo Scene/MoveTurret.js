#pragma strict

var speed : float = 30;

function Update () {

	// Turn Right
	if (Input.GetKey (KeyCode.D)) 
		transform.Rotate(Vector3(0, speed * Time.deltaTime, 0));

	// Turn Left
	if (Input.GetKey (KeyCode.A)) 
		transform.Rotate(Vector3(0, -speed * Time.deltaTime, 0));
		
}