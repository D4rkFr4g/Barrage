using UnityEngine;
using System.Collections;

public class myGUI : MonoBehaviour {
	
	public float FIXED_WIDTH = 0.82f;
	public float FIXED_HEIGHT = 0.35f; 
	public float width = 80.0f;
	public float height = 20.0f;
	
	void OnGUI () 
	{
		// Make a background box
		//GUI.Box(new Rect(10,10,100,90), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width * FIXED_WIDTH,Screen.height * FIXED_HEIGHT,width,height), "Start")) 
		{
			Application.LoadLevel(1);
		}

		// Make the second button.
		//if(GUI.Button(new Rect(20,70,80,20), "Difficulty")) 
		{
			//Application.LoadLevel(2);
		}
	}
}
