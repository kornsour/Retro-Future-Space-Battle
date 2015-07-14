using UnityEngine;
using System.Collections;

public class splashScript : MonoBehaviour {

	private float timer = 2f;

	public Camera main;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (main.transform.position.x == 6) 
		{
			timer -= Time.deltaTime;
			if(timer<=0)
			{
				Application.LoadLevel("main menu");
			}
		}
	
	}
}
